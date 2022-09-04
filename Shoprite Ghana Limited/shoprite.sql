-- phpMyAdmin SQL Dump
-- version 5.2.0
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Sep 04, 2022 at 05:57 PM
-- Server version: 10.4.24-MariaDB
-- PHP Version: 7.4.29

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `shoprite`
--

-- --------------------------------------------------------

--
-- Table structure for table `categories`
--

CREATE TABLE `categories` (
  `id` int(5) NOT NULL,
  `name` varchar(20) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `categories`
--

INSERT INTO `categories` (`id`, `name`) VALUES
(1, 'Oil'),
(2, 'Lotion'),
(3, 'Soap'),
(4, 'Soft Drink'),
(5, 'Wine'),
(6, 'Pastries');

-- --------------------------------------------------------

--
-- Table structure for table `products`
--

CREATE TABLE `products` (
  `id` int(5) NOT NULL,
  `price` double NOT NULL,
  `name` varchar(20) NOT NULL,
  `reorderlevel` int(5) DEFAULT NULL,
  `categoryId` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `products`
--

INSERT INTO `products` (`id`, `price`, `name`, `reorderlevel`, `categoryId`) VALUES
(1, 45.3, 'Gino', 50, 1),
(2, 300, 'Coup de Noodel', 50, 5),
(3, 32.1, 'Charde de Loom', 29, 5),
(4, 40, 'Geisha', 30, 3),
(5, 25.3, 'Apple Pie', 350, 6);

-- --------------------------------------------------------

--
-- Table structure for table `sales`
--

CREATE TABLE `sales` (
  `id` int(5) NOT NULL,
  `productId` int(11) DEFAULT NULL,
  `quantity` int(11) DEFAULT NULL,
  `amount` double DEFAULT NULL,
  `discount` double DEFAULT NULL,
  `tillId` int(11) DEFAULT NULL,
  `attendantId` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `sales`
--

INSERT INTO `sales` (`id`, `productId`, `quantity`, `amount`, `discount`, `tillId`, `attendantId`) VALUES
(2, 1, 2, 40.01, 0.1, 1, 2),
(3, 3, 3, 0, 0.2, 1, 2),
(4, 1, 7, 253.68, 0.2, 1, 2),
(5, 1, 3, 122.31, 0.1, 1, 2),
(6, 3, 4, 0, 0.3, 1, 2),
(7, 1, 3, 135.9, 0, 1, 2),
(8, 1, 2, 90.6, 0, 1, 2),
(9, 1, 2, 90.6, 0, 1, 2),
(10, 1, 3, 135.9, 0, 1, 2),
(11, 1, 3, 135.9, 0, 1, 2),
(12, 1, 3, 135.9, 0, 1, 2),
(13, 5, 4, 101.2, 0, 1, 2);

-- --------------------------------------------------------

--
-- Table structure for table `stock`
--

CREATE TABLE `stock` (
  `id` int(5) NOT NULL,
  `categoryId` int(11) DEFAULT NULL,
  `quantity` int(5) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `stock`
--

INSERT INTO `stock` (`id`, `categoryId`, `quantity`) VALUES
(1, 1, 500),
(2, 5, 300);

-- --------------------------------------------------------

--
-- Table structure for table `tills`
--

CREATE TABLE `tills` (
  `id` int(5) NOT NULL,
  `attendantId` int(11) DEFAULT NULL,
  `opentime` datetime DEFAULT NULL,
  `closedtime` datetime DEFAULT NULL,
  `status` enum('open','closed') DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `tills`
--

INSERT INTO `tills` (`id`, `attendantId`, `opentime`, `closedtime`, `status`) VALUES
(1, 2, '2022-08-28 22:17:35', '2022-08-29 22:17:35', 'open');

-- --------------------------------------------------------

--
-- Table structure for table `users`
--

CREATE TABLE `users` (
  `id` int(6) NOT NULL,
  `username` varchar(20) NOT NULL,
  `email` varchar(20) DEFAULT NULL,
  `password` varchar(300) NOT NULL,
  `fullname` varchar(50) NOT NULL,
  `role` enum('admin','attendant') NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `users`
--

INSERT INTO `users` (`id`, `username`, `email`, `password`, `fullname`, `role`) VALUES
(1, 'russell', 'russellquaicoo1@gmai', '827ccb0eea8a706c4c34a16891f84e7b', 'Russell Quaicoo', 'admin'),
(2, 'naadjels', 'pinkie@gmail.com', '827ccb0eea8a706c4c34a16891f84e7b', 'Alexis Addo', 'attendant'),
(3, 'abena', 'abena@mail.com', '9ec2658e019628e1fb2527bb7374cf88', 'Abena Bempomaa', 'admin'),
(4, 'abena', 'abena@gmail.com', '9ec2658e019628e1fb2527bb7374cf88', 'Abena Bempomaa', 'admin'),
(5, 'kwabs', 'kwabs@ug.edu.gh', '00d450d907549b34983bbb5e24777e94', 'Michael Koranteng', 'admin'),
(7, '', '', 'f9892b0092d2fc81fa7b50d6ad6f85a2', '', ''),
(8, 'Kofi', 'kofi@gmail.com', 'xuibodb', 'Kofa Attah', 'attendant');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `categories`
--
ALTER TABLE `categories`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `products`
--
ALTER TABLE `products`
  ADD PRIMARY KEY (`id`),
  ADD KEY `categoryId` (`categoryId`);

--
-- Indexes for table `sales`
--
ALTER TABLE `sales`
  ADD PRIMARY KEY (`id`),
  ADD KEY `productId` (`productId`),
  ADD KEY `tillId` (`tillId`),
  ADD KEY `attendantId` (`attendantId`);

--
-- Indexes for table `stock`
--
ALTER TABLE `stock`
  ADD PRIMARY KEY (`id`),
  ADD KEY `categoryId` (`categoryId`);

--
-- Indexes for table `tills`
--
ALTER TABLE `tills`
  ADD PRIMARY KEY (`id`),
  ADD KEY `attendantId` (`attendantId`);

--
-- Indexes for table `users`
--
ALTER TABLE `users`
  ADD PRIMARY KEY (`id`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `categories`
--
ALTER TABLE `categories`
  MODIFY `id` int(5) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;

--
-- AUTO_INCREMENT for table `products`
--
ALTER TABLE `products`
  MODIFY `id` int(5) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- AUTO_INCREMENT for table `sales`
--
ALTER TABLE `sales`
  MODIFY `id` int(5) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=14;

--
-- AUTO_INCREMENT for table `stock`
--
ALTER TABLE `stock`
  MODIFY `id` int(5) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT for table `tills`
--
ALTER TABLE `tills`
  MODIFY `id` int(5) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT for table `users`
--
ALTER TABLE `users`
  MODIFY `id` int(6) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=9;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `products`
--
ALTER TABLE `products`
  ADD CONSTRAINT `products_ibfk_1` FOREIGN KEY (`categoryId`) REFERENCES `categories` (`id`);

--
-- Constraints for table `sales`
--
ALTER TABLE `sales`
  ADD CONSTRAINT `sales_ibfk_1` FOREIGN KEY (`productId`) REFERENCES `products` (`id`),
  ADD CONSTRAINT `sales_ibfk_2` FOREIGN KEY (`tillId`) REFERENCES `tills` (`id`),
  ADD CONSTRAINT `sales_ibfk_3` FOREIGN KEY (`attendantId`) REFERENCES `users` (`id`);

--
-- Constraints for table `stock`
--
ALTER TABLE `stock`
  ADD CONSTRAINT `stock_ibfk_1` FOREIGN KEY (`categoryId`) REFERENCES `categories` (`id`);

--
-- Constraints for table `tills`
--
ALTER TABLE `tills`
  ADD CONSTRAINT `tills_ibfk_1` FOREIGN KEY (`attendantId`) REFERENCES `users` (`id`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
