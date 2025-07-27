-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- 主機： 127.0.0.1
-- 產生時間： 2025 年 07 月 09 日 17:33
-- 伺服器版本： 10.4.32-MariaDB
-- PHP 版本： 8.2.12
CREATE DATABASE IF NOT EXISTS ay2425class1agroup1;
USE ay2425class1agroup1;

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- 資料庫： `ay2425class1agroup1`
--

-- --------------------------------------------------------

--
-- 資料表結構 `courier`
--

CREATE TABLE `courier` (
  `courierID` char(7) NOT NULL,
  `courierName` varchar(50) NOT NULL,
  `courierPhone` char(8) DEFAULT NULL,
  `courierEmail` varchar(50) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- 傾印資料表的資料 `courier`
--

INSERT INTO `courier` (`courierID`, `courierName`, `courierPhone`, `courierEmail`) VALUES
('PM00001', 'Courier A', '12345678', 'courierA@example.com'),
('PM00002', 'Courier B', '12345678', 'courierB@example.com'),
('PM00003', 'Courier C', '98765432', 'courierC@example.com');

-- --------------------------------------------------------

--
-- 資料表結構 `customer`
--

CREATE TABLE `customer` (
  `customerID` char(6) NOT NULL,
  `customerName` varchar(20) NOT NULL,
  `customerPassword` varchar(255) NOT NULL,
  `companyAddress` varchar(100) DEFAULT NULL,
  `customerEmail` varchar(50) DEFAULT NULL,
  `customerPhone` char(11) DEFAULT NULL,
  `country` varchar(50) DEFAULT NULL,
  `receivePromotion` int(11) NOT NULL DEFAULT 1
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- 傾印資料表的資料 `customer`
--

INSERT INTO `customer` (`customerID`, `customerName`, `customerPassword`, `companyAddress`, `customerEmail`, `customerPhone`, `country`, `receivePromotion`) VALUES
('C00001', 'Alice Smith', 'ff8d9819fc0e12bf0d24892e45987e249a28dce836a85cad60e28eaaa8c6d976', '123 Elm St', 'alice@example.com', '12345678901', 'USA', 1),
('C00002', 'Bob Johnson', '5ff860bf1190596c7188ab851db691f0f3169c453936e9e1eba2f9a47f7a0018', '456 Oak St', 'bob@example.com', '12345678902', 'USA', 1),
('C00003', 'Charlie Brown', 'add7232b65bb559f896cbcfa9a600170a7ca381a0366789dcf59ad986bdf4a98', '789 Pine St', 'charlie@example.com', '12345678903', 'USA', 1),
('C00004', 'Diana Prince', 'e240bcaea43a9ddcd598126ccca52d9b5204d5c5541e21f1a6644db24dbb49fa', '321 Maple St', 'diana@example.com', '12345678904', 'USA', 1),
('C00005', 'Ethan Hunt', '2475966ba9b5151a3eeb8d0718b23697395dfe926d8ffee8924b90f0cc6b21bc', '654 Cedar St', 'ethan@example.com', '12345678905', 'USA', 1),
('C00006', 'Fiona Gallagher', 'e1f5492a4a9d6ffc0480496e6b11d4937e673db4d63a301d1737d9341f23e8e4', '987 Birch St', 'fiona@example.com', '12345678906', 'USA', 1),
('C00007', 'George Costanza', '47508cb4512f7b46aaeb34b4a514c63d63ec240bf28cbc4410addd4867c10066', '159 Spruce St', 'george@example.com', '12345678907', 'USA', 1),
('C00008', 'Hannah Baker', 'cb53b7a9b00c0558fce2bc9b436789e2c48c7e8ef05b389277519bcf53b4f0a7', '753 Fir St', 'hannah@example.com', '12345678908', 'USA', 1),
('C00009', 'Ian Malcolm', 'd01da62a9dce57c85ce77fe935317111adaa9f22063aa2d154bc9ac73971c05d', '852 Willow St', 'ian@example.com', '12345678909', 'USA', 1),
('C00010', 'Julia Roberts', 'a363bda8fb774751c61803c6c626f8dfd4ff01652558c2cce64a6fe905ef492e', '963 Chestnut St', 'julia@example.com', '12345678910', 'USA', 0),
('C00011', 'customer', 'b6c45863875e34487ca3c155ed145efe12a74581e27befec5aa661b8ee8ca6dd', 'Hello World Co.', 'customer@test.com', '22222224', 'HK', 1);

-- --------------------------------------------------------

--
-- 資料表結構 `customersystemaccessright`
--

CREATE TABLE `customersystemaccessright` (
  `customerID` char(6) NOT NULL,
  `systemFunctionID` char(7) NOT NULL,
  `systemAccessRight` int(11) DEFAULT 2
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- 傾印資料表的資料 `customersystemaccessright`
--

INSERT INTO `customersystemaccessright` (`customerID`, `systemFunctionID`, `systemAccessRight`) VALUES
('C00001', 'SF00001', 2),
('C00001', 'SF00002', 2),
('C00001', 'SF00101', 2),
('C00001', 'SF00102', 2),
('C00001', 'SF00103', 2),
('C00001', 'SF00104', 2),
('C00001', 'SF00105', 2),
('C00001', 'SF00106', 2),
('C00001', 'SF00107', 2),
('C00001', 'SF00108', 2),
('C00001', 'SF00201', 2),
('C00001', 'SF00202', 2),
('C00001', 'SF00203', 2),
('C00001', 'SF00204', 2),
('C00001', 'SF00205', 2),
('C00001', 'SF00206', 2),
('C00001', 'SF00207', 2),
('C00001', 'SF00208', 2),
('C00001', 'SF00209', 2),
('C00001', 'SF00210', 2),
('C00001', 'SF00301', 2),
('C00001', 'SF00302', 2),
('C00001', 'SF00401', 2),
('C00001', 'SF00402', 2),
('C00001', 'SF00403', 2),
('C00001', 'SF00404', 2),
('C00001', 'SF00405', 2),
('C00001', 'SF00406', 2),
('C00001', 'SF00407', 2),
('C00001', 'SF00408', 2),
('C00001', 'SF00501', 2),
('C00001', 'SF00502', 2),
('C00001', 'SF00601', 2),
('C00001', 'SF00602', 2),
('C00001', 'SF00603', 2),
('C00001', 'SF00701', 2),
('C00001', 'SF00702', 2),
('C00001', 'SF00703', 2),
('C00001', 'SF00704', 2),
('C00001', 'SF00801', 2),
('C00001', 'SF00802', 2),
('C00001', 'SF00803', 2),
('C00001', 'SF00804', 2),
('C00001', 'SF00901', 2),
('C00001', 'SF00902', 2),
('C00001', 'SF00903', 2),
('C00001', 'SF00904', 2),
('C00001', 'SF01001', 2),
('C00001', 'SF01002', 2),
('C00001', 'SF01101', 2),
('C00001', 'SF01201', 2),
('C00001', 'SF01202', 2),
('C00001', 'SF01203', 2),
('C00001', 'SF01301', 2),
('C00001', 'SF01302', 2),
('C00001', 'SF01303', 2),
('C00001', 'SF01304', 2),
('C00001', 'SF01305', 2),
('C00001', 'SF01306', 2),
('C00001', 'SF01307', 2),
('C00001', 'SF01401', 2),
('C00001', 'SF01402', 2),
('C00001', 'SF01403', 2),
('C00001', 'SF01404', 2),
('C00001', 'SF01405', 2),
('C00001', 'SF01501', 2),
('C00001', 'SF01502', 2),
('C00001', 'SF01503', 2),
('C00002', 'SF00001', 2),
('C00002', 'SF00002', 2),
('C00002', 'SF00101', 2),
('C00002', 'SF00102', 2),
('C00002', 'SF00103', 2),
('C00002', 'SF00104', 2),
('C00002', 'SF00105', 2),
('C00002', 'SF00106', 2),
('C00002', 'SF00107', 2),
('C00002', 'SF00108', 2),
('C00002', 'SF00201', 2),
('C00002', 'SF00202', 2),
('C00002', 'SF00203', 2),
('C00002', 'SF00204', 2),
('C00002', 'SF00205', 2),
('C00002', 'SF00206', 2),
('C00002', 'SF00207', 2),
('C00002', 'SF00208', 2),
('C00002', 'SF00209', 2),
('C00002', 'SF00210', 2),
('C00002', 'SF00301', 2),
('C00002', 'SF00302', 2),
('C00002', 'SF00401', 2),
('C00002', 'SF00402', 2),
('C00002', 'SF00403', 2),
('C00002', 'SF00404', 2),
('C00002', 'SF00405', 2),
('C00002', 'SF00406', 2),
('C00002', 'SF00407', 2),
('C00002', 'SF00408', 2),
('C00002', 'SF00501', 2),
('C00002', 'SF00502', 2),
('C00002', 'SF00601', 2),
('C00002', 'SF00602', 2),
('C00002', 'SF00603', 2),
('C00002', 'SF00701', 2),
('C00002', 'SF00702', 2),
('C00002', 'SF00703', 2),
('C00002', 'SF00704', 2),
('C00002', 'SF00801', 2),
('C00002', 'SF00802', 2),
('C00002', 'SF00803', 2),
('C00002', 'SF00804', 2),
('C00002', 'SF00901', 2),
('C00002', 'SF00902', 2),
('C00002', 'SF00903', 2),
('C00002', 'SF00904', 2),
('C00002', 'SF01001', 2),
('C00002', 'SF01002', 2),
('C00002', 'SF01101', 2),
('C00002', 'SF01201', 2),
('C00002', 'SF01202', 2),
('C00002', 'SF01203', 2),
('C00002', 'SF01301', 2),
('C00002', 'SF01302', 2),
('C00002', 'SF01303', 2),
('C00002', 'SF01304', 2),
('C00002', 'SF01305', 2),
('C00002', 'SF01306', 2),
('C00002', 'SF01307', 2),
('C00002', 'SF01401', 2),
('C00002', 'SF01402', 2),
('C00002', 'SF01403', 2),
('C00002', 'SF01404', 2),
('C00002', 'SF01405', 2),
('C00002', 'SF01501', 2),
('C00002', 'SF01502', 2),
('C00002', 'SF01503', 2),
('C00003', 'SF00001', 2),
('C00003', 'SF00002', 2),
('C00003', 'SF00101', 2),
('C00003', 'SF00102', 2),
('C00003', 'SF00103', 2),
('C00003', 'SF00104', 2),
('C00003', 'SF00105', 2),
('C00003', 'SF00106', 2),
('C00003', 'SF00107', 2),
('C00003', 'SF00108', 2),
('C00003', 'SF00201', 2),
('C00003', 'SF00202', 2),
('C00003', 'SF00203', 2),
('C00003', 'SF00204', 2),
('C00003', 'SF00205', 2),
('C00003', 'SF00206', 2),
('C00003', 'SF00207', 2),
('C00003', 'SF00208', 2),
('C00003', 'SF00209', 2),
('C00003', 'SF00210', 2),
('C00003', 'SF00301', 2),
('C00003', 'SF00302', 2),
('C00003', 'SF00401', 2),
('C00003', 'SF00402', 2),
('C00003', 'SF00403', 2),
('C00003', 'SF00404', 2),
('C00003', 'SF00405', 2),
('C00003', 'SF00406', 2),
('C00003', 'SF00407', 2),
('C00003', 'SF00408', 2),
('C00003', 'SF00501', 2),
('C00003', 'SF00502', 2),
('C00003', 'SF00601', 2),
('C00003', 'SF00602', 2),
('C00003', 'SF00603', 2),
('C00003', 'SF00701', 2),
('C00003', 'SF00702', 2),
('C00003', 'SF00703', 2),
('C00003', 'SF00704', 2),
('C00003', 'SF00801', 2),
('C00003', 'SF00802', 2),
('C00003', 'SF00803', 2),
('C00003', 'SF00804', 2),
('C00003', 'SF00901', 2),
('C00003', 'SF00902', 2),
('C00003', 'SF00903', 2),
('C00003', 'SF00904', 2),
('C00003', 'SF01001', 2),
('C00003', 'SF01002', 2),
('C00003', 'SF01101', 2),
('C00003', 'SF01201', 2),
('C00003', 'SF01202', 2),
('C00003', 'SF01203', 2),
('C00003', 'SF01301', 2),
('C00003', 'SF01302', 2),
('C00003', 'SF01303', 2),
('C00003', 'SF01304', 2),
('C00003', 'SF01305', 2),
('C00003', 'SF01306', 2),
('C00003', 'SF01307', 2),
('C00003', 'SF01401', 2),
('C00003', 'SF01402', 2),
('C00003', 'SF01403', 2),
('C00003', 'SF01404', 2),
('C00003', 'SF01405', 2),
('C00003', 'SF01501', 2),
('C00003', 'SF01502', 2),
('C00003', 'SF01503', 2),
('C00011', 'SF00001', 2),
('C00011', 'SF00002', 2),
('C00011', 'SF00201', 2),
('C00011', 'SF00202', 2),
('C00011', 'SF00203', 2),
('C00011', 'SF00204', 2),
('C00011', 'SF00205', 2),
('C00011', 'SF00206', 2),
('C00011', 'SF00207', 2),
('C00011', 'SF00208', 2),
('C00011', 'SF00209', 2),
('C00011', 'SF00210', 2),
('C00011', 'SF00801', 2),
('C00011', 'SF00802', 2),
('C00011', 'SF00803', 2),
('C00011', 'SF00804', 2),
('C00011', 'SF00901', 2),
('C00011', 'SF00902', 2),
('C00011', 'SF00903', 2),
('C00011', 'SF00904', 2),
('C00011', 'SF01101', 2);

-- --------------------------------------------------------

--
-- 資料表結構 `deliveryorder`
--

CREATE TABLE `deliveryorder` (
  `deliveryOrderID` char(7) NOT NULL,
  `deliveryType` varchar(8) DEFAULT 'External',
  `personInCharge` char(6) DEFAULT NULL,
  `trackingID` varchar(50) DEFAULT NULL,
  `courierID` char(7) DEFAULT NULL,
  `deliveryStatus` varchar(10) DEFAULT 'Delivering',
  `requestID` char(6) DEFAULT NULL,
  `createAt` date DEFAULT curdate()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- 傾印資料表的資料 `deliveryorder`
--

INSERT INTO `deliveryorder` (`deliveryOrderID`, `deliveryType`, `personInCharge`, `trackingID`, `courierID`, `deliveryStatus`, `requestID`, `createAt`) VALUES
('DO0001', 'Internal', 'E00001', 'T00001', 'PM00001', 'Delivering', NULL, '2025-06-26'),
('DO0002', 'External', 'E00002', 'T00002', 'PM00002', 'Delivering', NULL, '2025-06-26'),
('DO0003', 'External', 'E00003', 'T00003', 'PM00003', 'Delivered', NULL, '2025-06-26'),
('DO0004', 'External', '', 'T00004', 'PM00002', 'Delivering', 'DR0002', '2025-06-27');

-- --------------------------------------------------------

--
-- 資料表結構 `deliveryproduct`
--

CREATE TABLE `deliveryproduct` (
  `deliveryOrderID` char(7) NOT NULL,
  `orderID` char(7) NOT NULL,
  `remarks` varchar(300) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- 傾印資料表的資料 `deliveryproduct`
--

INSERT INTO `deliveryproduct` (`deliveryOrderID`, `orderID`, `remarks`) VALUES
('DO0002', 'O00002', 'Standard delivery'),
('DO0003', 'O00003', 'Express delivery');

-- --------------------------------------------------------

--
-- 資料表結構 `deliveryrawmaterial`
--

CREATE TABLE `deliveryrawmaterial` (
  `deliveryOrderID` char(7) NOT NULL,
  `materialID` char(6) NOT NULL,
  `quantity` int(11) NOT NULL,
  `remarks` varchar(300) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- 傾印資料表的資料 `deliveryrawmaterial`
--

INSERT INTO `deliveryrawmaterial` (`deliveryOrderID`, `materialID`, `quantity`, `remarks`) VALUES
('DO0001', 'M00001', 200, 'Urgent delivery'),
('DO0002', 'M00002', 100, 'Standard delivery'),
('DO0003', 'M00003', 50, 'Express delivery');

-- --------------------------------------------------------

--
-- 資料表結構 `deliveryrequest`
--

CREATE TABLE `deliveryrequest` (
  `requestID` char(6) NOT NULL,
  `orderID` char(6) NOT NULL,
  `requestDate` date DEFAULT NULL,
  `requester_id` char(6) DEFAULT NULL,
  `priority` enum('Low','Normal','High','Urgent') NOT NULL DEFAULT 'Normal',
  `requestStatus` varchar(10) DEFAULT NULL,
  `remarks` varchar(255) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- 傾印資料表的資料 `deliveryrequest`
--

INSERT INTO `deliveryrequest` (`requestID`, `orderID`, `requestDate`, `requester_id`, `priority`, `requestStatus`, `remarks`) VALUES
('DR0002', 'O00003', '2025-06-26', NULL, 'Normal', 'Completed', ''),
('DR0003', 'O00002', '2025-06-27', NULL, 'Normal', NULL, '');

-- --------------------------------------------------------

--
-- 資料表結構 `demonstrationvideo`
--

CREATE TABLE `demonstrationvideo` (
  `videoID` char(6) NOT NULL,
  `videoTitle` varchar(50) NOT NULL,
  `videoDescription` varchar(300) DEFAULT NULL,
  `departmentID` char(6) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- 傾印資料表的資料 `demonstrationvideo`
--

INSERT INTO `demonstrationvideo` (`videoID`, `videoTitle`, `videoDescription`, `departmentID`) VALUES
('V00001', 'System Overview', 'An overview of the system features and functionalities.', 'D00001'),
('V00002', 'User Guide', 'A comprehensive guide on how to use the system.', 'D00002'),
('V00003', 'Troubleshooting', 'Common issues and troubleshooting steps.', 'D00003'),
('V00004', 'New Features', 'Introduction to new features in the latest update.', 'D00004'),
('V00005', 'Best Practices', 'Best practices for using the system effectively.', 'D00005');

-- --------------------------------------------------------

--
-- 資料表結構 `department`
--

CREATE TABLE `department` (
  `deptID` char(6) NOT NULL,
  `deptName` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- 傾印資料表的資料 `department`
--

INSERT INTO `department` (`deptID`, `deptName`) VALUES
('D00001', 'Research and Development Department'),
('D00002', 'Sales & Marketing Department'),
('D00003', 'Production Department'),
('D00004', 'Supply Chain Department'),
('D00005', 'Customer Service Department'),
('D00006', 'Finance Department'),
('D00007', 'IT Department');

-- --------------------------------------------------------

--
-- 資料表結構 `file`
--

CREATE TABLE `file` (
  `fileID` char(6) NOT NULL,
  `fileName` varchar(50) NOT NULL,
  `filePath` varchar(250) NOT NULL,
  `fileType` varchar(50) NOT NULL,
  `recordDate` date NOT NULL,
  `recordPerson` char(6) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- 傾印資料表的資料 `file`
--

INSERT INTO `file` (`fileID`, `fileName`, `filePath`, `fileType`, `recordDate`, `recordPerson`) VALUES
('F00001', 'F00001_1.png', 'F00001_1.png', '.png', '2025-07-09', 'E00008'),
('F00002', 'F00002_Prod_manuals.docx', 'F00002_Prod_manuals.docx', '.docx', '2025-07-09', 'E00001');

-- --------------------------------------------------------

--
-- 資料表結構 `inventoryinandout`
--

CREATE TABLE `inventoryinandout` (
  `transferID` char(6) NOT NULL,
  `transferType` enum('RESTOCK','EXTERNAL_TRANSFER','MATERIAL_DEMAND','INTERNAL_TRANSFER','RETURN','ADJUSTMENT') NOT NULL,
  `inOrOut` enum('INBOUND','OUTBOUND') NOT NULL,
  `itemType` enum('PRODUCT','MATERIAL') NOT NULL,
  `itemID` char(6) NOT NULL,
  `quantity` int(11) NOT NULL,
  `price` decimal(10,2) DEFAULT NULL,
  `date` date NOT NULL DEFAULT curdate(),
  `from` varchar(100) DEFAULT NULL,
  `to` varchar(100) DEFAULT 'Production DPT',
  `remarks` text DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- 傾印資料表的資料 `inventoryinandout`
--

INSERT INTO `inventoryinandout` (`transferID`, `transferType`, `inOrOut`, `itemType`, `itemID`, `quantity`, `price`, `date`, `from`, `to`, `remarks`) VALUES
('MD0001', 'MATERIAL_DEMAND', 'OUTBOUND', 'MATERIAL', 'M00001', 50, NULL, '2025-06-25', NULL, 'Production DPT', NULL),
('MD0003', 'MATERIAL_DEMAND', 'OUTBOUND', 'MATERIAL', 'M00005', 30, NULL, '2025-06-26', NULL, 'Production DPT', NULL),
('MD0004', 'MATERIAL_DEMAND', 'OUTBOUND', 'MATERIAL', 'M00007', 20, NULL, '2025-06-25', NULL, 'Production DPT', NULL),
('MD0005', 'MATERIAL_DEMAND', 'OUTBOUND', 'MATERIAL', 'M00009', 100, NULL, '2025-06-25', NULL, 'Production DPT', NULL),
('MD0006', 'MATERIAL_DEMAND', 'OUTBOUND', 'MATERIAL', 'M00006', 30, NULL, '2025-06-26', NULL, 'Production DPT', NULL),
('MD0008', 'MATERIAL_DEMAND', 'OUTBOUND', 'MATERIAL', 'M00001', 100, NULL, '2025-06-25', NULL, 'Production DPT', NULL),
('MD0009', 'MATERIAL_DEMAND', 'OUTBOUND', 'MATERIAL', 'M00005', 50, NULL, '2025-06-23', NULL, 'Production DPT', NULL),
('MD0010', 'MATERIAL_DEMAND', 'OUTBOUND', 'MATERIAL', 'M00002', 100, NULL, '2025-06-24', NULL, 'Production DPT', NULL),
('MD0011', 'MATERIAL_DEMAND', 'OUTBOUND', 'MATERIAL', 'M00003', 20, NULL, '2025-06-25', NULL, 'Production DPT', NULL),
('MD0012', 'MATERIAL_DEMAND', 'OUTBOUND', 'MATERIAL', 'M00010', 50, NULL, '2025-06-25', NULL, 'Production DPT', NULL),
('R00001', 'RESTOCK', 'INBOUND', 'MATERIAL', 'M00001', 200, NULL, '2025-06-25', NULL, 'Production DPT', NULL),
('R00004', 'RESTOCK', 'INBOUND', 'MATERIAL', 'M00004', 20, NULL, '2025-06-25', NULL, 'Production DPT', NULL),
('R00005', 'RESTOCK', 'INBOUND', 'MATERIAL', 'M00005', 15, NULL, '2025-06-23', NULL, 'Production DPT', NULL),
('R00006', 'RESTOCK', 'INBOUND', 'MATERIAL', 'M00007', 100, NULL, '2025-06-24', NULL, 'Production DPT', NULL),
('R00009', 'RESTOCK', 'INBOUND', 'MATERIAL', 'M00004', 20, NULL, '2025-06-23', NULL, 'Production DPT', NULL),
('R00011', 'RESTOCK', 'INBOUND', 'MATERIAL', 'M00010', 100, NULL, '2025-06-24', NULL, 'Production DPT', NULL),
('R00012', 'RESTOCK', 'INBOUND', 'MATERIAL', 'M00006', 300, NULL, '2025-06-24', NULL, 'Production DPT', NULL),
('R00013', 'RESTOCK', 'INBOUND', 'MATERIAL', 'M00009', 100, NULL, '2025-06-24', NULL, 'Production DPT', NULL),
('R00014', 'RESTOCK', 'INBOUND', 'MATERIAL', 'M00006', 35, NULL, '2025-06-24', NULL, 'Production DPT', NULL),
('R00017', 'RESTOCK', 'INBOUND', 'MATERIAL', 'M00005', 2000, NULL, '2025-06-25', NULL, 'Production DPT', NULL),
('R00019', 'RESTOCK', 'INBOUND', 'MATERIAL', 'M00007', 10, NULL, '2025-06-25', NULL, 'Production DPT', NULL),
('R00020', 'RESTOCK', 'INBOUND', 'MATERIAL', 'M00004', 50, NULL, '2025-06-25', NULL, 'Production DPT', NULL),
('R00021', 'RESTOCK', 'INBOUND', 'MATERIAL', 'M00006', 100, NULL, '2025-06-26', 'S00005', 'Production DPT', NULL),
('R00022', 'RESTOCK', 'INBOUND', 'MATERIAL', 'M00002', 1000, NULL, '2025-06-25', NULL, 'Production DPT', NULL),
('R00023', 'RESTOCK', 'INBOUND', 'MATERIAL', 'M00006', 100, NULL, '2025-06-26', 'S00003', 'Production DPT', NULL);

-- --------------------------------------------------------

--
-- 資料表結構 `itsupportrequest`
--

CREATE TABLE `itsupportrequest` (
  `itRequestID` char(7) NOT NULL,
  `staffID` char(6) NOT NULL,
  `itRequestType` varchar(10) NOT NULL,
  `itRequestDescription` varchar(300) DEFAULT NULL,
  `itRequestStatus` varchar(10) NOT NULL,
  `staffAssigned` char(6) DEFAULT NULL,
  `itRequest_reasonOfStaffReassign` varchar(100) NOT NULL,
  `itRequest_lastUpdate` date DEFAULT NULL,
  `itRequest_archive` varchar(3) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- 傾印資料表的資料 `itsupportrequest`
--

INSERT INTO `itsupportrequest` (`itRequestID`, `staffID`, `itRequestType`, `itRequestDescription`, `itRequestStatus`, `staffAssigned`, `itRequest_reasonOfStaffReassign`, `itRequest_lastUpdate`, `itRequest_archive`) VALUES
('SR00001', 'E00010', 'Login', 'Unable to login to the system.', 'Open', NULL, 'N/A', '2025-05-15', 'No'),
('SR00002', 'E00010', 'Bug', 'System crashes when submitting a form.', 'InProgress', 'E00010', 'Assigned to IT support', '2025-05-15', 'No'),
('SR00003', 'E00010', 'Request', 'Request for password reset.', 'Closed', 'E00010', 'Handled by customer service', '2025-05-14', 'No'),
('SR00004', 'E00010', 'Access', 'Need access to new module.', 'Open', NULL, 'N/A', NULL, 'No'),
('SR00005', 'E00010', 'Other', 'General inquiry about system usage.', 'Closed', 'E00010', 'Reassigned due to workload', '2025-05-10', 'Yes');

-- --------------------------------------------------------

--
-- 資料表結構 `itsystem`
--

CREATE TABLE `itsystem` (
  `systemID` char(7) NOT NULL,
  `systemName` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- 傾印資料表的資料 `itsystem`
--

INSERT INTO `itsystem` (`systemID`, `systemName`) VALUES
('SI00000', 'General System'),
('SI00001', 'Project Management System'),
('SI00002', 'Product Specification System'),
('SI00003', 'Order Management System'),
('SI00004', 'Production Monitoring System'),
('SI00005', 'Raw Material Management System'),
('SI00006', 'Inventory Management System'),
('SI00007', 'Delivery System'),
('SI00008', 'Supplier Control System'),
('SI00009', 'Customer Feedback System'),
('SI00010', 'Product Refund System'),
('SI00011', 'Finance Analysis Tool'),
('SI00012', 'Payment Gateway'),
('SI00013', 'User Management System'),
('SI00014', 'Support Request System'),
('SI00015', 'System Learning Platform'),
('SI00016', 'Software Feedback Collection System');

-- --------------------------------------------------------

--
-- 資料表結構 `materialdemand`
--

CREATE TABLE `materialdemand` (
  `demandID` char(6) NOT NULL,
  `receiver` varchar(100) NOT NULL DEFAULT 'production DPT',
  `materialID` char(6) NOT NULL,
  `quantity` int(11) NOT NULL CHECK (`quantity` > 0),
  `expectedDate` date DEFAULT NULL,
  `status` enum('PENDING','ISSUED','COMPLETED','CANCELLED') NOT NULL DEFAULT 'PENDING',
  `createdAt` date DEFAULT curdate(),
  `updatedAt` date DEFAULT curdate()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- 傾印資料表的資料 `materialdemand`
--

INSERT INTO `materialdemand` (`demandID`, `receiver`, `materialID`, `quantity`, `expectedDate`, `status`, `createdAt`, `updatedAt`) VALUES
('MD0001', 'production DPT', 'M00001', 50, '2025-06-27', 'COMPLETED', '2025-06-17', '2025-06-25'),
('MD0002', 'Production DPT', 'M00003', 20, '2025-06-18', 'CANCELLED', '2025-06-18', '2025-06-25'),
('MD0003', 'Production DPT', 'M00005', 30, '2025-06-18', 'COMPLETED', '2025-06-18', '2025-06-26'),
('MD0003', 'Production DPT', 'M00008', 100, '2025-06-18', 'PENDING', '2025-06-18', '2025-06-18'),
('MD0004', 'Production DPT', 'M00007', 20, '2025-06-18', 'COMPLETED', '2025-06-18', '2025-06-25'),
('MD0004', 'Production DPT', 'M00009', 50, '2025-06-18', 'PENDING', '2025-06-18', '2025-06-18'),
('MD0005', 'Production DPT', 'M00002', 100, '2025-06-18', 'COMPLETED', '2025-06-18', '2025-06-25'),
('MD0005', 'Production DPT', 'M00009', 100, '2025-06-18', 'COMPLETED', '2025-06-18', '2025-06-25'),
('MD0006', 'Production DPT', 'M00006', 30, '2025-06-18', 'COMPLETED', '2025-06-18', '2025-06-26'),
('MD0006', 'Production DPT', 'M00008', 50, '2025-06-18', 'CANCELLED', '2025-06-18', '2025-06-25'),
('MD0007', 'Production DPT', 'M00005', 30, '2025-06-18', 'CANCELLED', '2025-06-18', '2025-06-25'),
('MD0008', 'Production DPT', 'M00001', 100, '2025-06-18', 'COMPLETED', '2025-06-18', '2025-06-25'),
('MD0009', 'Production DPT', 'M00005', 50, '2025-06-18', 'COMPLETED', '2025-06-18', '2025-06-23'),
('MD0010', 'Production DPT', 'M00002', 100, '2025-06-18', 'CANCELLED', '2025-06-18', '2025-06-25'),
('MD0011', 'Production DPT', 'M00003', 20, '2025-06-19', 'COMPLETED', '2025-06-19', '2025-06-25'),
('MD0011', 'Production DPT', 'M00005', 50, '2025-06-19', 'CANCELLED', '2025-06-19', '2025-06-25'),
('MD0012', 'Production DPT', 'M00005', 30, '2025-06-19', 'PENDING', '2025-06-19', '2025-06-19'),
('MD0012', 'Production DPT', 'M00010', 50, '2025-06-19', 'COMPLETED', '2025-06-19', '2025-06-25'),
('MD0013', 'Production DPT', 'M00008', 100, '2025-06-26', 'PENDING', '2025-06-26', '2025-06-26'),
('MD0013', 'Production DPT', 'M00010', 200, '2025-06-26', 'PENDING', '2025-06-26', '2025-06-26');

-- --------------------------------------------------------

--
-- 資料表結構 `orderproduct`
--

CREATE TABLE `orderproduct` (
  `orderID` char(6) NOT NULL,
  `productID` char(6) NOT NULL,
  `unitPrice` decimal(10,2) NOT NULL,
  `quantity` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- 傾印資料表的資料 `orderproduct`
--

INSERT INTO `orderproduct` (`orderID`, `productID`, `unitPrice`, `quantity`) VALUES
('O00001', 'P00001', 50.00, 10),
('O00001', 'P00002', 100.00, 5),
('O00002', 'P00003', 25.00, 20),
('O00002', 'P00004', 30.00, 15),
('O00003', 'P00005', 75.00, 8),
('O00003', 'P00006', 60.00, 12),
('O00004', 'P00001', 250.00, 15),
('O00005', 'P00001', 250.00, 20),
('O00006', 'P00001', 45.00, 30),
('O00007', 'P00001', 200.00, 20),
('O00008', 'P00003', 20.00, 10);

-- --------------------------------------------------------

--
-- 資料表結構 `payment`
--

CREATE TABLE `payment` (
  `paymentID` char(8) NOT NULL,
  `orderID` char(6) NOT NULL,
  `paymentDate` date NOT NULL,
  `paymentAmount` decimal(10,2) NOT NULL,
  `paymentDescription` varchar(255) DEFAULT NULL,
  `paymentMethodID` char(9) NOT NULL,
  `paymentStatus` varchar(8) NOT NULL,
  `approvalCode` varchar(100) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- 傾印資料表的資料 `payment`
--

INSERT INTO `payment` (`paymentID`, `orderID`, `paymentDate`, `paymentAmount`, `paymentDescription`, `paymentMethodID`, `paymentStatus`, `approvalCode`) VALUES
('PAY00001', 'O00002', '2025-04-21', 2000.00, 'Payment for Order O00002', 'PAYM00002', 'Error', 'A00001'),
('PAY00002', 'O00002', '2025-05-21', 2000.00, 'Payment for Order O00002', 'PAYM00002', 'Error', 'A00002'),
('PAY00003', 'O00003', '2025-05-22', 1500.00, 'Payment for Order O00003', 'PAYM00003', 'Error', 'A00003');

-- --------------------------------------------------------

--
-- 資料表結構 `paymentdetails`
--

CREATE TABLE `paymentdetails` (
  `customerID` char(6) NOT NULL,
  `paymentMethodID` char(9) NOT NULL,
  `accountName` varchar(255) NOT NULL,
  `accountNumber` varchar(30) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- 傾印資料表的資料 `paymentdetails`
--

INSERT INTO `paymentdetails` (`customerID`, `paymentMethodID`, `accountName`, `accountNumber`) VALUES
('C00001', 'PAYM00001', 'John Doe', '123456789'),
('C00002', 'PAYM00002', 'Jane Smith', '987654321'),
('C00003', 'PAYM00003', 'Alice Johnson', '456789123');

-- --------------------------------------------------------

--
-- 資料表結構 `paymentmethod`
--

CREATE TABLE `paymentmethod` (
  `paymentMethodID` char(9) NOT NULL,
  `paymentMethodName` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- 傾印資料表的資料 `paymentmethod`
--

INSERT INTO `paymentmethod` (`paymentMethodID`, `paymentMethodName`) VALUES
('PAYM00001', 'Credit Card'),
('PAYM00002', 'Bank Transfer'),
('PAYM00003', 'Cash'),
('PAYM00004', 'PayPal'),
('PAYM00005', 'Cheque');

-- --------------------------------------------------------

--
-- 資料表結構 `placedorder`
--

CREATE TABLE `placedorder` (
  `orderID` char(6) NOT NULL,
  `quotationID` char(6) NOT NULL,
  `orderDate` date NOT NULL,
  `invoiceDate` date DEFAULT NULL,
  `customerID` char(6) NOT NULL,
  `paidAmount` decimal(10,2) DEFAULT NULL,
  `orderStatus` varchar(18) NOT NULL,
  `remarks` varchar(300) DEFAULT NULL,
  `productionStatus` varchar(8) DEFAULT NULL,
  `productionStartDate` date DEFAULT NULL,
  `productionExpEndDate` date DEFAULT NULL,
  `productionEndDate` date DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- 傾印資料表的資料 `placedorder`
--

INSERT INTO `placedorder` (`orderID`, `quotationID`, `orderDate`, `invoiceDate`, `customerID`, `paidAmount`, `orderStatus`, `remarks`, `productionStatus`, `productionStartDate`, `productionExpEndDate`, `productionEndDate`) VALUES
('O00001', 'Q00001', '2025-05-15', '2025-05-20', 'C00001', 1000.00, 'Created', 'First order', 'Finished', '2025-05-01', '2025-07-01', '2025-07-01'),
('O00002', 'Q00002', '2025-05-16', '2025-05-21', 'C00002', 2000.00, 'SentToFinance', 'Second order', 'Finished', '2025-05-02', '2025-06-01', NULL),
('O00003', 'Q00003', '2025-05-17', '2025-05-22', 'C00003', 1500.00, 'Deposited', 'Third order', 'Finished', '2025-05-03', '2025-06-02', NULL),
('O00004', 'Q00012', '2025-07-09', NULL, 'C00011', NULL, 'Deposited', NULL, NULL, NULL, NULL, NULL),
('O00005', 'Q00013', '2025-07-09', NULL, 'C00011', NULL, 'Completed', NULL, NULL, NULL, NULL, NULL),
('O00006', 'Q00014', '2025-07-09', NULL, 'C00011', NULL, 'Created', NULL, NULL, NULL, NULL, NULL),
('O00007', 'Q00015', '2025-07-09', NULL, 'C00011', NULL, 'SentToFinance', NULL, NULL, NULL, NULL, NULL),
('O00008', 'Q00016', '2025-07-09', NULL, 'C00011', 200.00, 'Completed', NULL, 'finished', '2025-07-02', '2025-07-10', '2025-07-09');

-- --------------------------------------------------------

--
-- 資料表結構 `product`
--

CREATE TABLE `product` (
  `productID` char(6) NOT NULL,
  `parentProductID` char(6) DEFAULT NULL,
  `productName` varchar(50) NOT NULL,
  `productType` varchar(8) NOT NULL,
  `productCategory` varchar(11) NOT NULL,
  `productVersion` varchar(3) NOT NULL,
  `productStatus` varchar(16) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- 傾印資料表的資料 `product`
--

INSERT INTO `product` (`productID`, `parentProductID`, `productName`, `productType`, `productCategory`, `productVersion`, `productStatus`) VALUES
('P00001', NULL, 'Toy Car', 'Internal', 'Vehicle', '1.0', 'Approved'),
('P00002', 'P00001', 'Remote Control Car', 'External', 'Vehicle', '1.1', 'Finished'),
('P00003', NULL, 'Building Blocks', 'Internal', 'Educational', '2.0', 'Approved'),
('P00004', NULL, 'Doll House', 'External', 'Figures', '1.0', 'Work-in-progress'),
('P00005', 'P00004', 'Doll House Furniture', 'External', 'Figures', '1.0', 'Pending approval'),
('P00006', NULL, 'Musical Toy', 'Internal', 'Musical', '1.0', 'Approved'),
('P00007', NULL, 'Puzzle Game', 'Internal', 'Game', '1.0', 'Finished'),
('P00008', NULL, 'Children’s Book', 'External', 'Educational', '1.0', 'Terminated'),
('P00009', NULL, 'Action Figure', 'Internal', 'Figures', '1.0', 'ToBeDeleted'),
('P00010', 'P00003', 'Advanced Building Blocks', 'External', 'Educational', '2.1', 'Approved');

-- --------------------------------------------------------

--
-- 資料表結構 `productattribute`
--

CREATE TABLE `productattribute` (
  `attributeID` char(6) NOT NULL,
  `attributeName` varchar(50) NOT NULL,
  `dataType` varchar(8) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- 傾印資料表的資料 `productattribute`
--

INSERT INTO `productattribute` (`attributeID`, `attributeName`, `dataType`) VALUES
('A00001', 'Product Description', 'String'),
('A00002', 'Product Image', 'String'),
('A00003', 'Product Price', 'Decimal'),
('A00004', 'Minimum Order Qty', 'Integer'),
('A00005', 'Product Name', 'String'),
('A00006', 'Dimension (Length)', 'Decimal'),
('A00007', 'Dimension (Width)', 'Decimal'),
('A00008', 'Dimension (Height)', 'Decimal'),
('A00009', 'Age Range', 'String'),
('A00010', 'Product Features', 'String'),
('A00011', 'Play Features', 'String'),
('A00012', 'Color Options', 'String'),
('A00013', 'Language Options', 'String'),
('A00014', 'Battery Required', 'String'),
('A00015', 'Safety Warnings', 'String'),
('A00016', 'Design Prototype', 'String'),
('A00017', 'Production Manuals', 'String'),
('A00018', 'Performance Criteria', 'String'),
('A00019', 'Quality Standards', 'String'),
('A00020', 'Testing Procedures', 'String'),
('A00021', 'Compliance Checklist', 'String'),
('A00022', 'First Compliance Report', 'String'),
('A00023', 'Product Label', 'String'),
('A00024', 'Storage Guidelines', 'String'),
('A00025', 'Dimension (Weight)', 'Decimal');

-- --------------------------------------------------------

--
-- 資料表結構 `productattributeversion`
--

CREATE TABLE `productattributeversion` (
  `versionID` char(7) NOT NULL,
  `productID` char(6) DEFAULT NULL,
  `attributeID` char(6) DEFAULT NULL,
  `attributeValue` varchar(500) DEFAULT NULL,
  `fileID` char(6) DEFAULT NULL,
  `recordDate` date NOT NULL,
  `recordPerson` char(6) DEFAULT NULL,
  `versionStatus` varchar(9) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- 傾印資料表的資料 `productattributeversion`
--

INSERT INTO `productattributeversion` (`versionID`, `productID`, `attributeID`, `attributeValue`, `fileID`, `recordDate`, `recordPerson`, `versionStatus`) VALUES
('VA00001', 'P00001', 'A00001', 'Toy Car', NULL, '2025-06-28', 'E00001', 'Approved'),
('VA00002', 'P00002', 'A00001', 'Remote Control Car', NULL, '2025-06-28', 'E00001', 'Approved'),
('VA00003', 'P00003', 'A00001', 'Building Blocks', NULL, '2025-06-28', 'E00001', 'Approved'),
('VA00004', 'P00004', 'A00001', 'Doll House', NULL, '2025-06-28', 'E00001', 'Approved'),
('VA00005', 'P00005', 'A00001', 'Doll House Furniture', NULL, '2025-06-28', 'E00001', 'Approved'),
('VA00006', 'P00006', 'A00001', 'Musical Toy', NULL, '2025-06-28', 'E00001', 'Approved'),
('VA00007', 'P00007', 'A00001', 'Puzzle Game', NULL, '2025-06-28', 'E00001', 'Approved'),
('VA00008', 'P00008', 'A00001', 'Children Book', NULL, '2025-06-28', 'E00001', 'Approved'),
('VA00009', 'P00009', 'A00001', 'Action Figure', NULL, '2025-06-28', 'E00001', 'Approved'),
('VA00010', 'P00010', 'A00001', 'Advanced Building Blocks', NULL, '2025-06-28', 'E00001', 'Approved'),
('VA00011', 'P00007', 'A00002', NULL, 'F00001', '2025-07-09', 'E00001', 'Approved'),
('VA00012', 'P00007', 'A00017', NULL, 'F00002', '2025-07-09', 'E00001', 'Approved');

-- --------------------------------------------------------

--
-- 資料表結構 `productdelete`
--

CREATE TABLE `productdelete` (
  `approvalID` char(7) NOT NULL,
  `productID` char(6) NOT NULL,
  `staffID` char(6) NOT NULL,
  `approvalDate` date NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- 資料表結構 `productmaterialversion`
--

CREATE TABLE `productmaterialversion` (
  `versionID` char(7) NOT NULL,
  `productID` char(6) DEFAULT NULL,
  `materialID` char(6) DEFAULT NULL,
  `quantity` decimal(10,2) NOT NULL,
  `recordDate` date NOT NULL,
  `recordPerson` char(6) DEFAULT NULL,
  `versionStatus` varchar(9) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- 傾印資料表的資料 `productmaterialversion`
--

INSERT INTO `productmaterialversion` (`versionID`, `productID`, `materialID`, `quantity`, `recordDate`, `recordPerson`, `versionStatus`) VALUES
('VM00001', 'P00001', 'M00001', 13.00, '2025-06-28', 'E00001', 'Approved'),
('VM00002', 'P00001', 'M00002', 2.00, '2025-06-28', 'E00001', 'Approved'),
('VM00003', 'P00001', 'M00003', 2.00, '2025-06-28', 'E00001', 'Approved'),
('VM00004', 'P00001', 'M00003', 2.10, '2025-06-28', 'E00001', 'Submitted'),
('VM00005', 'P00001', 'M00004', 2.00, '2025-06-28', 'E00001', 'Deleted'),
('VM00006', 'P00001', 'M00004', 1.00, '2025-06-28', 'E00001', 'Submitted'),
('VM00008', 'P00002', 'M00001', 1.00, '2025-06-28', 'E00001', 'Submitted'),
('VM00009', 'P00003', 'M00001', 1.00, '2025-06-28', 'E00001', 'Submitted'),
('VM00010', 'P00005', 'M00001', 1.00, '2025-06-28', 'E00001', 'Submitted'),
('VM00012', 'P00006', 'M00001', 1.00, '2025-06-28', 'E00001', 'Submitted'),
('VM00013', 'P00004', 'M00001', 1.00, '2025-06-28', 'E00001', 'Submitted'),
('VM00014', 'P00002', 'M00001', 2.00, '2025-06-28', 'E00001', 'Approved'),
('VM00015', 'P00003', 'M00001', 2.00, '2025-06-28', 'E00001', 'Approved'),
('VM00016', 'P00004', 'M00001', 2.00, '2025-06-28', 'E00001', 'Approved'),
('VM00017', 'P00005', 'M00001', 2.00, '2025-06-28', 'E00001', 'Approved'),
('VM00018', 'P00006', 'M00001', 2.00, '2025-06-28', 'E00001', 'Approved'),
('VM00019', 'P00010', 'M00002', 13.00, '2025-07-09', 'E00008', 'Submitted');

-- --------------------------------------------------------

--
-- 資料表結構 `productteam`
--

CREATE TABLE `productteam` (
  `productID` char(6) NOT NULL,
  `role` varchar(17) NOT NULL,
  `personID` char(6) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- 傾印資料表的資料 `productteam`
--

INSERT INTO `productteam` (`productID`, `role`, `personID`) VALUES
('P00001', 'ProductLeader', 'E00001'),
('P00002', 'ProductLeader', 'E00001'),
('P00003', 'ProductLeader', 'E00001'),
('P00004', 'ProductLeader', 'E00001'),
('P00005', 'ProductLeader', 'E00001'),
('P00006', 'ProductLeader', 'E00001'),
('P00007', 'ProductLeader', 'E00001'),
('P00008', 'ProductLeader', 'E00001'),
('P00009', 'ProductLeader', 'E00001'),
('P00010', 'ProductLeader', 'E00001');

-- --------------------------------------------------------

--
-- 資料表結構 `project`
--

CREATE TABLE `project` (
  `projectID` char(8) NOT NULL,
  `projectName` varchar(50) NOT NULL,
  `projectType` char(8) NOT NULL,
  `projectStatus` varchar(16) NOT NULL,
  `projectPriority` varchar(6) NOT NULL,
  `projectStartDate` date NOT NULL,
  `projectEndDate` date NOT NULL,
  `projectBudget` int(11) NOT NULL,
  `projectDescription` varchar(400) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- 傾印資料表的資料 `project`
--

INSERT INTO `project` (`projectID`, `projectName`, `projectType`, `projectStatus`, `projectPriority`, `projectStartDate`, `projectEndDate`, `projectBudget`, `projectDescription`) VALUES
('PRO00001', 'Project A', 'Internal', 'Pending approval', 'High', '2023-01-01', '2023-12-31', 100000, 'Description of Project A'),
('PRO00002', 'Project B', 'External', 'Approved', 'Normal', '2023-02-01', '2024-01-31', 200000, 'Description of Project B'),
('PRO00003', 'Project C', 'Internal', 'Work-in-progress', 'Low', '2023-03-01', '2024-02-29', 150000, 'Description of Project C');

-- --------------------------------------------------------

--
-- 資料表結構 `projecttask`
--

CREATE TABLE `projecttask` (
  `projectID` char(8) NOT NULL,
  `taskID` char(10) NOT NULL,
  `departmentID` char(6) NOT NULL,
  `taskStatus` varchar(8) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- 傾印資料表的資料 `projecttask`
--

INSERT INTO `projecttask` (`projectID`, `taskID`, `departmentID`, `taskStatus`) VALUES
('PRO00001', 'T000000001', 'D00001', 'NotStart'),
('PRO00001', 'T000000002', 'D00002', 'Started'),
('PRO00002', 'TT00000003', 'D00003', 'Finished'),
('PRO00003', 'TT00000004', 'D00001', 'Finished'),
('PRO00003', 'TT00000005', 'D00002', 'Finished');

-- --------------------------------------------------------

--
-- 資料表結構 `projectteam`
--

CREATE TABLE `projectteam` (
  `projectID` char(8) NOT NULL,
  `staffID` char(6) NOT NULL,
  `role` varchar(13) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- 傾印資料表的資料 `projectteam`
--

INSERT INTO `projectteam` (`projectID`, `staffID`, `role`) VALUES
('PRO00001', 'E00001', 'ProjectLeader'),
('PRO00001', 'E00002', 'TeamLeader'),
('PRO00002', 'E00003', 'Staff'),
('PRO00003', 'E00004', 'ProjectLeader'),
('PRO00003', 'E00005', 'Staff');

-- --------------------------------------------------------

--
-- 資料表結構 `quotation`
--

CREATE TABLE `quotation` (
  `quotationID` char(6) NOT NULL,
  `quotationDate` date NOT NULL,
  `customerID` char(6) NOT NULL,
  `deposit` decimal(10,2) DEFAULT NULL,
  `paymentTerm` varchar(300) DEFAULT NULL,
  `remarks` varchar(300) DEFAULT NULL,
  `quotationStatus` varchar(9) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- 傾印資料表的資料 `quotation`
--

INSERT INTO `quotation` (`quotationID`, `quotationDate`, `customerID`, `deposit`, `paymentTerm`, `remarks`, `quotationStatus`) VALUES
('Q00001', '2025-05-15', 'C00001', 1000.00, '30 days', 'First quotation', 'Deleted'),
('Q00002', '2025-05-16', 'C00002', 2000.00, '60 days', 'Second quotation', 'Finalized'),
('Q00003', '2025-07-09', 'C00003', 500.00, '60 days', 'Third quotation', 'Edited'),
('Q00004', '2025-07-09', 'C00011', 50.00, '30 days', 'this to be deleted', 'Deleted'),
('Q00005', '2025-07-09', 'C00011', 1000.00, '30 days', 'this to be converted to order', 'Created'),
('Q00006', '2025-07-09', 'C00011', 5.00, '30 days', 'this to be deleted', 'Created'),
('Q00007', '2025-07-09', 'C00011', 50.00, '30 days', '', 'Deleted'),
('Q00008', '2025-07-09', 'C00001', 500.00, '30 days', 'this to be converted to order and then delete order', 'Created'),
('Q00009', '2025-07-09', 'C00001', 200.00, '30 days', 'this to be converted to order and then send to finance', 'Created'),
('Q00010', '2025-07-09', 'C00001', 5.00, '30 days', 'this to be deleted by customer', 'Deleted'),
('Q00011', '2025-07-09', 'C00011', 50.00, '30 days', 'this to be deleted by customer', 'Created'),
('Q00012', '2025-07-09', 'C00011', 1500.00, '30 days', '', 'Finalized'),
('Q00013', '2025-07-09', 'C00011', 2500.00, '30 days', '', 'Finalized'),
('Q00014', '2025-07-09', 'C00011', 750.00, '30 days', '', 'Finalized'),
('Q00015', '2025-07-09', 'C00011', 2000.00, '30 days', '', 'Finalized'),
('Q00016', '2025-07-09', 'C00011', 50.00, '30 days', '', 'Finalized');

-- --------------------------------------------------------

--
-- 資料表結構 `quotationproduct`
--

CREATE TABLE `quotationproduct` (
  `quotationID` char(6) NOT NULL,
  `productID` char(6) NOT NULL,
  `unitPrice` decimal(10,2) NOT NULL,
  `quantity` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- 傾印資料表的資料 `quotationproduct`
--

INSERT INTO `quotationproduct` (`quotationID`, `productID`, `unitPrice`, `quantity`) VALUES
('Q00001', 'P00001', 50.00, 10),
('Q00001', 'P00002', 100.00, 5),
('Q00002', 'P00003', 25.00, 20),
('Q00002', 'P00004', 30.00, 15),
('Q00003', 'P00005', 75.00, 8),
('Q00004', 'P00001', 100.00, 1),
('Q00005', 'P00001', 100.00, 20),
('Q00005', 'P00005', 50.00, 10),
('Q00006', 'P00001', 10.00, 1),
('Q00007', 'P00001', 100.00, 10),
('Q00008', 'P00001', 100.00, 10),
('Q00009', 'P00004', 50.00, 20),
('Q00010', 'P00001', 10.00, 1),
('Q00011', 'P00001', 100.00, 10),
('Q00012', 'P00001', 250.00, 15),
('Q00013', 'P00001', 250.00, 20),
('Q00014', 'P00001', 45.00, 30),
('Q00015', 'P00001', 200.00, 20),
('Q00016', 'P00003', 20.00, 10);

-- --------------------------------------------------------

--
-- 資料表結構 `rawmaterial`
--

CREATE TABLE `rawmaterial` (
  `materialID` char(6) NOT NULL,
  `materialName` varchar(20) NOT NULL,
  `inStockQuantity` int(11) DEFAULT NULL,
  `unit` varchar(10) NOT NULL,
  `lowLevelAlertIndex` int(11) NOT NULL,
  `stockStatus` varchar(15) DEFAULT NULL,
  `price` decimal(10,2) DEFAULT 0.00,
  `createdAt` date DEFAULT curdate()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- 傾印資料表的資料 `rawmaterial`
--

INSERT INTO `rawmaterial` (`materialID`, `materialName`, `inStockQuantity`, `unit`, `lowLevelAlertIndex`, `stockStatus`, `price`, `createdAt`) VALUES
('M00001', 'Plastic', 50, 'kg', 100, 'LOW_STOCK', 0.00, '2025-06-25'),
('M00002', 'Metal', 900, 'kg', 100, 'NORMAL', 12.00, '2025-06-25'),
('M00003', 'Wood', 280, 'kg', 30, 'NORMAL', 0.00, '2025-06-23'),
('M00004', 'Paint', 90, 'liters', 100, 'LOW_STOCK', 10.00, '2025-06-25'),
('M00005', 'Glue', 1935, 'liters', 50, 'NORMAL', 150.00, '2025-06-25'),
('M00006', 'Rubber', 505, 'kg', 20, 'NORMAL', 0.00, '2025-06-25'),
('M00007', 'Fabric', 90, 'meters', 100, 'LOW_STOCK', 0.00, '2025-06-25'),
('M00008', 'Batteries', 600, 'units', 600, 'LOW-STOCK', 0.00, '2025-06-23'),
('M00009', 'Electronics', 0, 'units', 45, 'LOW_STOCK', 0.00, '2025-06-25'),
('M00010', 'Packaging Material', 50, 'units', 55, 'LOW_STOCK', 0.00, '2025-06-25'),
('M00011', 'TEST', 120, 'KG', 10, 'NORMAL', 0.00, '2025-06-23'),
('M00012', 'TEST', 120, '10', 10, 'NORMAL', 12.00, '2025-06-23'),
('M00013', 'TEST', 120, '10', 10, 'NORMAL', 13.00, '2025-06-23');

-- --------------------------------------------------------

--
-- 資料表結構 `refund`
--

CREATE TABLE `refund` (
  `refundID` char(7) NOT NULL,
  `customerID` char(6) NOT NULL,
  `orderID` char(6) NOT NULL,
  `refundDescription` varchar(300) NOT NULL,
  `staffAssigned` char(6) DEFAULT NULL,
  `refundRejectReason` varchar(100) DEFAULT NULL,
  `refundStatus` varchar(60) DEFAULT NULL,
  `refundLastUpdate` date NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- 傾印資料表的資料 `refund`
--

INSERT INTO `refund` (`refundID`, `customerID`, `orderID`, `refundDescription`, `staffAssigned`, `refundRejectReason`, `refundStatus`, `refundLastUpdate`) VALUES
('OR00000', 'C00001', 'O00001', '1', NULL, NULL, 'Pending to CS department review', '2025-06-22'),
('OR00001', 'C00011', 'O00008', 'reject', NULL, NULL, 'Pending to CS department review', '2025-07-09');

-- --------------------------------------------------------

--
-- 資料表結構 `restockrequest`
--

CREATE TABLE `restockrequest` (
  `restockRequestID` char(6) NOT NULL,
  `materialID` char(6) NOT NULL,
  `restockQuantity` int(11) NOT NULL,
  `supplierID` char(6) NOT NULL,
  `expectedDate` date DEFAULT NULL,
  `createDate` date DEFAULT current_timestamp(),
  `restockStatus` varchar(10) NOT NULL DEFAULT 'Pending',
  `updatedDate` date DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- 傾印資料表的資料 `restockrequest`
--

INSERT INTO `restockrequest` (`restockRequestID`, `materialID`, `restockQuantity`, `supplierID`, `expectedDate`, `createDate`, `restockStatus`, `updatedDate`) VALUES
('R00001', 'M00001', 200, 'S00001', '2025-05-15', NULL, 'Completed', '2025-06-25'),
('R00002', 'M00002', 100, 'S00002', '2025-05-16', NULL, 'Cancelled', NULL),
('R00003', 'M00003', 50, 'S00003', '2025-05-17', NULL, 'Cancelled', NULL),
('R00004', 'M00004', 20, 'S00001', '2025-05-18', NULL, 'Cancelled', '2025-06-25'),
('R00005', 'M00005', 15, 'S00002', '2025-05-19', NULL, 'Completed', '2025-06-25'),
('R00006', 'M00007', 100, 'S00002', '2025-06-24', NULL, 'Completed', '2025-06-24'),
('R00007', 'M00006', 60, 'S00003', '2025-06-12', NULL, 'Cancelled', NULL),
('R00008', 'M00004', 20, 'S00003', '2025-06-26', NULL, 'Cancelled', NULL),
('R00009', 'M00004', 20, 'S00003', '2025-06-26', NULL, 'Completed', '2025-06-23'),
('R00010', 'M00006', 90, 'S00003', '2025-06-26', NULL, 'Cancelled', NULL),
('R00011', 'M00007', 30, 'S00002', '2025-06-30', NULL, 'Cancelled', NULL),
('R00012', 'M00006', 300, 'S00002', '2025-06-30', NULL, 'Completed', '2025-06-24'),
('R00013', 'M00008', 1000, 'S00003', '2025-07-12', NULL, 'Cancelled', '2025-06-25'),
('R00014', 'M00006', 35, 'S00003', '2025-06-30', '2025-06-23', 'Completed', '2025-06-24'),
('R00015', 'M00008', 100, 'S00002', '2025-07-02', '2025-06-25', 'Cancelled', '2025-06-25'),
('R00016', 'M00002', 1000, 'S00003', '2025-07-02', '2025-06-25', 'Completed', '2025-06-25'),
('R00017', 'M00002', 1000, 'S00002', '2025-07-02', '2025-06-25', 'Completed', '2025-06-25'),
('R00018', 'M00006', 1000, 'S00002', '2025-07-02', '2025-06-25', 'Pending', '2025-06-25'),
('R00019', 'M00007', 10, 'S00003', '2025-07-02', '2025-06-25', 'Completed', '2025-06-25'),
('R00020', 'M00002', 100, 'S00002', '2025-07-02', '2025-06-25', 'Completed', '2025-06-25'),
('R00021', 'M00004', 1000, 'S00003', '2025-07-02', '2025-06-25', 'Cancelled', NULL),
('R00022', 'M00002', 1000, 'S00002', '2025-07-02', '2025-06-25', 'Completed', '2025-06-25'),
('R00023', 'M00006', 100, 'S00003', '2025-07-03', '2025-06-26', 'Completed', '2025-06-26');

-- --------------------------------------------------------

--
-- 資料表結構 `staff`
--

CREATE TABLE `staff` (
  `staffID` char(6) NOT NULL,
  `staffName` varchar(20) NOT NULL,
  `staffPassword` varchar(255) NOT NULL,
  `departmentID` char(6) DEFAULT NULL,
  `position` varchar(40) NOT NULL,
  `staffEmail` varchar(50) DEFAULT NULL,
  `staffPhone` char(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- 傾印資料表的資料 `staff`
--

INSERT INTO `staff` (`staffID`, `staffName`, `staffPassword`, `departmentID`, `position`, `staffEmail`, `staffPhone`) VALUES
('E00001', 'Alice Johnson', 'c2b177aaa2a7bdd9b72d9c0c5f7bf883f5ed5a71dc91550a3f9b3933b380d886', 'D00001', 'Research Scientist', 'alice.johnson@smilesunshinetoy.com', '85212345678'),
('E00002', 'Bob Smith', '38654ae0688d64e2bc15b60766bdcd4e3135c40c22cef3247d81d7aaf7ae3537', 'D00002', 'Marketing Manager', 'bob.smith@smilesunshinetoy.com', '85212345679'),
('E00003', 'Charlie Brown', '580a4c8224b0760df4f4754ac70597e83d957995e0947a6594c6896c3eabe47a', 'D00003', 'Production Supervisor', 'charlie.brown@smilesunshinetoy.com', '85212345680'),
('E00004', 'Diana Prince', '376b7585040cf3646f86af635cdbfe421517fe333a53018c3e8214e42eb6a136', 'D00004', 'Supply Chain Analyst', 'diana.prince@smilesunshinetoy.com', '85212345681'),
('E00005', 'Ethan Hunt', '9a379c14d3550f58c9491c7e4da06a2558550f0e447d2f3c0a85000dbbf124c4', 'D00005', 'Customer Service Rep', 'ethan.hunt@smilesunshinetoy.com', '85212345682'),
('E00006', 'Fiona Green', '5f0fe53fd444a381db0492b81d648a28201e6a14fc9b53b6d5a5b4c4c7fc8c41', 'D00006', 'Financial Analyst', 'fiona.green@smilesunshinetoy.com', '85212345683'),
('E00007', 'George Clark', '3f4916d85916d656b224d0a8f77792da8477b6e1e44301cf89a03c66b7c56db8', 'D00007', 'IT Support', 'george.clark@smilesunshinetoy.com', '85212345684'),
('E00008', 'Helen White', '7533e0c0bb4c4dddf6b071156f2db30525e0734405cf5f598ac17272ca0fb93f', 'D00001', 'CEO', 'helen.white@smilesunshinetoy.com', '85212345685'),
('E00009', 'Ian Black', 'f3c0c8ac00f5d4e377f55181e1b0e4942cdb482fbdc1a905108c1d5a75bdaee0', 'D00002', 'Test no permission', 'ian.black@smilesunshinetoy.com', '85212345686'),
('E00010', 'Julia King', '2ac9b5c6bdadc2b264fcb01a616cfc885e8e171e17ba5ce147bb885c1e0cfd3e', 'D00003', 'IT Manager', 'julia.king@smilesunshinetoy.com', '85212345687'),
('E00011', 'cs', '3b8b91c75627bee566dcb88f4805901b20a3eab2520bcff8d26c87157a035026', 'D00005', 'Customer Services Officer', 'cstest@smilesunshine.com', '22222222'),
('E00012', 'fin', 'a383bcb77c832a8ff52caace0f4efa8f1639b56b3ad5e32df3c35e8e2ca88f92', 'D00006', 'Accounting Officer', 'fintest@smilesunshine.com', '22222223'),
('E00013', 'snm', 'e7de46390a4a467a50abc101fe3a269667cf2773649d1c92757bd3740e6f8e07', 'D00002', 'Sales Manager', 'snmtest@smilesunshine.com', '22222225'),
('E00014', 'it', '2ad8a7049d7c5511ac254f5f51fe70a046ebd884729056f0fe57f5160d467153', 'D00007', 'IT support', 'ittest@smilesunshine.com', '22222221'),
('E00015', 'pro', '07ed400759a0f606a8b5bfa84712aabe7d1b1c45cb6536c8a5727446b6647b84', 'D00003', 'pro', 'pro@smilesunshine.com', '12345678');

-- --------------------------------------------------------

--
-- 資料表結構 `staffsystemaccessright`
--

CREATE TABLE `staffsystemaccessright` (
  `staffID` char(6) NOT NULL,
  `systemFunctionID` char(7) NOT NULL,
  `systemAccessRight` int(11) DEFAULT 0
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- 傾印資料表的資料 `staffsystemaccessright`
--

INSERT INTO `staffsystemaccessright` (`staffID`, `systemFunctionID`, `systemAccessRight`) VALUES
('E00001', 'SF00001', 2),
('E00001', 'SF00002', 2),
('E00001', 'SF00101', 2),
('E00001', 'SF00102', 2),
('E00001', 'SF00103', 2),
('E00001', 'SF00104', 2),
('E00001', 'SF00105', 2),
('E00001', 'SF00106', 2),
('E00001', 'SF00107', 2),
('E00001', 'SF00108', 2),
('E00002', 'SF00001', 2),
('E00002', 'SF00002', 2),
('E00002', 'SF00201', 2),
('E00002', 'SF00202', 2),
('E00002', 'SF00203', 2),
('E00002', 'SF00204', 2),
('E00002', 'SF00205', 2),
('E00002', 'SF00206', 2),
('E00002', 'SF00207', 2),
('E00002', 'SF00208', 2),
('E00002', 'SF00209', 2),
('E00002', 'SF00210', 2),
('E00003', 'SF00001', 2),
('E00003', 'SF00002', 2),
('E00003', 'SF00301', 2),
('E00003', 'SF00302', 2),
('E00004', 'SF00001', 2),
('E00004', 'SF00002', 2),
('E00004', 'SF00401', 2),
('E00004', 'SF00402', 2),
('E00004', 'SF00403', 2),
('E00004', 'SF00404', 2),
('E00004', 'SF00405', 2),
('E00004', 'SF00406', 2),
('E00004', 'SF00407', 2),
('E00004', 'SF00408', 2),
('E00004', 'SF00501', 2),
('E00004', 'SF00502', 2),
('E00004', 'SF00601', 2),
('E00004', 'SF00602', 2),
('E00004', 'SF00603', 2),
('E00004', 'SF00701', 2),
('E00004', 'SF00702', 2),
('E00004', 'SF00703', 2),
('E00004', 'SF00704', 2),
('E00005', 'SF00001', 2),
('E00005', 'SF00002', 2),
('E00005', 'SF00801', 2),
('E00005', 'SF00802', 2),
('E00005', 'SF00803', 2),
('E00005', 'SF00804', 2),
('E00005', 'SF00901', 2),
('E00005', 'SF00902', 2),
('E00005', 'SF00903', 2),
('E00005', 'SF00904', 2),
('E00006', 'SF00001', 2),
('E00006', 'SF00002', 2),
('E00006', 'SF01001', 2),
('E00006', 'SF01002', 2),
('E00007', 'SF00001', 2),
('E00007', 'SF00002', 2),
('E00007', 'SF01101', 2),
('E00007', 'SF01201', 2),
('E00007', 'SF01202', 2),
('E00007', 'SF01203', 2),
('E00007', 'SF01301', 2),
('E00007', 'SF01302', 2),
('E00007', 'SF01303', 2),
('E00007', 'SF01304', 2),
('E00007', 'SF01305', 2),
('E00007', 'SF01306', 2),
('E00007', 'SF01307', 2),
('E00007', 'SF01401', 2),
('E00007', 'SF01402', 2),
('E00007', 'SF01403', 2),
('E00007', 'SF01404', 2),
('E00007', 'SF01405', 2),
('E00007', 'SF01501', 2),
('E00007', 'SF01502', 2),
('E00007', 'SF01503', 2),
('E00008', 'SF00001', 2),
('E00008', 'SF00002', 2),
('E00008', 'SF00101', 2),
('E00008', 'SF00102', 2),
('E00008', 'SF00103', 2),
('E00008', 'SF00104', 2),
('E00008', 'SF00105', 2),
('E00008', 'SF00106', 2),
('E00008', 'SF00107', 2),
('E00008', 'SF00108', 2),
('E00008', 'SF00201', 2),
('E00008', 'SF00202', 2),
('E00008', 'SF00203', 2),
('E00008', 'SF00204', 2),
('E00008', 'SF00205', 2),
('E00008', 'SF00206', 2),
('E00008', 'SF00207', 2),
('E00008', 'SF00208', 2),
('E00008', 'SF00209', 2),
('E00008', 'SF00210', 2),
('E00008', 'SF00301', 2),
('E00008', 'SF00302', 2),
('E00008', 'SF00401', 2),
('E00008', 'SF00402', 2),
('E00008', 'SF00403', 2),
('E00008', 'SF00404', 2),
('E00008', 'SF00405', 2),
('E00008', 'SF00406', 2),
('E00008', 'SF00407', 2),
('E00008', 'SF00408', 2),
('E00008', 'SF00501', 2),
('E00008', 'SF00502', 2),
('E00008', 'SF00601', 2),
('E00008', 'SF00602', 2),
('E00008', 'SF00603', 2),
('E00008', 'SF00701', 2),
('E00008', 'SF00702', 2),
('E00008', 'SF00703', 2),
('E00008', 'SF00704', 2),
('E00008', 'SF00801', 2),
('E00008', 'SF00802', 2),
('E00008', 'SF00803', 2),
('E00008', 'SF00804', 2),
('E00008', 'SF00901', 2),
('E00008', 'SF00902', 2),
('E00008', 'SF00903', 2),
('E00008', 'SF00904', 2),
('E00008', 'SF01001', 2),
('E00008', 'SF01002', 2),
('E00008', 'SF01101', 2),
('E00008', 'SF01201', 2),
('E00008', 'SF01202', 2),
('E00008', 'SF01203', 2),
('E00008', 'SF01301', 2),
('E00008', 'SF01302', 2),
('E00008', 'SF01303', 2),
('E00008', 'SF01304', 2),
('E00008', 'SF01305', 2),
('E00008', 'SF01306', 2),
('E00008', 'SF01307', 2),
('E00008', 'SF01401', 2),
('E00008', 'SF01402', 2),
('E00008', 'SF01403', 2),
('E00008', 'SF01404', 2),
('E00008', 'SF01405', 2),
('E00008', 'SF01501', 2),
('E00008', 'SF01502', 2),
('E00008', 'SF01503', 2),
('E00010', 'SF00001', 2),
('E00010', 'SF00002', 2),
('E00010', 'SF00101', 2),
('E00010', 'SF00102', 2),
('E00010', 'SF00103', 2),
('E00010', 'SF00104', 2),
('E00010', 'SF00105', 2),
('E00010', 'SF00106', 2),
('E00010', 'SF00107', 2),
('E00010', 'SF00108', 2),
('E00010', 'SF00201', 2),
('E00010', 'SF00202', 2),
('E00010', 'SF00203', 2),
('E00010', 'SF00204', 2),
('E00010', 'SF00205', 2),
('E00010', 'SF00206', 2),
('E00010', 'SF00207', 2),
('E00010', 'SF00208', 2),
('E00010', 'SF00209', 2),
('E00010', 'SF00210', 2),
('E00010', 'SF00301', 2),
('E00010', 'SF00302', 2),
('E00010', 'SF00401', 2),
('E00010', 'SF00402', 2),
('E00010', 'SF00403', 2),
('E00010', 'SF00404', 2),
('E00010', 'SF00405', 2),
('E00010', 'SF00406', 2),
('E00010', 'SF00407', 2),
('E00010', 'SF00408', 2),
('E00010', 'SF00501', 2),
('E00010', 'SF00502', 2),
('E00010', 'SF00601', 2),
('E00010', 'SF00602', 2),
('E00010', 'SF00603', 2),
('E00010', 'SF00701', 2),
('E00010', 'SF00702', 2),
('E00010', 'SF00703', 2),
('E00010', 'SF00704', 2),
('E00010', 'SF00801', 2),
('E00010', 'SF00802', 2),
('E00010', 'SF00803', 2),
('E00010', 'SF00804', 2),
('E00010', 'SF00901', 2),
('E00010', 'SF00902', 2),
('E00010', 'SF00903', 2),
('E00010', 'SF00904', 2),
('E00010', 'SF01001', 2),
('E00010', 'SF01002', 2),
('E00010', 'SF01101', 2),
('E00010', 'SF01201', 2),
('E00010', 'SF01202', 2),
('E00010', 'SF01203', 2),
('E00010', 'SF01301', 2),
('E00010', 'SF01302', 2),
('E00010', 'SF01303', 2),
('E00010', 'SF01304', 2),
('E00010', 'SF01305', 2),
('E00010', 'SF01306', 2),
('E00010', 'SF01307', 2),
('E00010', 'SF01401', 2),
('E00010', 'SF01402', 2),
('E00010', 'SF01403', 2),
('E00010', 'SF01404', 2),
('E00010', 'SF01405', 2),
('E00010', 'SF01501', 2),
('E00010', 'SF01502', 2),
('E00010', 'SF01503', 2),
('E00011', 'SF00001', 2),
('E00011', 'SF00002', 2),
('E00011', 'SF00801', 2),
('E00011', 'SF00802', 2),
('E00011', 'SF00803', 2),
('E00011', 'SF00804', 2),
('E00011', 'SF00901', 2),
('E00011', 'SF00902', 2),
('E00011', 'SF00903', 2),
('E00011', 'SF00904', 2),
('E00012', 'SF00001', 2),
('E00012', 'SF00002', 2),
('E00012', 'SF00301', 2),
('E00012', 'SF00302', 2),
('E00012', 'SF00901', 2),
('E00012', 'SF00902', 2),
('E00012', 'SF00903', 2),
('E00012', 'SF00904', 2),
('E00012', 'SF01001', 2),
('E00012', 'SF01002', 2),
('E00012', 'SF01101', 2),
('E00013', 'SF00001', 2),
('E00013', 'SF00002', 2),
('E00013', 'SF00201', 2),
('E00013', 'SF00202', 2),
('E00013', 'SF00203', 2),
('E00013', 'SF00204', 2),
('E00013', 'SF00205', 2),
('E00013', 'SF00206', 2),
('E00013', 'SF00207', 2),
('E00013', 'SF00208', 2),
('E00013', 'SF00209', 2),
('E00013', 'SF00210', 2),
('E00013', 'SF00901', 2),
('E00013', 'SF00902', 2),
('E00013', 'SF00903', 2),
('E00013', 'SF00904', 2),
('E00014', 'SF00001', 2),
('E00014', 'SF00002', 2),
('E00014', 'SF01201', 2),
('E00014', 'SF01202', 2),
('E00014', 'SF01203', 2),
('E00014', 'SF01301', 2),
('E00014', 'SF01302', 2),
('E00014', 'SF01303', 2),
('E00014', 'SF01304', 2),
('E00014', 'SF01305', 2),
('E00014', 'SF01306', 2),
('E00014', 'SF01307', 2),
('E00014', 'SF01401', 2),
('E00014', 'SF01402', 2),
('E00014', 'SF01403', 2),
('E00014', 'SF01404', 2),
('E00014', 'SF01405', 2),
('E00014', 'SF01501', 2),
('E00014', 'SF01502', 2),
('E00014', 'SF01503', 2),
('E00015', 'SF00001', 2),
('E00015', 'SF00002', 2),
('E00015', 'SF00301', 2),
('E00015', 'SF00302', 2),
('E00015', 'SF00401', 2),
('E00015', 'SF00402', 2),
('E00015', 'SF00403', 2),
('E00015', 'SF00404', 2),
('E00015', 'SF00405', 2),
('E00015', 'SF00406', 2),
('E00015', 'SF00407', 2),
('E00015', 'SF00408', 2),
('E00015', 'SF00501', 2),
('E00015', 'SF00502', 2);

-- --------------------------------------------------------

--
-- 資料表結構 `supplier`
--

CREATE TABLE `supplier` (
  `supplierID` char(6) NOT NULL,
  `supplierName` varchar(50) NOT NULL,
  `supplierPhone` char(8) DEFAULT NULL,
  `supplierEmail` varchar(50) DEFAULT NULL,
  `supplierAddress` varchar(100) DEFAULT NULL,
  `contactPerson` varchar(50) DEFAULT NULL,
  `status` varchar(10) DEFAULT 'valid'
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- 傾印資料表的資料 `supplier`
--

INSERT INTO `supplier` (`supplierID`, `supplierName`, `supplierPhone`, `supplierEmail`, `supplierAddress`, `contactPerson`, `status`) VALUES
('S00001', 'Supplier A', '12345678', 'supplierA@example.com', '123 Supplier St, City, Country', ' ', 'Invalid'),
('S00002', 'Supplier B', '12345678', 'supplierB@example.com', '456 Supplier Ave, City, Country', NULL, 'valid'),
('S00003', 'Supplier C', '98765432', 'supplierC@example.com', '789 Supplier Blvd, City, Country', NULL, 'valid'),
('S00004', 'TEST', '12345678', 'abc@gmail.com', 'ST', 'PETER', 'valid'),
('S00005', 'testname', '22334455', 'syl@qq.com', 'testaddress', 'candy', 'valid'),
('S00006', 'testname', '33334444', 'test@gmail.com', 'testaddress', 'SHI', 'valid');

-- --------------------------------------------------------

--
-- 資料表結構 `systemfeedback`
--

CREATE TABLE `systemfeedback` (
  `systemFeedbackID` char(7) NOT NULL,
  `staffID` char(6) NOT NULL,
  `systemID` char(7) NOT NULL,
  `systemFeedbackComment` varchar(300) DEFAULT NULL,
  `systemFeedback_submissionDate` date NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- 傾印資料表的資料 `systemfeedback`
--

INSERT INTO `systemfeedback` (`systemFeedbackID`, `staffID`, `systemID`, `systemFeedbackComment`, `systemFeedback_submissionDate`) VALUES
('FB00001', 'E00010', 'SI00001', 'Great system performance.', '2025-05-15'),
('FB00002', 'E00010', 'SI00002', 'Minor bug found in module.', '2025-05-15'),
('FB00003', 'E00010', 'SI00003', 'Request for new feature.', '2025-05-15'),
('FB00004', 'E00010', 'SI00004', 'System downtime issue.', '2025-05-15'),
('FB00005', 'E00010', 'SI00005', 'User interface improvement suggestion.', '2025-05-15');

-- --------------------------------------------------------

--
-- 資料表結構 `systemfeedbackaspectrating`
--

CREATE TABLE `systemfeedbackaspectrating` (
  `systemFeedbackID` char(7) NOT NULL,
  `aspect` varchar(35) NOT NULL,
  `rating` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- 傾印資料表的資料 `systemfeedbackaspectrating`
--

INSERT INTO `systemfeedbackaspectrating` (`systemFeedbackID`, `aspect`, `rating`) VALUES
('FB00001', 'Performance', 5),
('FB00001', 'Usability', 4),
('FB00002', 'BugFix', 3),
('FB00003', 'FeatureRequest', 4),
('FB00004', 'Downtime', 2),
('FB00005', 'UI/UX', 4);

-- --------------------------------------------------------

--
-- 資料表結構 `systemfunction`
--

CREATE TABLE `systemfunction` (
  `systemFunctionID` char(7) NOT NULL,
  `systemID` char(7) DEFAULT NULL,
  `systemName` varchar(50) DEFAULT NULL,
  `deptID` char(6) DEFAULT NULL,
  `systemFunctionName` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- 傾印資料表的資料 `systemfunction`
--

INSERT INTO `systemfunction` (`systemFunctionID`, `systemID`, `systemName`, `deptID`, `systemFunctionName`) VALUES
('SF00001', 'SI00000', 'Login System', NULL, 'LoginAccount'),
('SF00002', 'SI00000', 'Login System', NULL, 'ForgetPassword'),
('SF00101', 'SI00001', 'Project Management System', 'D00001', 'CreateProject'),
('SF00102', 'SI00001', 'Project Management System', 'D00001', 'ViewProject'),
('SF00103', 'SI00001', 'Project Management System', 'D00001', 'ModifyTask'),
('SF00104', 'SI00001', 'Project Management System', 'D00001', 'DeleteProject'),
('SF00105', 'SI00002', 'Product Specification System', 'D00001', 'CreateProduct'),
('SF00106', 'SI00002', 'Product Specification System', 'D00001', 'UpdateProductAttribute'),
('SF00107', 'SI00002', 'Product Specification System', 'D00001', 'ViewVersionHistory'),
('SF00108', 'SI00002', 'Product Specification System', 'D00001', 'DeleteProduct'),
('SF00201', 'SI00003', 'Order Management System', 'D00002', 'CreateQuotation'),
('SF00202', 'SI00003', 'Order Management System', 'D00002', 'ViewQuotation'),
('SF00203', 'SI00003', 'Order Management System', 'D00002', 'EditQuotation'),
('SF00204', 'SI00003', 'Order Management System', 'D00002', 'DeleteQuotation'),
('SF00205', 'SI00003', 'Order Management System', 'D00002', 'GenerateQuotation'),
('SF00206', 'SI00003', 'Order Management System', 'D00002', 'ConvertQuotation'),
('SF00207', 'SI00003', 'Order Management System', 'D00002', 'ViewOrder'),
('SF00208', 'SI00003', 'Order Management System', 'D00002', 'SendOrder'),
('SF00209', 'SI00003', 'Order Management System', 'D00002', 'DeleteOrder'),
('SF00210', 'SI00003', 'Order Management System', 'D00002', 'GenerateInvoice'),
('SF00301', 'SI00004', 'Production Monitoring System', 'D00003', 'ViewOrder'),
('SF00302', 'SI00004', 'Production Monitoring System', 'D00003', 'UpdateOrder'),
('SF00401', 'SI00005', 'Raw Material Management System', 'D00004', 'ViewRawMaterial'),
('SF00402', 'SI00005', 'Raw Material Management System', 'D00004', 'AddRawMaterial'),
('SF00403', 'SI00005', 'Raw Material Management System', 'D00004', 'EditRawMaterial'),
('SF00404', 'SI00005', 'Raw Material Management System', 'D00004', 'DeleteRawMaterial'),
('SF00405', 'SI00005', 'Raw Material Management System', 'D00004', 'RequestMaterialRestock'),
('SF00406', 'SI00005', 'Raw Material Management System', 'D00004', 'ViewMaterialRestockStatus'),
('SF00407', 'SI00005', 'Raw Material Management System', 'D00004', 'UpdateMaterialRestockStatus'),
('SF00408', 'SI00005', 'Raw Material Management System', 'D00004', 'RequestRawMaterialForProduction'),
('SF00501', 'SI00006', 'Inventory Management System', 'D00004', 'ViewInventory'),
('SF00502', 'SI00006', 'Inventory Management System', 'D00004', 'GenerateReport'),
('SF00601', 'SI00007', 'Delivery System', 'D00004', 'CreateDelivery'),
('SF00602', 'SI00007', 'Delivery System', 'D00004', 'ViewDelivery'),
('SF00603', 'SI00007', 'Delivery System', 'D00004', 'DeleteDelivery'),
('SF00701', 'SI00008', 'Supplier Information System', 'D00004', 'CreateSupplier'),
('SF00702', 'SI00008', 'Supplier Information System', 'D00004', 'ViewSupplier'),
('SF00703', 'SI00008', 'Supplier Information System', 'D00004', 'EditSupplier'),
('SF00704', 'SI00008', 'Supplier Information System', 'D00004', 'DeleteSupplier'),
('SF00801', 'SI00009', 'Customer Feedback System', 'D00005', 'SubmitCustomerFeedback'),
('SF00802', 'SI00009', 'Customer Feedback System', 'D00005', 'ViewCustomerFeedback'),
('SF00803', 'SI00009', 'Customer Feedback System', 'D00005', 'UpdateCustomerFeedbackStatus'),
('SF00804', 'SI00009', 'Customer Feedback System', 'D00005', 'ReassignCustomerFeedbackHandler'),
('SF00901', 'SI00010', 'Product Refund System', 'D00005', 'ApplyForRefund'),
('SF00902', 'SI00010', 'Product Refund System', 'D00005', 'ViewRefundApplications'),
('SF00903', 'SI00010', 'Product Refund System', 'D00005', 'ApproveRejectRefundApplication'),
('SF00904', 'SI00010', 'Product Refund System', 'D00005', 'ProcessRefund'),
('SF01001', 'SI00011', 'Finance Analysis Tool', 'D00006', 'FetchData'),
('SF01002', 'SI00011', 'Finance Analysis Tool', 'D00006', 'DataAnalysis'),
('SF01101', 'SI00012', 'Payment Gateway', 'D00006', 'MakePayment'),
('SF01201', 'SI00013', 'User Management System', 'D00007', 'CreateUser'),
('SF01202', 'SI00013', 'User Management System', 'D00007', 'ModifyUserProfile'),
('SF01203', 'SI00013', 'User Management System', 'D00007', 'ViewUserInformation'),
('SF01301', 'SI00014', 'Support Request System', 'D00007', 'SubmitITSupportRequest'),
('SF01302', 'SI00014', 'Support Request System', 'D00007', 'ViewITSupportRequest'),
('SF01303', 'SI00014', 'Support Request System', 'D00007', 'AssignITSupportRequestHandler'),
('SF01304', 'SI00014', 'Support Request System', 'D00007', 'ReassignITSupportRequestHandler'),
('SF01305', 'SI00014', 'Support Request System', 'D00007', 'UpdateITSupportRequestStatus'),
('SF01306', 'SI00014', 'Support Request System', 'D00007', 'ArchiveITSupportRequest'),
('SF01307', 'SI00014', 'Support Request System', 'D00007', 'UnarchiveITSupportRequest'),
('SF01401', 'SI00015', 'System Learning Platform', 'D00007', 'ViewDemonstrationVideo'),
('SF01402', 'SI00015', 'System Learning Platform', 'D00007', 'ViewUploadedVideo'),
('SF01403', 'SI00015', 'System Learning Platform', 'D00007', 'AddVideo'),
('SF01404', 'SI00015', 'System Learning Platform', 'D00007', 'EditVideoInformation'),
('SF01405', 'SI00015', 'System Learning Platform', 'D00007', 'RemoveVideo'),
('SF01501', 'SI00016', 'Software Feedback Collection System', 'D00007', 'SubmitSystemFeedback'),
('SF01502', 'SI00016', 'Software Feedback Collection System', 'D00007', 'ViewSystemFeedback'),
('SF01503', 'SI00016', 'Software Feedback Collection System', 'D00007', 'AnalyzeSystemFeedback');

-- --------------------------------------------------------

--
-- 資料表結構 `task`
--

CREATE TABLE `task` (
  `taskID` char(10) NOT NULL,
  `taskName` varchar(250) NOT NULL,
  `taskDescription` varchar(400) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- 傾印資料表的資料 `task`
--

INSERT INTO `task` (`taskID`, `taskName`, `taskDescription`) VALUES
('T000000001', 'Task A1', 'Description of Task A1'),
('T000000002', 'Task A2', 'Description of Task A2'),
('TT00000003', 'Task B1', 'Description of Task B1'),
('TT00000004', 'Task C1', 'Description of Task C1'),
('TT00000005', 'Task C2', 'Description of Task C2');

--
-- 已傾印資料表的索引
--

--
-- 資料表索引 `courier`
--
ALTER TABLE `courier`
  ADD PRIMARY KEY (`courierID`);

--
-- 資料表索引 `customer`
--
ALTER TABLE `customer`
  ADD PRIMARY KEY (`customerID`);

--
-- 資料表索引 `customersystemaccessright`
--
ALTER TABLE `customersystemaccessright`
  ADD PRIMARY KEY (`customerID`,`systemFunctionID`),
  ADD KEY `systemFunctionID` (`systemFunctionID`);

--
-- 資料表索引 `deliveryorder`
--
ALTER TABLE `deliveryorder`
  ADD PRIMARY KEY (`deliveryOrderID`),
  ADD KEY `personInCharge` (`personInCharge`),
  ADD KEY `courierID` (`courierID`),
  ADD KEY `delivery_fk1` (`requestID`);

--
-- 資料表索引 `deliveryproduct`
--
ALTER TABLE `deliveryproduct`
  ADD PRIMARY KEY (`deliveryOrderID`,`orderID`),
  ADD KEY `orderID` (`orderID`);

--
-- 資料表索引 `deliveryrawmaterial`
--
ALTER TABLE `deliveryrawmaterial`
  ADD PRIMARY KEY (`deliveryOrderID`,`materialID`),
  ADD KEY `materialID` (`materialID`);

--
-- 資料表索引 `deliveryrequest`
--
ALTER TABLE `deliveryrequest`
  ADD PRIMARY KEY (`requestID`),
  ADD KEY `deliveryrequest_ibfk_1` (`orderID`);

--
-- 資料表索引 `demonstrationvideo`
--
ALTER TABLE `demonstrationvideo`
  ADD PRIMARY KEY (`videoID`),
  ADD KEY `departmentID` (`departmentID`);

--
-- 資料表索引 `department`
--
ALTER TABLE `department`
  ADD PRIMARY KEY (`deptID`);

--
-- 資料表索引 `file`
--
ALTER TABLE `file`
  ADD PRIMARY KEY (`fileID`),
  ADD KEY `recordPerson` (`recordPerson`);

--
-- 資料表索引 `itsupportrequest`
--
ALTER TABLE `itsupportrequest`
  ADD PRIMARY KEY (`itRequestID`),
  ADD KEY `staffID` (`staffID`),
  ADD KEY `staffAssigned` (`staffAssigned`);

--
-- 資料表索引 `itsystem`
--
ALTER TABLE `itsystem`
  ADD PRIMARY KEY (`systemID`);

--
-- 資料表索引 `materialdemand`
--
ALTER TABLE `materialdemand`
  ADD KEY `fk_materialdemand` (`materialID`);

--
-- 資料表索引 `orderproduct`
--
ALTER TABLE `orderproduct`
  ADD PRIMARY KEY (`orderID`,`productID`),
  ADD KEY `productID` (`productID`);

--
-- 資料表索引 `payment`
--
ALTER TABLE `payment`
  ADD PRIMARY KEY (`paymentID`),
  ADD KEY `orderID` (`orderID`),
  ADD KEY `paymentMethodID` (`paymentMethodID`);

--
-- 資料表索引 `paymentdetails`
--
ALTER TABLE `paymentdetails`
  ADD PRIMARY KEY (`customerID`,`paymentMethodID`),
  ADD KEY `paymentMethodID` (`paymentMethodID`);

--
-- 資料表索引 `paymentmethod`
--
ALTER TABLE `paymentmethod`
  ADD PRIMARY KEY (`paymentMethodID`);

--
-- 資料表索引 `placedorder`
--
ALTER TABLE `placedorder`
  ADD PRIMARY KEY (`orderID`),
  ADD KEY `quotationID` (`quotationID`),
  ADD KEY `customerID` (`customerID`);

--
-- 資料表索引 `product`
--
ALTER TABLE `product`
  ADD PRIMARY KEY (`productID`),
  ADD KEY `parentProductID` (`parentProductID`);

--
-- 資料表索引 `productattribute`
--
ALTER TABLE `productattribute`
  ADD PRIMARY KEY (`attributeID`);

--
-- 資料表索引 `productattributeversion`
--
ALTER TABLE `productattributeversion`
  ADD PRIMARY KEY (`versionID`),
  ADD KEY `productID` (`productID`),
  ADD KEY `attributeID` (`attributeID`),
  ADD KEY `fileID` (`fileID`),
  ADD KEY `recordPerson` (`recordPerson`);

--
-- 資料表索引 `productdelete`
--
ALTER TABLE `productdelete`
  ADD PRIMARY KEY (`approvalID`),
  ADD KEY `productID` (`productID`),
  ADD KEY `staffID` (`staffID`);

--
-- 資料表索引 `productmaterialversion`
--
ALTER TABLE `productmaterialversion`
  ADD PRIMARY KEY (`versionID`),
  ADD KEY `productID` (`productID`),
  ADD KEY `materialID` (`materialID`),
  ADD KEY `recordPerson` (`recordPerson`);

--
-- 資料表索引 `productteam`
--
ALTER TABLE `productteam`
  ADD PRIMARY KEY (`productID`,`personID`);

--
-- 資料表索引 `project`
--
ALTER TABLE `project`
  ADD PRIMARY KEY (`projectID`);

--
-- 資料表索引 `projecttask`
--
ALTER TABLE `projecttask`
  ADD PRIMARY KEY (`projectID`,`taskID`),
  ADD KEY `taskID` (`taskID`),
  ADD KEY `departmentID` (`departmentID`);

--
-- 資料表索引 `projectteam`
--
ALTER TABLE `projectteam`
  ADD PRIMARY KEY (`projectID`,`staffID`),
  ADD KEY `staffID` (`staffID`);

--
-- 資料表索引 `quotation`
--
ALTER TABLE `quotation`
  ADD PRIMARY KEY (`quotationID`),
  ADD KEY `customerID` (`customerID`);

--
-- 資料表索引 `quotationproduct`
--
ALTER TABLE `quotationproduct`
  ADD PRIMARY KEY (`quotationID`,`productID`),
  ADD KEY `productID` (`productID`);

--
-- 資料表索引 `rawmaterial`
--
ALTER TABLE `rawmaterial`
  ADD PRIMARY KEY (`materialID`);

--
-- 資料表索引 `refund`
--
ALTER TABLE `refund`
  ADD PRIMARY KEY (`refundID`),
  ADD KEY `fk_customerID` (`customerID`),
  ADD KEY `fk_orderID` (`orderID`),
  ADD KEY `fk_staff` (`staffAssigned`);

--
-- 資料表索引 `restockrequest`
--
ALTER TABLE `restockrequest`
  ADD PRIMARY KEY (`restockRequestID`,`materialID`,`supplierID`),
  ADD KEY `materialID` (`materialID`),
  ADD KEY `supplierID` (`supplierID`);

--
-- 資料表索引 `staff`
--
ALTER TABLE `staff`
  ADD PRIMARY KEY (`staffID`),
  ADD KEY `departmentID` (`departmentID`);

--
-- 資料表索引 `staffsystemaccessright`
--
ALTER TABLE `staffsystemaccessright`
  ADD PRIMARY KEY (`staffID`,`systemFunctionID`),
  ADD KEY `systemFunctionID` (`systemFunctionID`);

--
-- 資料表索引 `supplier`
--
ALTER TABLE `supplier`
  ADD PRIMARY KEY (`supplierID`);

--
-- 資料表索引 `systemfeedback`
--
ALTER TABLE `systemfeedback`
  ADD PRIMARY KEY (`systemFeedbackID`),
  ADD KEY `staffID` (`staffID`),
  ADD KEY `systemID` (`systemID`);

--
-- 資料表索引 `systemfeedbackaspectrating`
--
ALTER TABLE `systemfeedbackaspectrating`
  ADD PRIMARY KEY (`systemFeedbackID`,`aspect`);

--
-- 資料表索引 `systemfunction`
--
ALTER TABLE `systemfunction`
  ADD PRIMARY KEY (`systemFunctionID`),
  ADD KEY `systemID` (`systemID`);

--
-- 資料表索引 `task`
--
ALTER TABLE `task`
  ADD PRIMARY KEY (`taskID`);

--
-- 已傾印資料表的限制式
--

--
-- 資料表的限制式 `customersystemaccessright`
--
ALTER TABLE `customersystemaccessright`
  ADD CONSTRAINT `customersystemaccessright_ibfk_1` FOREIGN KEY (`customerID`) REFERENCES `customer` (`customerID`),
  ADD CONSTRAINT `customersystemaccessright_ibfk_2` FOREIGN KEY (`systemFunctionID`) REFERENCES `systemfunction` (`systemFunctionID`);

--
-- 資料表的限制式 `deliveryorder`
--
ALTER TABLE `deliveryorder`
  ADD CONSTRAINT `delivery_fk1` FOREIGN KEY (`requestID`) REFERENCES `deliveryrequest` (`requestID`),
  ADD CONSTRAINT `deliveryorder_ibfk_2` FOREIGN KEY (`courierID`) REFERENCES `courier` (`courierID`);

--
-- 資料表的限制式 `deliveryproduct`
--
ALTER TABLE `deliveryproduct`
  ADD CONSTRAINT `deliveryproduct_ibfk_1` FOREIGN KEY (`deliveryOrderID`) REFERENCES `deliveryorder` (`deliveryOrderID`),
  ADD CONSTRAINT `deliveryproduct_ibfk_2` FOREIGN KEY (`orderID`) REFERENCES `placedorder` (`orderID`);

--
-- 資料表的限制式 `deliveryrawmaterial`
--
ALTER TABLE `deliveryrawmaterial`
  ADD CONSTRAINT `deliveryrawmaterial_ibfk_1` FOREIGN KEY (`deliveryOrderID`) REFERENCES `deliveryorder` (`deliveryOrderID`),
  ADD CONSTRAINT `deliveryrawmaterial_ibfk_2` FOREIGN KEY (`materialID`) REFERENCES `rawmaterial` (`materialID`);

--
-- 資料表的限制式 `deliveryrequest`
--
ALTER TABLE `deliveryrequest`
  ADD CONSTRAINT `deliveryrequest_ibfk_1` FOREIGN KEY (`orderID`) REFERENCES `placedorder` (`orderID`);

--
-- 資料表的限制式 `demonstrationvideo`
--
ALTER TABLE `demonstrationvideo`
  ADD CONSTRAINT `demonstrationvideo_ibfk_1` FOREIGN KEY (`departmentID`) REFERENCES `department` (`deptID`);

--
-- 資料表的限制式 `file`
--
ALTER TABLE `file`
  ADD CONSTRAINT `file_ibfk_1` FOREIGN KEY (`recordPerson`) REFERENCES `staff` (`staffID`);

--
-- 資料表的限制式 `itsupportrequest`
--
ALTER TABLE `itsupportrequest`
  ADD CONSTRAINT `itsupportrequest_ibfk_1` FOREIGN KEY (`staffID`) REFERENCES `staff` (`staffID`),
  ADD CONSTRAINT `itsupportrequest_ibfk_2` FOREIGN KEY (`staffAssigned`) REFERENCES `staff` (`staffID`);

--
-- 資料表的限制式 `materialdemand`
--
ALTER TABLE `materialdemand`
  ADD CONSTRAINT `fk_materialdemand` FOREIGN KEY (`materialID`) REFERENCES `rawmaterial` (`materialID`);

--
-- 資料表的限制式 `orderproduct`
--
ALTER TABLE `orderproduct`
  ADD CONSTRAINT `orderproduct_ibfk_1` FOREIGN KEY (`orderID`) REFERENCES `placedorder` (`orderID`),
  ADD CONSTRAINT `orderproduct_ibfk_2` FOREIGN KEY (`productID`) REFERENCES `product` (`productID`);

--
-- 資料表的限制式 `payment`
--
ALTER TABLE `payment`
  ADD CONSTRAINT `payment_ibfk_1` FOREIGN KEY (`orderID`) REFERENCES `placedorder` (`orderID`),
  ADD CONSTRAINT `payment_ibfk_2` FOREIGN KEY (`paymentMethodID`) REFERENCES `paymentmethod` (`paymentMethodID`);

--
-- 資料表的限制式 `paymentdetails`
--
ALTER TABLE `paymentdetails`
  ADD CONSTRAINT `paymentdetails_ibfk_1` FOREIGN KEY (`customerID`) REFERENCES `customer` (`customerID`),
  ADD CONSTRAINT `paymentdetails_ibfk_2` FOREIGN KEY (`paymentMethodID`) REFERENCES `paymentmethod` (`paymentMethodID`);

--
-- 資料表的限制式 `placedorder`
--
ALTER TABLE `placedorder`
  ADD CONSTRAINT `placedorder_ibfk_1` FOREIGN KEY (`quotationID`) REFERENCES `quotation` (`quotationID`),
  ADD CONSTRAINT `placedorder_ibfk_2` FOREIGN KEY (`customerID`) REFERENCES `customer` (`customerID`);

--
-- 資料表的限制式 `product`
--
ALTER TABLE `product`
  ADD CONSTRAINT `product_ibfk_1` FOREIGN KEY (`parentProductID`) REFERENCES `product` (`productID`);

--
-- 資料表的限制式 `productattributeversion`
--
ALTER TABLE `productattributeversion`
  ADD CONSTRAINT `productattributeversion_ibfk_1` FOREIGN KEY (`productID`) REFERENCES `product` (`productID`),
  ADD CONSTRAINT `productattributeversion_ibfk_2` FOREIGN KEY (`attributeID`) REFERENCES `productattribute` (`attributeID`),
  ADD CONSTRAINT `productattributeversion_ibfk_3` FOREIGN KEY (`fileID`) REFERENCES `file` (`fileID`),
  ADD CONSTRAINT `productattributeversion_ibfk_4` FOREIGN KEY (`recordPerson`) REFERENCES `staff` (`staffID`);

--
-- 資料表的限制式 `productdelete`
--
ALTER TABLE `productdelete`
  ADD CONSTRAINT `productdelete_ibfk_1` FOREIGN KEY (`productID`) REFERENCES `product` (`productID`),
  ADD CONSTRAINT `productdelete_ibfk_2` FOREIGN KEY (`staffID`) REFERENCES `staff` (`staffID`);

--
-- 資料表的限制式 `productmaterialversion`
--
ALTER TABLE `productmaterialversion`
  ADD CONSTRAINT `productmaterialversion_ibfk_1` FOREIGN KEY (`productID`) REFERENCES `product` (`productID`),
  ADD CONSTRAINT `productmaterialversion_ibfk_2` FOREIGN KEY (`materialID`) REFERENCES `rawmaterial` (`materialID`),
  ADD CONSTRAINT `productmaterialversion_ibfk_3` FOREIGN KEY (`recordPerson`) REFERENCES `staff` (`staffID`);

--
-- 資料表的限制式 `projecttask`
--
ALTER TABLE `projecttask`
  ADD CONSTRAINT `projecttask_ibfk_1` FOREIGN KEY (`projectID`) REFERENCES `project` (`projectID`),
  ADD CONSTRAINT `projecttask_ibfk_2` FOREIGN KEY (`taskID`) REFERENCES `task` (`taskID`),
  ADD CONSTRAINT `projecttask_ibfk_3` FOREIGN KEY (`departmentID`) REFERENCES `department` (`deptID`);

--
-- 資料表的限制式 `projectteam`
--
ALTER TABLE `projectteam`
  ADD CONSTRAINT `projectteam_ibfk_1` FOREIGN KEY (`projectID`) REFERENCES `project` (`projectID`),
  ADD CONSTRAINT `projectteam_ibfk_2` FOREIGN KEY (`staffID`) REFERENCES `staff` (`staffID`);

--
-- 資料表的限制式 `quotation`
--
ALTER TABLE `quotation`
  ADD CONSTRAINT `quotation_ibfk_1` FOREIGN KEY (`customerID`) REFERENCES `customer` (`customerID`);

--
-- 資料表的限制式 `quotationproduct`
--
ALTER TABLE `quotationproduct`
  ADD CONSTRAINT `quotationproduct_ibfk_1` FOREIGN KEY (`quotationID`) REFERENCES `quotation` (`quotationID`),
  ADD CONSTRAINT `quotationproduct_ibfk_2` FOREIGN KEY (`productID`) REFERENCES `product` (`productID`);

--
-- 資料表的限制式 `refund`
--
ALTER TABLE `refund`
  ADD CONSTRAINT `fk_customerID` FOREIGN KEY (`customerID`) REFERENCES `customer` (`customerID`),
  ADD CONSTRAINT `fk_orderID` FOREIGN KEY (`orderID`) REFERENCES `placedorder` (`orderID`),
  ADD CONSTRAINT `fk_staff` FOREIGN KEY (`staffAssigned`) REFERENCES `staff` (`staffID`);

--
-- 資料表的限制式 `restockrequest`
--
ALTER TABLE `restockrequest`
  ADD CONSTRAINT `restockrequest_ibfk_1` FOREIGN KEY (`materialID`) REFERENCES `rawmaterial` (`materialID`) ON DELETE CASCADE,
  ADD CONSTRAINT `restockrequest_ibfk_2` FOREIGN KEY (`supplierID`) REFERENCES `supplier` (`supplierID`);

--
-- 資料表的限制式 `staff`
--
ALTER TABLE `staff`
  ADD CONSTRAINT `staff_ibfk_1` FOREIGN KEY (`departmentID`) REFERENCES `department` (`deptID`);

--
-- 資料表的限制式 `staffsystemaccessright`
--
ALTER TABLE `staffsystemaccessright`
  ADD CONSTRAINT `staffsystemaccessright_ibfk_1` FOREIGN KEY (`staffID`) REFERENCES `staff` (`staffID`),
  ADD CONSTRAINT `staffsystemaccessright_ibfk_2` FOREIGN KEY (`systemFunctionID`) REFERENCES `systemfunction` (`systemFunctionID`);

--
-- 資料表的限制式 `systemfeedback`
--
ALTER TABLE `systemfeedback`
  ADD CONSTRAINT `systemfeedback_ibfk_1` FOREIGN KEY (`staffID`) REFERENCES `staff` (`staffID`),
  ADD CONSTRAINT `systemfeedback_ibfk_2` FOREIGN KEY (`systemID`) REFERENCES `itsystem` (`systemID`);

--
-- 資料表的限制式 `systemfeedbackaspectrating`
--
ALTER TABLE `systemfeedbackaspectrating`
  ADD CONSTRAINT `systemfeedbackaspectrating_ibfk_1` FOREIGN KEY (`systemFeedbackID`) REFERENCES `systemfeedback` (`systemFeedbackID`);

--
-- 資料表的限制式 `systemfunction`
--
ALTER TABLE `systemfunction`
  ADD CONSTRAINT `systemfunction_ibfk_1` FOREIGN KEY (`systemID`) REFERENCES `itsystem` (`systemID`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
