-- phpMyAdmin SQL Dump
-- version 4.7.4
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: 24 Okt 2017 pada 15.52
-- Versi Server: 10.1.26-MariaDB
-- PHP Version: 7.1.9

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `projekppk`
--

-- --------------------------------------------------------

--
-- Struktur dari tabel `penduduk`
--

CREATE TABLE `penduduk` (
  `NIK` varchar(5) NOT NULL,
  `No_kk` varchar(5) NOT NULL,
  `nama` varchar(25) NOT NULL,
  `alamat` varchar(30) NOT NULL,
  `tempat_lahir` varchar(15) NOT NULL,
  `tanggal_lahir` varchar(15) NOT NULL,
  `tahun_lahir` int(5) NOT NULL,
  `pekerjaan` varchar(15) NOT NULL,
  `status` varchar(6) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data untuk tabel `penduduk`
--

INSERT INTO `penduduk` (`NIK`, `No_kk`, `nama`, `alamat`, `tempat_lahir`, `tanggal_lahir`, `tahun_lahir`, `pekerjaan`, `status`) VALUES
('1', '1', 'tian', 'borobudur', 'kediri', '29/01', 1999, 'mahasiswa', 'kaya'),
('10', '2', 'testing', 'test', 'Gresik', '23/12', 1996, 'Mahasiswa', 'Miskin'),
('2', '2', 'kacong', 'joyogrand', 'sampang', '20/01', 1997, 'mahasiswa', 'miskin'),
('24', '20', 'anak baru pindah', 'kerto', 'surabaya', '24/12', 1990, 'tukang nasi gor', 'Miskin'),
('3', '3', 'dio', 'suhat', 'jember', '26/01', 1989, 'pengushaa', 'Miskin'),
('4', '4', 'wahyu', 'borobudur', 'kediri', '24/01', 1990, 'mahasiswa', 'kaya'),
('5', '5', 'jelang', 'melati', 'jombang', '29/02', 1999, 'mahasiswa', 'kaya');

-- --------------------------------------------------------

--
-- Struktur dari tabel `status`
--

CREATE TABLE `status` (
  `status` varchar(9) NOT NULL,
  `jumlah` int(20) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data untuk tabel `status`
--

INSERT INTO `status` (`status`, `jumlah`) VALUES
('Kelahiran', 0),
('Meninggal', 3);

--
-- Indexes for dumped tables
--

--
-- Indexes for table `penduduk`
--
ALTER TABLE `penduduk`
  ADD PRIMARY KEY (`NIK`);

--
-- Indexes for table `status`
--
ALTER TABLE `status`
  ADD PRIMARY KEY (`status`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
