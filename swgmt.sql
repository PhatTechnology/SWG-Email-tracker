-- phpMyAdmin SQL Dump
-- version 5.1.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Sep 16, 2022 at 10:37 AM
-- Server version: 10.4.20-MariaDB
-- PHP Version: 8.0.8

CREATE DATABASE  IF NOT EXISTS `swgmt` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci */ /*!80016 DEFAULT ENCRYPTION='N' */;
USE `swgmt`;

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";



/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;


DROP TABLE IF EXISTS `sales`;

CREATE TABLE `sales` (
  `uid` double NOT NULL,
  `purchaser` text NOT NULL,
  `PurchasePrice` double NOT NULL,
  `PurchaseDate` text NOT NULL,
  `vendorName` text NOT NULL,
  `saleItem` text NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

ALTER TABLE `sales`
  ADD PRIMARY KEY (`uid`);
COMMIT;

DROP TABLE IF EXISTS `bankTips`;

CREATE TABLE `bankTips` (
  `uid` double NOT NULL,
    `tipSender` text NOT NULL,
  `tipAmount` text NOT NULL,
    `tipDate` text NOT NULL

) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

ALTER TABLE `bankTips`
  ADD PRIMARY KEY (`uid`);
COMMIT;



/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
