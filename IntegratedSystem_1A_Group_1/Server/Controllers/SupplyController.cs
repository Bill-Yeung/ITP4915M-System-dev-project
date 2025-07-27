using EntityModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using DatabaseAccessController;
using Server.Helper;
using Newtonsoft.Json;
using static EntityModels.Supplier;
using System.Data.SqlTypes;
namespace Server.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class SupplyController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        dboDatabaseController dbo;
        public SupplyController(IConfiguration configuration)
        {
            _configuration = configuration;
            dbo = new dboDatabaseController(_configuration["ConnectionStrings"]);
        }
        [HttpPost("AddMaterial")]
        //public string addMaterial([FromBody] Dictionary<string, object> materialData) 
        public string addMaterial([FromBody] Dictionary<string, Object> materialData)
        {
            try
            {
                string table = "rawmaterial";

                string sqlCmd = UpdateData.InsertData(materialData, table);
                sqlCmd = sqlCmd + @"UPDATE rawmaterial
                        SET stockStatus = 
                            CASE 
                                WHEN inStockQuantity = 0 THEN 'EMPTY'
                                WHEN inStockQuantity <= lowLevelAlertIndex THEN 'LOW_STOCK'
                                ELSE 'NORMAL'
                            END;";

                return dbo.BatchUpdate(sqlCmd).ToString();
            }
            catch (Exception ex)
            {

                return "0";
            }
        }

        [HttpGet("GetNameList")]
        public string getNameList(string tableName, string fieldName)
        {
            try
            {
                string jsonString = JsonConvert.SerializeObject(dbo.GetSpecifyData(tableName, fieldName, null));
                // string jsonString = JsonConvert.SerializeObject(dbo.GetALLData(tableName));
                return jsonString;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpGet("GetMaxID")]
        public string getAllID(string tableName, string fieldName)
        {
            try
            {
                string jsonString = JsonConvert.SerializeObject(dbo.GetSpecifyData(tableName, fieldName, $"ORDER BY {fieldName} DESC"));
                return jsonString;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //[HttpPost("AddRestockRequest")]
        //public string addRestockRequest([FromBody] Dictionary<string, object> restockData)
        //{
        //    try
        //    {
        //        string table = "restockrequest";
        //        string sqlCmd = UpdateData.InsertData(restockData, table);
        //        return dbo.BatchUpdate(sqlCmd).ToString();
        //    }
        //    catch (Exception ex)
        //    {
        //        return "0";
        //    }
        //}
        [HttpGet("GetSupplierData")]
        public string getAllData()
        {
            try
            {
                string sql = $"SELECT * FROM supplier";
                string jsonString = JsonConvert.SerializeObject(dbo.GetData(sql));
                return jsonString;

            }
            catch (Exception ex)
            {
                return "0";
            }
        }


        [HttpGet("SearchSupplier")]
        public string searchSupplier(string term)
        {

            try
            {
                //string sql = $"SELECT * FROM supplier WHERE supplierName LIKE '%{term}%'";
                string sql = $"SELECT * FROM supplier WHERE supplierName LIKE '%{term}%' OR supplierEmail LIKE '%{term}%' OR supplierAddress LIKE '%{term}%' OR contactPerson LIKE '%{term}%'";
                string jsonString = JsonConvert.SerializeObject(dbo.GetData(sql));
                return jsonString;
            }
            catch (Exception ex)
            {
                return "0";
            }
        }
        [HttpPost("AddSupplier")]
        public string addSupplier([FromBody] Dictionary<string, Object> supplierData)
        {
            try
            {
                string table = "supplier";
                string sqlCmd = UpdateData.InsertData(supplierData, table);
                return dbo.BatchUpdate(sqlCmd).ToString();
            }
            catch (Exception ex)
            {

                return "0";
            }
        }
        [HttpPost("AddMaterialDemand")]
        public string addMaterialDemand([FromBody] string values)
        {

            string columns = "(demandID, materialID, quantity, expectedDate, receiver)";
            try
            {
                string table = "materialdemand";
                string sqlCmd = $"INSERT INTO `{table}` {columns} VALUES {values}";
                return dbo.BatchUpdate(sqlCmd).ToString();
            }
            catch (Exception ex)
            {

                return "0";
            }
        }
        [HttpPost("AddRestockRequest")]
        public string addRestockRequest([FromBody] List<Dictionary<string, Object>> data)
        {
            try
            {
                string table = "restockrequest";
                string sqlCmd = UpdateData.multiInsertData(data, table);
                return dbo.BatchUpdate(sqlCmd).ToString();
            }
            catch (Exception ex)
            {

                return "0";
            }

        }
        [HttpGet("GetMaterialData")]
        public string getMaterialData()
        {

            try
            {
                // string columns="m.materialID,m.materialName,inStockQuantity,"
                //string sql = "SELECT m.materialID,m.materialName,m.instockQuantity,m.price,m.stockStatus,IFNULL(r.totalRestock, 0) AS totalRestockRequested,IFNULL(md.totalDemand, 0) AS totalDemandRequested FROM rawmaterial m LEFT JOIN (SELECT materialID, SUM(restockQuantity) AS totalRestock FROM restockrequest GROUP BY materialID) r ON m.materialID = r.materialID LEFT JOIN (SELECT materialID, SUM(quantity) AS totalDemand FROM materialdemand GROUP BY materialID) md ON m.materialID = md.materialID;";
                string sql = @"SELECT 
                            m.materialID,
                            m.materialName,
                            m.inStockQuantity,
                            m.price,
                            m.stockStatus,
                            IFNULL(r.totalRestock, 0) AS totalRestockRequested,
                            IFNULL(md.totalDemand, 0) AS totalDemandRequested 
                        FROM 
                            rawmaterial m 
                        LEFT JOIN 
                            (SELECT materialID, SUM(restockQuantity) AS totalRestock 
                             FROM restockrequest 
                             WHERE restockStatus NOT IN ('Completed', 'Cancelled')
                             GROUP BY materialID) r ON m.materialID = r.materialID 
                        LEFT JOIN 
                            (SELECT materialID, SUM(quantity) AS totalDemand 
                             FROM materialdemand 
                             WHERE status NOT IN ('COMPLETED', 'CANCELLED')
                             GROUP BY materialID) md ON m.materialID = md.materialID;";
                string jsonString = JsonConvert.SerializeObject(dbo.GetData(sql));
                return jsonString;
            }
            catch (Exception ex)
            {
                return "0";
            }
        }
        [HttpGet("GetRestockRequest")]
        public string getRestockRequest()
        {
            try
            {
                string sql = $"SELECT r.*,m.materialName FROM restockrequest r,rawmaterial m WHERE r.materialID=m.materialID ORDER BY expectedDate";
                string jsonString = JsonConvert.SerializeObject(dbo.GetData(sql));
                return jsonString;
            }
            catch (Exception ex)
            {
                return "0";
            }
        }
        [HttpPost("UpdateRestock")]
        public string updateStatus([FromBody] RestockUpdate data, string btnEvent)
        {
            try
            {
                string sqlCmd = "";
                string table = "restockrequest";
                if (btnEvent == "edit")
                {
                    sqlCmd = $"UPDATE {table} SET restockQuantity={data.restockQuantity},updatedDate='{data.updatedDate}',expectedDate='{data.expectedDate}',restockStatus='{data.restockStatus}' WHERE restockRequestID='{data.restockRequestID}' AND materialID='{data.materialID}';";
                }
                else if (btnEvent == "updateStatus")
                {
                    string status = data.restockStatus;
                    string incolumns = "(transferID,transferType,InOrOut,itemType,itemID,quantity,date,`from`)";
                    string invalues = $"('{data.restockRequestID}','Restock','INBOUND','Material','{data.materialID}',{data.restockQuantity},'{data.updatedDate}','{data.supplierID}')";

                    if (status == "Completed")
                    {
                        sqlCmd = $"UPDATE {table} SET restockStatus='{status}',updatedDate='{data.updatedDate}' WHERE restockRequestID='{data.restockRequestID}' AND materialID='{data.materialID}';";
                        sqlCmd = sqlCmd + $"INSERT INTO inventoryinandout {incolumns} VALUES {invalues};";
                        sqlCmd = sqlCmd + $"UPDATE rawmaterial SET inStockQuantity=inStockQuantity+{data.restockQuantity} WHERE materialID='{data.materialID}';";
                        sqlCmd = sqlCmd + $"UPDATE rawmaterial SET stockStatus='NORMAL' WHERE inStockQuantity>lowLevelAlertIndex and materialID='{data.materialID}';";
                    }
                    else if (status == "Cancelled")

                    {
                        sqlCmd = $"UPDATE {table} SET restockStatus = '{status}' WHERE restockRequestID='{data.restockRequestID}' AND materialID='{data.materialID}';";
                    }
                }

                return dbo.BatchUpdate(sqlCmd).ToString();
            }
            catch (Exception ex)
            {

                return "0";
            }
        }
        [HttpGet("SearchRestockData")]
        public string searchRestockData(string term)
        {
            {

                try
                {
                    //string sql = $"SELECT * FROM supplier WHERE supplierName LIKE '%{term}%'";
                    //string sql = $"SELECT * FROM restockrequest WHERE restockrequestID LIKE '%{term}%' OR materialID LIKE '%{term}%' OR restockStatus LIKE '%{term}%';";
                    string searchScope = "(r.restockrequestID,r.materialID,r.restocKStatus,m.materialName)";
                    string sql = $"SELECT r.*,m.materialName FROM restockrequest r,rawmaterial m WHERE r.materialID=m.materialID AND CONCAT{searchScope} LIKE '%{term}%'";
                    string jsonString = JsonConvert.SerializeObject(dbo.GetData(sql));
                    return jsonString;
                }
                catch (Exception ex)
                {
                    return "0";
                }
            }

        }
        [HttpPost("UpdateSupplier")]
        public string updateSupplier([FromBody] Supplier supplier)
        {
            try
            {
                string table = "supplier";
                string sqlCmd = $"UPDATE {table} SET supplierName='{supplier.supplierName}',supplierPhone='{supplier.supplierPhone}',supplierEmail='{supplier.supplierEmail}',supplierAddress='{supplier.supplierAddress}',contactPerson='{supplier.contactPerson}',status='{supplier.status}' WHERE supplierID='{supplier.supplierID}';";
                return dbo.BatchUpdate(sqlCmd).ToString();
            }
            catch (Exception ex)
            {
                return "0";
            }
        }
        [HttpGet("SearchData")]
        public string searchData(string tableName, string columns, string? scope1, string? scope2, string term)
        {
            try
            {
                string sql = "";
                string searchScope = "(r.restockrequestID,r.materialID,r.restocKStatus,m.materialName)";
                //string sql = $"SELECT {columns} FROM {tableName} WHERE r.materialID=m.materialID AND CONCAT{searchScope} LIKE '%{term}%'";
                if (scope1 != null && scope2 != null)
                    sql = $"SELECT {columns} FROM {tableName} WHERE {scope1} AND {scope2} LIKE '%{term}%'";
                if (scope1 != null & scope2 == null)
                    sql = $"SELECT {columns} FROM {tableName} WHERE {scope1} LIKE '%{term}%'";
                string jsonString = JsonConvert.SerializeObject(dbo.GetData(sql));
                return jsonString;
            }
            catch (Exception ex)
            {
                return "0";
            }
        }
        [HttpGet("GetAllDemands")]
        public string getAllDemands()
        {
            try
            {
                //{   string columns= "d.*,m.materialName";
                string sql = "SELECT d.*,m.materialName From materialdemand d,rawmaterial m WHERE d.materialID=m.materialID ORDER BY expectedDate";
                string jsonString = JsonConvert.SerializeObject(dbo.GetData(sql));
                return jsonString;
            }
            catch (Exception ex)
            {
                return "0";
            }

        }
        [HttpPost("UpdateDemandStatus")]
        public string updateDemand([FromBody] DemandUpdate data)
        {
            try
            {
                string table = "materialdemand";
                string status = data.status;
                string incolumns = "(transferID,transferType,InOrOut,itemType,itemID,quantity,date,`to`)";
                string invalues = $"('{data.demandID}','MATERIAL_DEMAND','OUTBOUND','Material','{data.materialID}',{data.quantity},'{data.updatedAt}','Production DPT')";
                string sqlCmd = $"UPDATE {table} SET status = '{status}',updatedAt='{data.updatedAt}' WHERE demandID='{data.demandID}' AND materialID='{data.materialID}';";
                if (status == "COMPLETED")

                    sqlCmd = sqlCmd + $"INSERT INTO inventoryinandout {incolumns} VALUES {invalues};";
                sqlCmd = sqlCmd + $"UPDATE rawmaterial SET inStockQuantity=inStockQuantity-{data.quantity} WHERE materialID='{data.materialID}';";
                sqlCmd = sqlCmd + $"UPDATE rawmaterial SET stockStatus='LOW_STOCK' WHERE materialID='{data.materialID}' AND instockQuantity<=lowLevelAlertIndex;";
                return dbo.BatchUpdate(sqlCmd).ToString();
            }
            catch (Exception ex)
            {
                return "0";
            }
        }
        [HttpGet("GetInventoryData")]
        public string getInventory()
        {
            try
            {

                string sql = @"
                    SELECT 
                        r.materialID AS MaterialID,
                        r.materialName AS MaterialName,
                        r.inStockQuantity AS CurrentStock,
                        r.unit AS Unit,
                        r.lowLevelAlertIndex AS AlertLevel,
                        CASE 
                            WHEN r.inStockQuantity <= 0 THEN 'OUT_OF_STOCK'
                            WHEN r.inStockQuantity <= r.lowLevelAlertIndex THEN 'LOW_STOCK'
                            ELSE 'NORMAL'
                        END AS StockStatus,
                        IFNULL(rs.totalRestock, 0) AS PendingRestock,
                        IFNULL(d.totalDemand, 0) AS PendingDemand,
                        (r.inStockQuantity + IFNULL(rs.totalRestock, 0) - IFNULL(d.totalDemand, 0)) AS ProjectedStock,
                        DATE_FORMAT(MAX(t.date), '%Y-%m-%d') AS LastUpdated
                    FROM 
                        rawmaterial r
                    LEFT JOIN 
                        (SELECT materialID, SUM(quantity) AS totalDemand
                         FROM materialdemand
                         WHERE status NOT IN ('COMPLETED','CANCELLED')
                         GROUP BY materialID) d ON r.materialID = d.materialID
                    LEFT JOIN 
                        (SELECT materialID, SUM(restockQuantity) AS totalRestock
                         FROM restockrequest
                         WHERE restockStatus NOT IN ('COMPLETED','CANCELLED')
                         GROUP BY materialID) rs ON r.materialID = rs.materialID
                    LEFT JOIN 
                        inventoryinandout t ON r.materialID = t.itemID AND t.itemType = 'MATERIAL'
                    GROUP BY 
                        r.materialID, r.materialName, r.inStockQuantity, r.unit, r.lowLevelAlertIndex, rs.totalRestock, d.totalDemand;";
                string jsonString = JsonConvert.SerializeObject(dbo.GetData(sql));
                return jsonString;
            }
            catch (Exception ex)
            {
                return "0";
            }

        }
        [HttpGet("GetData")]
        public string getData(string tableName, string columns, string? cond)
        {
            try
            {
                string jsonString = "";
                if (cond == null)
                    jsonString = JsonConvert.SerializeObject(dbo.GetSpecifyData(tableName, columns, null));
                else
                    jsonString = JsonConvert.SerializeObject(dbo.GetSpecifyData(tableName, columns, cond));
                return jsonString;

            }
            catch (Exception ex)
            {
                return "0";
            }

        }
        [HttpPost("UpdateMaterial")]
        public string updateMaterial([FromBody] Material2 data)
        {
            try
            {
                string table = "rawmaterial";
                string sqlCmd = $"UPDATE {table} SET materialName='{data.materialName}',unit='{data.unit}',lowLevelAlertIndex='{data.lowLevelAlertIndex}',price={data.price} WHERE materialID='{data.materialID}';";
                sqlCmd = sqlCmd + $"UPDATE {table} SET stockStatus='LOW-STOCK' WHERE inStockQuantity<={data.lowLevelAlertIndex} AND materialID='{data.materialID}';";
                sqlCmd = sqlCmd + $"UPDATE {table} SET stockStatus='NORMAL' WHERE inStockQuantity>{data.lowLevelAlertIndex} AND materialID='{data.materialID}';";
                return dbo.BatchUpdate(sqlCmd).ToString();
            }
            catch (Exception ex)
            {
                return "0";
            }
        }
        [HttpGet("GetInBoundData")]
        public string getInBoundData()
        {
            try
            {

                string sql = @"
                            SELECT 
                                io.transferID AS TransferID,
                                io.transferType AS TransferType,
                                io.itemType AS ItemType,
                                io.itemID AS MaterialID,
                                rm.materialName AS MaterialName,
                                io.quantity AS Quantity,
                                io.price AS UnitPrice,
                                io.date AS CreateDate,
                                s.supplierID AS SupplierID,
                                s.supplierName AS SupplierName  -- 可选显示供应商名称
                            FROM 
                                inventoryinandout io
                            LEFT JOIN 
                                rawmaterial rm ON io.itemID = rm.materialID AND io.itemType = 'MATERIAL'
                            LEFT JOIN 
                                supplier s ON io.from = s.supplierID  -- 假设from字段存储的是供应商ID
                            WHERE 
                                io.inOrOut = 'INBOUND'
                                /* 可选条件 */
                                /* AND io.date BETWEEN @startDate AND @endDate */
                                /* AND io.itemID = @materialID */
                            ORDER BY 
                                io.date DESC";
                string jsonString = JsonConvert.SerializeObject(dbo.GetData(sql));
                return jsonString;
            }
            catch (Exception ex)
            {
                return "0";
            }

        }
        [HttpGet("GetOutBoundData")]
        public string getOutBoundData()
        {
            try
            {

                string sql = @"
                            SELECT 
                                io.transferID AS TransferID,
                                io.transferType AS TransferType,
                                io.itemType AS ItemType,
                                io.itemID AS MaterialID,
                                rm.materialName AS MaterialName,
                                io.quantity AS Quantity,
                                io.price AS UnitPrice,
                                io.date AS CreateDate,
                                io.to AS Destination
                            FROM 
                                inventoryinandout io
                            LEFT JOIN 
                                rawmaterial rm ON io.itemID = rm.materialID AND io.itemType = 'MATERIAL'
                    
                            WHERE 
                                io.inOrOut = 'OUTBOUND'
                                /* 可选条件 */
                                /* AND io.date BETWEEN @startDate AND @endDate */
                                /* AND io.itemID = @materialID */
                            ORDER BY 
                                io.date DESC";
                string jsonString = JsonConvert.SerializeObject(dbo.GetData(sql));
                return jsonString;
            }
            catch (Exception ex)
            {
                return "0";
            }

        }
        [HttpPost("AddDeliveryRequest")]
        public string addDeliveryOrder([FromBody] DeliveryProduct data)
        {
            {
                try
                {
                    string requestID = data.requestID;
                    string orderID = data.orderID;
                    string remarks = data.remarks;
                    //日期未写
                    string date = DateTime.Now.ToString("yyyy-MM-dd");
                    string columns = "(requestID,orderID,remarks,requestDate,priority)";
                    string sqlCmd = $"INSERT INTO deliveryRequest {columns} VALUES ('{requestID}','{orderID}','{remarks}','{date}','{data.priority}');";

                    return dbo.BatchUpdate(sqlCmd).ToString();
                }
                catch (Exception ex)
                {

                    return "0";
                }
            }

        }
        [HttpGet("GetPendingOrder")]
        public string getPendingOrder()
        {
            try
            {
                //string sql = $"SELECT * FROM placeorder WHERE orderStatus<>'Completed'";
                string sql = @"SELECT p.orderID, p.orderDate, p.customerID, p.orderStatus
                                FROM placedorder p
                                WHERE p.orderStatus != 'Completed'
                                  AND p.orderID NOT IN (SELECT orderID FROM deliveryrequest);";

                string jsonString = JsonConvert.SerializeObject(dbo.GetData(sql));
                return jsonString;

            }
            catch (Exception ex)
            {
                return "0";
            }

        }
        [HttpGet("GetDeliveryRequestData")]
        public string getDeliveryRequestData()
        {

            try
            {
                string sql = "SELECT dr.*,po.customerID,c.customerName,c.companyAddress,c.customerPhone FROM deliveryRequest dr JOIN placedorder po ON dr.orderID = po.orderID JOIN customer c ON po.customerID = c.customerID";


                string jsonString = JsonConvert.SerializeObject(dbo.GetData(sql));

                return jsonString;

            }
            catch (Exception ex)
            {
                return "0";

            }

        }
        [HttpPost("ProcessDeliveryRequest")]
        public string processDelivery([FromBody] ProcessDelivery data,string action)
        {
            try
            {
                string sqlCmd = "";
                if (action == "process")
                {
                    string table = "deliveryorder";
                    string columns = "(deliveryOrderID,requestID,courierID,trackingID)";
                     sqlCmd = $"INSERT INTO {table} {columns} VALUES ('{data.deliveryOrderID}','{data.requestID}','{data.courierID}','{data.trackingID}');";
                    sqlCmd += $"UPDATE deliveryRequest SET requestStatus='Completed';";                   
                }
                else if (action == "cancel")
                {
                    string table = "deliveryRequest";
                    sqlCmd = $"UPDATE {table} SET requestStatus='Cancelled' WHERE requestID='{data.requestID}';";                 
                }
                return dbo.BatchUpdate(sqlCmd).ToString();
            }
            catch (Exception ex)
            {
                return "0";
            }
        }
        [HttpGet("GenerateNotes")]
        public string generateNotes(string deliveryOrderID)
        {

            try
            {
                string id=deliveryOrderID.ToString();
                string sql = $@"
                    SELECT 
                        deo.deliveryOrderID,
                        o.orderID,
                        c.customerName,
                        cr.courierName,
                        deo.trackingID,
                        deo.createAt AS createDate,
                        c.customerPhone
                    FROM 
                        deliveryorder deo
                    JOIN 
                        deliveryrequest dr ON deo.requestID = dr.requestID
                    JOIN 
                        placedorder o ON dr.orderID = o.orderID
                    JOIN 
                        customer c ON o.customerID = c.customerID
                    JOIN 
                        courier cr ON deo.courierID = cr.courierID
                    WHERE deliveryOrderID='{id}'";
               
                string jsonString = JsonConvert.SerializeObject(dbo.GetData(sql));

                return jsonString;

            }
            catch (Exception ex)
            {
                return "0";

            }

        }
    }
}