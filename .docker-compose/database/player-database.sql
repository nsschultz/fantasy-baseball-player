--
-- PostgreSQL database dump
--

-- Dumped from database version 14.1
-- Dumped by pg_dump version 14.2

-- Started on 2024-04-19 19:00:46 UTC

SET statement_timeout = 0;
SET lock_timeout = 0;
SET idle_in_transaction_session_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SELECT pg_catalog.set_config('search_path', '', false);
SET check_function_bodies = false;
SET xmloption = content;
SET client_min_messages = warning;
SET row_security = off;

SET default_tablespace = '';

SET default_table_access_method = heap;

--
-- TOC entry 209 (class 1259 OID 16385)
-- Name: BattingStats; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."BattingStats" (
    "PlayerId" uuid NOT NULL,
    "StatsType" integer NOT NULL,
    "AtBats" integer NOT NULL,
    "Runs" integer NOT NULL,
    "Hits" integer NOT NULL,
    "Doubles" integer NOT NULL,
    "Triples" integer NOT NULL,
    "HomeRuns" integer NOT NULL,
    "RunsBattedIn" integer NOT NULL,
    "BaseOnBalls" integer NOT NULL,
    "StrikeOuts" integer NOT NULL,
    "StolenBases" integer NOT NULL,
    "CaughtStealing" integer NOT NULL,
    "Power" double precision NOT NULL,
    "Speed" double precision NOT NULL
);


ALTER TABLE public."BattingStats" OWNER TO postgres;

--
-- TOC entry 210 (class 1259 OID 16388)
-- Name: LeagueStatuses; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."LeagueStatuses" (
    "PlayerId" uuid NOT NULL,
    "LeagueId" integer NOT NULL,
    "LeagueStatus" integer NOT NULL
);


ALTER TABLE public."LeagueStatuses" OWNER TO postgres;

--
-- TOC entry 211 (class 1259 OID 16391)
-- Name: PitchingStats; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."PitchingStats" (
    "PlayerId" uuid NOT NULL,
    "StatsType" integer NOT NULL,
    "Wins" integer NOT NULL,
    "Losses" integer NOT NULL,
    "QualityStarts" integer NOT NULL,
    "Saves" integer NOT NULL,
    "BlownSaves" integer NOT NULL,
    "Holds" integer NOT NULL,
    "InningsPitched" double precision NOT NULL,
    "HitsAllowed" integer NOT NULL,
    "EarnedRuns" integer NOT NULL,
    "HomeRunsAllowed" integer NOT NULL,
    "BaseOnBallsAllowed" integer NOT NULL,
    "StrikeOuts" integer NOT NULL,
    "FlyBallRate" double precision NOT NULL,
    "GroundBallRate" double precision NOT NULL
);


ALTER TABLE public."PitchingStats" OWNER TO postgres;

--
-- TOC entry 212 (class 1259 OID 16394)
-- Name: PlayerPositionEntity; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."PlayerPositionEntity" (
    "PlayerId" uuid NOT NULL,
    "PositionCode" character varying(4) NOT NULL
);


ALTER TABLE public."PlayerPositionEntity" OWNER TO postgres;

--
-- TOC entry 213 (class 1259 OID 16397)
-- Name: Players; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."Players" (
    "Id" uuid NOT NULL,
    "Type" integer NOT NULL,
    "FirstName" character varying(20),
    "LastName" character varying(20),
    "Age" integer NOT NULL,
    "Team" character varying(3),
    "Status" integer NOT NULL,
    "AverageDraftPickMin" integer NOT NULL,
    "AverageDraftPick" double precision NOT NULL,
    "MlbAmId" integer NOT NULL,
    "Reliability" double precision NOT NULL,
    "MayberryMethod" integer NOT NULL,
    "AverageDraftPickMax" integer DEFAULT 0 NOT NULL
);


ALTER TABLE public."Players" OWNER TO postgres;

--
-- TOC entry 214 (class 1259 OID 16401)
-- Name: Teams; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."Teams" (
    "Code" character varying(3) NOT NULL,
    "AlternativeCode" character varying(3),
    "LeagueId" character varying(2),
    "City" character varying(20),
    "Nickname" character varying(20)
);


ALTER TABLE public."Teams" OWNER TO postgres;

--
-- TOC entry 215 (class 1259 OID 16404)
-- Name: __EFMigrationsHistory; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."__EFMigrationsHistory" (
    "MigrationId" character varying(150) NOT NULL,
    "ProductVersion" character varying(32) NOT NULL
);


ALTER TABLE public."__EFMigrationsHistory" OWNER TO postgres;

--
-- TOC entry 3351 (class 0 OID 16385)
-- Dependencies: 209
-- Data for Name: BattingStats; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public."BattingStats" ("PlayerId", "StatsType", "AtBats", "Runs", "Hits", "Doubles", "Triples", "HomeRuns", "RunsBattedIn", "BaseOnBalls", "StrikeOuts", "StolenBases", "CaughtStealing", "Power", "Speed") VALUES ('083931a0-68ac-4d5c-a045-78ecf437a444', 1, 71, 7, 18, 5, 0, 2, 11, 11, 15, 2, 0, 110, 56);
INSERT INTO public."BattingStats" ("PlayerId", "StatsType", "AtBats", "Runs", "Hits", "Doubles", "Triples", "HomeRuns", "RunsBattedIn", "BaseOnBalls", "StrikeOuts", "StolenBases", "CaughtStealing", "Power", "Speed") VALUES ('20e17640-9552-490c-b90f-652395ac6951', 1, 68, 11, 15, 3, 2, 2, 9, 12, 14, 4, 1, 114, 93);
INSERT INTO public."BattingStats" ("PlayerId", "StatsType", "AtBats", "Runs", "Hits", "Doubles", "Triples", "HomeRuns", "RunsBattedIn", "BaseOnBalls", "StrikeOuts", "StolenBases", "CaughtStealing", "Power", "Speed") VALUES ('083931a0-68ac-4d5c-a045-78ecf437a444', 2, 516, 76, 137, 25, 5, 23, 70, 51, 127, 8, 1, 115, 101);
INSERT INTO public."BattingStats" ("PlayerId", "StatsType", "AtBats", "Runs", "Hits", "Doubles", "Triples", "HomeRuns", "RunsBattedIn", "BaseOnBalls", "StrikeOuts", "StolenBases", "CaughtStealing", "Power", "Speed") VALUES ('35f2c7d4-799c-4f05-9313-f80e102140ec', 1, 53, 7, 14, 0, 0, 2, 4, 4, 16, 0, 1, 69, 61);
INSERT INTO public."BattingStats" ("PlayerId", "StatsType", "AtBats", "Runs", "Hits", "Doubles", "Triples", "HomeRuns", "RunsBattedIn", "BaseOnBalls", "StrikeOuts", "StolenBases", "CaughtStealing", "Power", "Speed") VALUES ('3c88638b-291f-45f8-8bb2-a11d403604c5', 1, 61, 9, 20, 3, 0, 2, 12, 14, 10, 1, 1, 92, 58);
INSERT INTO public."BattingStats" ("PlayerId", "StatsType", "AtBats", "Runs", "Hits", "Doubles", "Triples", "HomeRuns", "RunsBattedIn", "BaseOnBalls", "StrikeOuts", "StolenBases", "CaughtStealing", "Power", "Speed") VALUES ('4707d3a6-35cc-4f86-88f3-122e83de82b9', 1, 37, 4, 10, 1, 1, 1, 4, 2, 14, 2, 0, 118, 90);
INSERT INTO public."BattingStats" ("PlayerId", "StatsType", "AtBats", "Runs", "Hits", "Doubles", "Triples", "HomeRuns", "RunsBattedIn", "BaseOnBalls", "StrikeOuts", "StolenBases", "CaughtStealing", "Power", "Speed") VALUES ('4947afdf-6d0d-4d36-a656-d1687789cfd8', 1, 48, 3, 9, 4, 1, 0, 3, 4, 15, 0, 0, 110, 67);
INSERT INTO public."BattingStats" ("PlayerId", "StatsType", "AtBats", "Runs", "Hits", "Doubles", "Triples", "HomeRuns", "RunsBattedIn", "BaseOnBalls", "StrikeOuts", "StolenBases", "CaughtStealing", "Power", "Speed") VALUES ('20e17640-9552-490c-b90f-652395ac6951', 2, 509, 70, 128, 24, 1, 12, 57, 58, 109, 28, 6, 74, 107);
INSERT INTO public."BattingStats" ("PlayerId", "StatsType", "AtBats", "Runs", "Hits", "Doubles", "Triples", "HomeRuns", "RunsBattedIn", "BaseOnBalls", "StrikeOuts", "StolenBases", "CaughtStealing", "Power", "Speed") VALUES ('2a601e7c-6dc3-48c6-b215-77f243da4ee6', 2, 26, 2, 5, 1, 0, 0, 2, 3, 6, 0, 0, 32, 73);
INSERT INTO public."BattingStats" ("PlayerId", "StatsType", "AtBats", "Runs", "Hits", "Doubles", "Triples", "HomeRuns", "RunsBattedIn", "BaseOnBalls", "StrikeOuts", "StolenBases", "CaughtStealing", "Power", "Speed") VALUES ('35f2c7d4-799c-4f05-9313-f80e102140ec', 2, 472, 70, 123, 24, 3, 20, 69, 35, 126, 12, 2, 115, 113);
INSERT INTO public."BattingStats" ("PlayerId", "StatsType", "AtBats", "Runs", "Hits", "Doubles", "Triples", "HomeRuns", "RunsBattedIn", "BaseOnBalls", "StrikeOuts", "StolenBases", "CaughtStealing", "Power", "Speed") VALUES ('51a61d66-e85b-480a-bbf8-995dd0436f29', 1, 59, 16, 23, 4, 0, 4, 15, 9, 15, 1, 0, 181, 72);
INSERT INTO public."BattingStats" ("PlayerId", "StatsType", "AtBats", "Runs", "Hits", "Doubles", "Triples", "HomeRuns", "RunsBattedIn", "BaseOnBalls", "StrikeOuts", "StolenBases", "CaughtStealing", "Power", "Speed") VALUES ('3c88638b-291f-45f8-8bb2-a11d403604c5', 2, 461, 89, 127, 24, 1, 33, 86, 106, 96, 9, 3, 145, 70);
INSERT INTO public."BattingStats" ("PlayerId", "StatsType", "AtBats", "Runs", "Hits", "Doubles", "Triples", "HomeRuns", "RunsBattedIn", "BaseOnBalls", "StrikeOuts", "StolenBases", "CaughtStealing", "Power", "Speed") VALUES ('4707d3a6-35cc-4f86-88f3-122e83de82b9', 2, 286, 33, 65, 15, 2, 11, 40, 42, 112, 8, 4, 133, 82);
INSERT INTO public."BattingStats" ("PlayerId", "StatsType", "AtBats", "Runs", "Hits", "Doubles", "Triples", "HomeRuns", "RunsBattedIn", "BaseOnBalls", "StrikeOuts", "StolenBases", "CaughtStealing", "Power", "Speed") VALUES ('488e88e9-2d20-4a48-9edf-dbdbf21f429c', 2, 28, 2, 6, 1, 0, 0, 2, 1, 6, 0, 0, 29, 84);
INSERT INTO public."BattingStats" ("PlayerId", "StatsType", "AtBats", "Runs", "Hits", "Doubles", "Triples", "HomeRuns", "RunsBattedIn", "BaseOnBalls", "StrikeOuts", "StolenBases", "CaughtStealing", "Power", "Speed") VALUES ('4947afdf-6d0d-4d36-a656-d1687789cfd8', 2, 414, 49, 104, 20, 1, 16, 43, 33, 109, 9, 4, 103, 81);
INSERT INTO public."BattingStats" ("PlayerId", "StatsType", "AtBats", "Runs", "Hits", "Doubles", "Triples", "HomeRuns", "RunsBattedIn", "BaseOnBalls", "StrikeOuts", "StolenBases", "CaughtStealing", "Power", "Speed") VALUES ('51a61d66-e85b-480a-bbf8-995dd0436f29', 2, 459, 67, 126, 26, 0, 20, 63, 49, 118, 3, 0, 114, 97);
INSERT INTO public."BattingStats" ("PlayerId", "StatsType", "AtBats", "Runs", "Hits", "Doubles", "Triples", "HomeRuns", "RunsBattedIn", "BaseOnBalls", "StrikeOuts", "StolenBases", "CaughtStealing", "Power", "Speed") VALUES ('5b92e19b-3bfd-40dd-9546-73cccede2638', 1, 67, 12, 19, 2, 1, 0, 1, 7, 8, 0, 0, 37, 74);
INSERT INTO public."BattingStats" ("PlayerId", "StatsType", "AtBats", "Runs", "Hits", "Doubles", "Triples", "HomeRuns", "RunsBattedIn", "BaseOnBalls", "StrikeOuts", "StolenBases", "CaughtStealing", "Power", "Speed") VALUES ('5b92e19b-3bfd-40dd-9546-73cccede2638', 2, 528, 72, 173, 27, 2, 7, 55, 40, 40, 3, 2, 54, 59);
INSERT INTO public."BattingStats" ("PlayerId", "StatsType", "AtBats", "Runs", "Hits", "Doubles", "Triples", "HomeRuns", "RunsBattedIn", "BaseOnBalls", "StrikeOuts", "StolenBases", "CaughtStealing", "Power", "Speed") VALUES ('6102c1c5-0022-4a73-93cd-ead484f4e735', 2, 415, 48, 99, 24, 2, 8, 59, 33, 62, 8, 2, 72, 84);
INSERT INTO public."BattingStats" ("PlayerId", "StatsType", "AtBats", "Runs", "Hits", "Doubles", "Triples", "HomeRuns", "RunsBattedIn", "BaseOnBalls", "StrikeOuts", "StolenBases", "CaughtStealing", "Power", "Speed") VALUES ('61a0a509-7d45-489b-a6be-2e19700173ac', 2, 440, 81, 117, 24, 1, 14, 56, 67, 119, 17, 2, 99, 104);
INSERT INTO public."BattingStats" ("PlayerId", "StatsType", "AtBats", "Runs", "Hits", "Doubles", "Triples", "HomeRuns", "RunsBattedIn", "BaseOnBalls", "StrikeOuts", "StolenBases", "CaughtStealing", "Power", "Speed") VALUES ('647cdd37-00ae-46b6-b69d-7a76174f71b3', 2, 464, 60, 126, 32, 9, 5, 53, 44, 50, 8, 1, 77, 111);
INSERT INTO public."BattingStats" ("PlayerId", "StatsType", "AtBats", "Runs", "Hits", "Doubles", "Triples", "HomeRuns", "RunsBattedIn", "BaseOnBalls", "StrikeOuts", "StolenBases", "CaughtStealing", "Power", "Speed") VALUES ('6d56f922-c389-4716-950b-2fa0073cda78', 2, 484, 81, 127, 24, 6, 23, 68, 53, 141, 11, 3, 131, 116);
INSERT INTO public."BattingStats" ("PlayerId", "StatsType", "AtBats", "Runs", "Hits", "Doubles", "Triples", "HomeRuns", "RunsBattedIn", "BaseOnBalls", "StrikeOuts", "StolenBases", "CaughtStealing", "Power", "Speed") VALUES ('7106b85c-47e2-4e4f-95a3-2e0d72f252e4', 2, 437, 58, 112, 19, 3, 6, 41, 41, 69, 17, 6, 56, 107);
INSERT INTO public."BattingStats" ("PlayerId", "StatsType", "AtBats", "Runs", "Hits", "Doubles", "Triples", "HomeRuns", "RunsBattedIn", "BaseOnBalls", "StrikeOuts", "StolenBases", "CaughtStealing", "Power", "Speed") VALUES ('780e4821-a9ab-459b-90d9-06a5308cd24f', 2, 272, 32, 61, 11, 0, 17, 44, 27, 80, 0, 0, 136, 83);
INSERT INTO public."BattingStats" ("PlayerId", "StatsType", "AtBats", "Runs", "Hits", "Doubles", "Triples", "HomeRuns", "RunsBattedIn", "BaseOnBalls", "StrikeOuts", "StolenBases", "CaughtStealing", "Power", "Speed") VALUES ('79442841-8e3a-40a2-a08e-77a4daeb3969', 2, 455, 63, 111, 23, 1, 18, 60, 52, 151, 4, 3, 117, 52);
INSERT INTO public."BattingStats" ("PlayerId", "StatsType", "AtBats", "Runs", "Hits", "Doubles", "Triples", "HomeRuns", "RunsBattedIn", "BaseOnBalls", "StrikeOuts", "StolenBases", "CaughtStealing", "Power", "Speed") VALUES ('82ce40a9-45cd-453c-ab03-0fcfba2b62d9', 2, 476, 62, 123, 22, 1, 17, 64, 31, 103, 31, 8, 90, 107);
INSERT INTO public."BattingStats" ("PlayerId", "StatsType", "AtBats", "Runs", "Hits", "Doubles", "Triples", "HomeRuns", "RunsBattedIn", "BaseOnBalls", "StrikeOuts", "StolenBases", "CaughtStealing", "Power", "Speed") VALUES ('8372ff25-ff7f-4825-8960-d4e1206647a9', 2, 353, 49, 88, 23, 0, 18, 67, 35, 110, 0, 0, 143, 77);
INSERT INTO public."BattingStats" ("PlayerId", "StatsType", "AtBats", "Runs", "Hits", "Doubles", "Triples", "HomeRuns", "RunsBattedIn", "BaseOnBalls", "StrikeOuts", "StolenBases", "CaughtStealing", "Power", "Speed") VALUES ('89ef3592-b576-408a-829a-526aad713b95', 2, 81, 10, 19, 3, 0, 1, 7, 8, 22, 2, 1, 51, 94);
INSERT INTO public."BattingStats" ("PlayerId", "StatsType", "AtBats", "Runs", "Hits", "Doubles", "Triples", "HomeRuns", "RunsBattedIn", "BaseOnBalls", "StrikeOuts", "StolenBases", "CaughtStealing", "Power", "Speed") VALUES ('973e9c12-762b-4303-aea4-65bed4c4edd2', 2, 477, 83, 127, 31, 1, 20, 77, 60, 114, 5, 2, 118, 75);
INSERT INTO public."BattingStats" ("PlayerId", "StatsType", "AtBats", "Runs", "Hits", "Doubles", "Triples", "HomeRuns", "RunsBattedIn", "BaseOnBalls", "StrikeOuts", "StolenBases", "CaughtStealing", "Power", "Speed") VALUES ('9bd677e7-ba97-4bd7-89e8-5cf61dedba78', 2, 441, 78, 108, 27, 0, 24, 69, 67, 126, 1, 0, 140, 56);
INSERT INTO public."BattingStats" ("PlayerId", "StatsType", "AtBats", "Runs", "Hits", "Doubles", "Triples", "HomeRuns", "RunsBattedIn", "BaseOnBalls", "StrikeOuts", "StolenBases", "CaughtStealing", "Power", "Speed") VALUES ('6102c1c5-0022-4a73-93cd-ead484f4e735', 1, 59, 12, 21, 2, 0, 1, 7, 8, 11, 3, 1, 57, 78);
INSERT INTO public."BattingStats" ("PlayerId", "StatsType", "AtBats", "Runs", "Hits", "Doubles", "Triples", "HomeRuns", "RunsBattedIn", "BaseOnBalls", "StrikeOuts", "StolenBases", "CaughtStealing", "Power", "Speed") VALUES ('61a0a509-7d45-489b-a6be-2e19700173ac', 1, 39, 7, 13, 1, 0, 5, 11, 6, 8, 2, 0, 228, 58);
INSERT INTO public."BattingStats" ("PlayerId", "StatsType", "AtBats", "Runs", "Hits", "Doubles", "Triples", "HomeRuns", "RunsBattedIn", "BaseOnBalls", "StrikeOuts", "StolenBases", "CaughtStealing", "Power", "Speed") VALUES ('647cdd37-00ae-46b6-b69d-7a76174f71b3', 1, 66, 8, 17, 2, 0, 1, 5, 6, 7, 2, 2, 46, 67);
INSERT INTO public."BattingStats" ("PlayerId", "StatsType", "AtBats", "Runs", "Hits", "Doubles", "Triples", "HomeRuns", "RunsBattedIn", "BaseOnBalls", "StrikeOuts", "StolenBases", "CaughtStealing", "Power", "Speed") VALUES ('9d7257bc-e6a4-46bc-9200-91b73f437a82', 2, 220, 26, 48, 9, 0, 4, 24, 18, 62, 6, 1, 65, 78);
INSERT INTO public."BattingStats" ("PlayerId", "StatsType", "AtBats", "Runs", "Hits", "Doubles", "Triples", "HomeRuns", "RunsBattedIn", "BaseOnBalls", "StrikeOuts", "StolenBases", "CaughtStealing", "Power", "Speed") VALUES ('9e6a26f6-e752-43ae-9327-9092c51ce23a', 2, 464, 68, 124, 24, 2, 29, 66, 73, 130, 2, 1, 147, 62);
INSERT INTO public."BattingStats" ("PlayerId", "StatsType", "AtBats", "Runs", "Hits", "Doubles", "Triples", "HomeRuns", "RunsBattedIn", "BaseOnBalls", "StrikeOuts", "StolenBases", "CaughtStealing", "Power", "Speed") VALUES ('9ff79a30-3c1b-44c7-96a0-d33633c847df', 2, 422, 88, 118, 18, 0, 39, 94, 86, 139, 3, 1, 195, 53);
INSERT INTO public."BattingStats" ("PlayerId", "StatsType", "AtBats", "Runs", "Hits", "Doubles", "Triples", "HomeRuns", "RunsBattedIn", "BaseOnBalls", "StrikeOuts", "StolenBases", "CaughtStealing", "Power", "Speed") VALUES ('a75dadee-3586-4b2b-a371-2beffd6884a7', 2, 506, 77, 141, 31, 3, 22, 81, 61, 69, 23, 5, 106, 109);
INSERT INTO public."BattingStats" ("PlayerId", "StatsType", "AtBats", "Runs", "Hits", "Doubles", "Triples", "HomeRuns", "RunsBattedIn", "BaseOnBalls", "StrikeOuts", "StolenBases", "CaughtStealing", "Power", "Speed") VALUES ('ac0af2b7-e715-4a7f-a13d-d3a4ecc95555', 2, 525, 84, 149, 29, 1, 26, 80, 42, 140, 29, 8, 125, 110);
INSERT INTO public."BattingStats" ("PlayerId", "StatsType", "AtBats", "Runs", "Hits", "Doubles", "Triples", "HomeRuns", "RunsBattedIn", "BaseOnBalls", "StrikeOuts", "StolenBases", "CaughtStealing", "Power", "Speed") VALUES ('b5df2e6f-cccc-42f9-ac06-0a505fa724ae', 2, 328, 44, 75, 17, 1, 13, 42, 30, 108, 2, 0, 118, 91);
INSERT INTO public."BattingStats" ("PlayerId", "StatsType", "AtBats", "Runs", "Hits", "Doubles", "Triples", "HomeRuns", "RunsBattedIn", "BaseOnBalls", "StrikeOuts", "StolenBases", "CaughtStealing", "Power", "Speed") VALUES ('b6832adf-a496-4d5d-81e7-605030a0e028', 2, 26, 4, 6, 1, 0, 0, 3, 3, 6, 2, 0, 32, 114);
INSERT INTO public."BattingStats" ("PlayerId", "StatsType", "AtBats", "Runs", "Hits", "Doubles", "Triples", "HomeRuns", "RunsBattedIn", "BaseOnBalls", "StrikeOuts", "StolenBases", "CaughtStealing", "Power", "Speed") VALUES ('b850bfff-7f85-40a9-abff-28348754dbe9', 2, 220, 27, 51, 4, 1, 4, 19, 19, 65, 8, 1, 50, 127);
INSERT INTO public."BattingStats" ("PlayerId", "StatsType", "AtBats", "Runs", "Hits", "Doubles", "Triples", "HomeRuns", "RunsBattedIn", "BaseOnBalls", "StrikeOuts", "StolenBases", "CaughtStealing", "Power", "Speed") VALUES ('c4a6ee18-6242-4501-b781-b1b7f2b27e49', 2, 510, 85, 147, 34, 3, 21, 80, 27, 113, 21, 3, 119, 112);
INSERT INTO public."BattingStats" ("PlayerId", "StatsType", "AtBats", "Runs", "Hits", "Doubles", "Triples", "HomeRuns", "RunsBattedIn", "BaseOnBalls", "StrikeOuts", "StolenBases", "CaughtStealing", "Power", "Speed") VALUES ('cddc33ec-062e-4779-8057-75cd691c8abb', 2, 484, 68, 118, 27, 1, 23, 72, 53, 146, 5, 2, 129, 70);
INSERT INTO public."BattingStats" ("PlayerId", "StatsType", "AtBats", "Runs", "Hits", "Doubles", "Triples", "HomeRuns", "RunsBattedIn", "BaseOnBalls", "StrikeOuts", "StolenBases", "CaughtStealing", "Power", "Speed") VALUES ('cefdf564-6134-4030-b384-c3f6c9285114', 2, 281, 36, 71, 18, 1, 4, 32, 17, 65, 6, 4, 77, 83);
INSERT INTO public."BattingStats" ("PlayerId", "StatsType", "AtBats", "Runs", "Hits", "Doubles", "Triples", "HomeRuns", "RunsBattedIn", "BaseOnBalls", "StrikeOuts", "StolenBases", "CaughtStealing", "Power", "Speed") VALUES ('d3bcbd0a-4ad2-4604-b82b-c9620013260b', 2, 409, 46, 92, 12, 1, 6, 39, 39, 97, 21, 3, 48, 115);
INSERT INTO public."BattingStats" ("PlayerId", "StatsType", "AtBats", "Runs", "Hits", "Doubles", "Triples", "HomeRuns", "RunsBattedIn", "BaseOnBalls", "StrikeOuts", "StolenBases", "CaughtStealing", "Power", "Speed") VALUES ('d7f01c58-2f34-4bb3-8978-b4f0c4bfd54b', 2, 27, 3, 6, 1, 0, 0, 2, 2, 9, 0, 0, 36, 87);
INSERT INTO public."BattingStats" ("PlayerId", "StatsType", "AtBats", "Runs", "Hits", "Doubles", "Triples", "HomeRuns", "RunsBattedIn", "BaseOnBalls", "StrikeOuts", "StolenBases", "CaughtStealing", "Power", "Speed") VALUES ('da2190fb-0dbd-4edc-8d83-e7808266d630', 2, 288, 32, 71, 12, 1, 13, 33, 40, 99, 5, 3, 121, 64);
INSERT INTO public."BattingStats" ("PlayerId", "StatsType", "AtBats", "Runs", "Hits", "Doubles", "Triples", "HomeRuns", "RunsBattedIn", "BaseOnBalls", "StrikeOuts", "StolenBases", "CaughtStealing", "Power", "Speed") VALUES ('e3090c33-043b-4f89-a6ad-955b1b4b7c6d', 2, 411, 53, 109, 27, 2, 14, 60, 37, 106, 1, 1, 112, 48);
INSERT INTO public."BattingStats" ("PlayerId", "StatsType", "AtBats", "Runs", "Hits", "Doubles", "Triples", "HomeRuns", "RunsBattedIn", "BaseOnBalls", "StrikeOuts", "StolenBases", "CaughtStealing", "Power", "Speed") VALUES ('e45125f0-e38b-466a-bb06-62b1ccda2c5f', 2, 134, 16, 32, 10, 0, 2, 10, 14, 43, 2, 1, 95, 63);
INSERT INTO public."BattingStats" ("PlayerId", "StatsType", "AtBats", "Runs", "Hits", "Doubles", "Triples", "HomeRuns", "RunsBattedIn", "BaseOnBalls", "StrikeOuts", "StolenBases", "CaughtStealing", "Power", "Speed") VALUES ('efd41ad2-4941-4d97-aca4-751c971cf33e', 2, 458, 67, 125, 29, 4, 16, 61, 50, 85, 4, 0, 105, 96);
INSERT INTO public."BattingStats" ("PlayerId", "StatsType", "AtBats", "Runs", "Hits", "Doubles", "Triples", "HomeRuns", "RunsBattedIn", "BaseOnBalls", "StrikeOuts", "StolenBases", "CaughtStealing", "Power", "Speed") VALUES ('6d56f922-c389-4716-950b-2fa0073cda78', 1, 64, 11, 16, 1, 2, 4, 11, 6, 17, 4, 0, 154, 95);
INSERT INTO public."BattingStats" ("PlayerId", "StatsType", "AtBats", "Runs", "Hits", "Doubles", "Triples", "HomeRuns", "RunsBattedIn", "BaseOnBalls", "StrikeOuts", "StolenBases", "CaughtStealing", "Power", "Speed") VALUES ('7106b85c-47e2-4e4f-95a3-2e0d72f252e4', 1, 57, 11, 17, 2, 0, 0, 5, 5, 14, 3, 1, 34, 73);
INSERT INTO public."BattingStats" ("PlayerId", "StatsType", "AtBats", "Runs", "Hits", "Doubles", "Triples", "HomeRuns", "RunsBattedIn", "BaseOnBalls", "StrikeOuts", "StolenBases", "CaughtStealing", "Power", "Speed") VALUES ('fba56342-e6ef-41d1-a393-c62a85df7f92', 2, 495, 84, 137, 25, 1, 23, 83, 43, 112, 15, 3, 111, 99);
INSERT INTO public."BattingStats" ("PlayerId", "StatsType", "AtBats", "Runs", "Hits", "Doubles", "Triples", "HomeRuns", "RunsBattedIn", "BaseOnBalls", "StrikeOuts", "StolenBases", "CaughtStealing", "Power", "Speed") VALUES ('780e4821-a9ab-459b-90d9-06a5308cd24f', 1, 23, 1, 3, 0, 0, 1, 2, 1, 3, 0, 0, 63, 58);
INSERT INTO public."BattingStats" ("PlayerId", "StatsType", "AtBats", "Runs", "Hits", "Doubles", "Triples", "HomeRuns", "RunsBattedIn", "BaseOnBalls", "StrikeOuts", "StolenBases", "CaughtStealing", "Power", "Speed") VALUES ('79442841-8e3a-40a2-a08e-77a4daeb3969', 1, 63, 7, 22, 5, 0, 2, 11, 10, 17, 0, 1, 134, 56);
INSERT INTO public."BattingStats" ("PlayerId", "StatsType", "AtBats", "Runs", "Hits", "Doubles", "Triples", "HomeRuns", "RunsBattedIn", "BaseOnBalls", "StrikeOuts", "StolenBases", "CaughtStealing", "Power", "Speed") VALUES ('82ce40a9-45cd-453c-ab03-0fcfba2b62d9', 1, 54, 7, 14, 1, 0, 3, 11, 4, 16, 3, 0, 119, 72);
INSERT INTO public."BattingStats" ("PlayerId", "StatsType", "AtBats", "Runs", "Hits", "Doubles", "Triples", "HomeRuns", "RunsBattedIn", "BaseOnBalls", "StrikeOuts", "StolenBases", "CaughtStealing", "Power", "Speed") VALUES ('89ef3592-b576-408a-829a-526aad713b95', 1, 7, 2, 0, 0, 0, 0, 0, 2, 1, 0, 0, 0, 59);
INSERT INTO public."BattingStats" ("PlayerId", "StatsType", "AtBats", "Runs", "Hits", "Doubles", "Triples", "HomeRuns", "RunsBattedIn", "BaseOnBalls", "StrikeOuts", "StolenBases", "CaughtStealing", "Power", "Speed") VALUES ('973e9c12-762b-4303-aea4-65bed4c4edd2', 1, 67, 13, 21, 2, 0, 6, 19, 2, 15, 1, 1, 174, 56);
INSERT INTO public."BattingStats" ("PlayerId", "StatsType", "AtBats", "Runs", "Hits", "Doubles", "Triples", "HomeRuns", "RunsBattedIn", "BaseOnBalls", "StrikeOuts", "StolenBases", "CaughtStealing", "Power", "Speed") VALUES ('9bd677e7-ba97-4bd7-89e8-5cf61dedba78', 1, 52, 8, 13, 3, 0, 3, 9, 5, 11, 0, 0, 146, 51);
INSERT INTO public."BattingStats" ("PlayerId", "StatsType", "AtBats", "Runs", "Hits", "Doubles", "Triples", "HomeRuns", "RunsBattedIn", "BaseOnBalls", "StrikeOuts", "StolenBases", "CaughtStealing", "Power", "Speed") VALUES ('9d7257bc-e6a4-46bc-9200-91b73f437a82', 1, 43, 9, 13, 1, 0, 3, 11, 4, 10, 0, 0, 137, 57);
INSERT INTO public."BattingStats" ("PlayerId", "StatsType", "AtBats", "Runs", "Hits", "Doubles", "Triples", "HomeRuns", "RunsBattedIn", "BaseOnBalls", "StrikeOuts", "StolenBases", "CaughtStealing", "Power", "Speed") VALUES ('9e6a26f6-e752-43ae-9327-9092c51ce23a', 1, 62, 10, 15, 2, 0, 4, 8, 9, 19, 0, 0, 152, 57);
INSERT INTO public."BattingStats" ("PlayerId", "StatsType", "AtBats", "Runs", "Hits", "Doubles", "Triples", "HomeRuns", "RunsBattedIn", "BaseOnBalls", "StrikeOuts", "StolenBases", "CaughtStealing", "Power", "Speed") VALUES ('9ff79a30-3c1b-44c7-96a0-d33633c847df', 1, 58, 7, 11, 4, 0, 3, 9, 15, 17, 0, 0, 163, 46);
INSERT INTO public."BattingStats" ("PlayerId", "StatsType", "AtBats", "Runs", "Hits", "Doubles", "Triples", "HomeRuns", "RunsBattedIn", "BaseOnBalls", "StrikeOuts", "StolenBases", "CaughtStealing", "Power", "Speed") VALUES ('a75dadee-3586-4b2b-a371-2beffd6884a7', 1, 69, 13, 18, 3, 1, 3, 13, 1, 8, 0, 0, 110, 73);
INSERT INTO public."BattingStats" ("PlayerId", "StatsType", "AtBats", "Runs", "Hits", "Doubles", "Triples", "HomeRuns", "RunsBattedIn", "BaseOnBalls", "StrikeOuts", "StolenBases", "CaughtStealing", "Power", "Speed") VALUES ('ac0af2b7-e715-4a7f-a13d-d3a4ecc95555', 1, 63, 5, 12, 1, 0, 0, 5, 4, 22, 3, 0, 18, 64);
INSERT INTO public."BattingStats" ("PlayerId", "StatsType", "AtBats", "Runs", "Hits", "Doubles", "Triples", "HomeRuns", "RunsBattedIn", "BaseOnBalls", "StrikeOuts", "StolenBases", "CaughtStealing", "Power", "Speed") VALUES ('b5df2e6f-cccc-42f9-ac06-0a505fa724ae', 1, 52, 9, 17, 3, 0, 6, 12, 8, 16, 0, 0, 272, 57);
INSERT INTO public."BattingStats" ("PlayerId", "StatsType", "AtBats", "Runs", "Hits", "Doubles", "Triples", "HomeRuns", "RunsBattedIn", "BaseOnBalls", "StrikeOuts", "StolenBases", "CaughtStealing", "Power", "Speed") VALUES ('c4a6ee18-6242-4501-b781-b1b7f2b27e49', 1, 62, 9, 18, 3, 1, 2, 8, 4, 14, 1, 0, 113, 74);
INSERT INTO public."BattingStats" ("PlayerId", "StatsType", "AtBats", "Runs", "Hits", "Doubles", "Triples", "HomeRuns", "RunsBattedIn", "BaseOnBalls", "StrikeOuts", "StolenBases", "CaughtStealing", "Power", "Speed") VALUES ('cddc33ec-062e-4779-8057-75cd691c8abb', 1, 60, 11, 19, 4, 0, 3, 10, 7, 12, 1, 1, 140, 72);
INSERT INTO public."BattingStats" ("PlayerId", "StatsType", "AtBats", "Runs", "Hits", "Doubles", "Triples", "HomeRuns", "RunsBattedIn", "BaseOnBalls", "StrikeOuts", "StolenBases", "CaughtStealing", "Power", "Speed") VALUES ('cefdf564-6134-4030-b384-c3f6c9285114', 1, 34, 5, 11, 1, 1, 0, 3, 5, 6, 0, 1, 52, 83);
INSERT INTO public."BattingStats" ("PlayerId", "StatsType", "AtBats", "Runs", "Hits", "Doubles", "Triples", "HomeRuns", "RunsBattedIn", "BaseOnBalls", "StrikeOuts", "StolenBases", "CaughtStealing", "Power", "Speed") VALUES ('d3bcbd0a-4ad2-4604-b82b-c9620013260b', 1, 51, 8, 17, 4, 0, 1, 7, 3, 9, 8, 0, 99, 80);
INSERT INTO public."BattingStats" ("PlayerId", "StatsType", "AtBats", "Runs", "Hits", "Doubles", "Triples", "HomeRuns", "RunsBattedIn", "BaseOnBalls", "StrikeOuts", "StolenBases", "CaughtStealing", "Power", "Speed") VALUES ('d7f01c58-2f34-4bb3-8978-b4f0c4bfd54b', 1, 3, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 58);
INSERT INTO public."BattingStats" ("PlayerId", "StatsType", "AtBats", "Runs", "Hits", "Doubles", "Triples", "HomeRuns", "RunsBattedIn", "BaseOnBalls", "StrikeOuts", "StolenBases", "CaughtStealing", "Power", "Speed") VALUES ('da2190fb-0dbd-4edc-8d83-e7808266d630', 1, 32, 6, 5, 2, 0, 1, 7, 2, 12, 1, 1, 136, 80);
INSERT INTO public."BattingStats" ("PlayerId", "StatsType", "AtBats", "Runs", "Hits", "Doubles", "Triples", "HomeRuns", "RunsBattedIn", "BaseOnBalls", "StrikeOuts", "StolenBases", "CaughtStealing", "Power", "Speed") VALUES ('e3090c33-043b-4f89-a6ad-955b1b4b7c6d', 1, 52, 2, 10, 0, 0, 0, 4, 5, 12, 1, 0, 0, 70);
INSERT INTO public."BattingStats" ("PlayerId", "StatsType", "AtBats", "Runs", "Hits", "Doubles", "Triples", "HomeRuns", "RunsBattedIn", "BaseOnBalls", "StrikeOuts", "StolenBases", "CaughtStealing", "Power", "Speed") VALUES ('e45125f0-e38b-466a-bb06-62b1ccda2c5f', 1, 30, 8, 11, 0, 0, 2, 5, 3, 7, 2, 0, 110, 80);
INSERT INTO public."BattingStats" ("PlayerId", "StatsType", "AtBats", "Runs", "Hits", "Doubles", "Triples", "HomeRuns", "RunsBattedIn", "BaseOnBalls", "StrikeOuts", "StolenBases", "CaughtStealing", "Power", "Speed") VALUES ('efd41ad2-4941-4d97-aca4-751c971cf33e', 1, 67, 16, 18, 5, 0, 3, 8, 8, 11, 1, 0, 133, 62);
INSERT INTO public."BattingStats" ("PlayerId", "StatsType", "AtBats", "Runs", "Hits", "Doubles", "Triples", "HomeRuns", "RunsBattedIn", "BaseOnBalls", "StrikeOuts", "StolenBases", "CaughtStealing", "Power", "Speed") VALUES ('fba56342-e6ef-41d1-a393-c62a85df7f92', 1, 61, 5, 11, 1, 0, 2, 10, 9, 12, 0, 0, 67, 61);


--
-- TOC entry 3352 (class 0 OID 16388)
-- Dependencies: 210
-- Data for Name: LeagueStatuses; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public."LeagueStatuses" ("PlayerId", "LeagueId", "LeagueStatus") VALUES ('20e17640-9552-490c-b90f-652395ac6951', 2, 2);
INSERT INTO public."LeagueStatuses" ("PlayerId", "LeagueId", "LeagueStatus") VALUES ('083931a0-68ac-4d5c-a045-78ecf437a444', 2, 1);
INSERT INTO public."LeagueStatuses" ("PlayerId", "LeagueId", "LeagueStatus") VALUES ('083931a0-68ac-4d5c-a045-78ecf437a444', 1, 2);
INSERT INTO public."LeagueStatuses" ("PlayerId", "LeagueId", "LeagueStatus") VALUES ('2a601e7c-6dc3-48c6-b215-77f243da4ee6', 1, 0);
INSERT INTO public."LeagueStatuses" ("PlayerId", "LeagueId", "LeagueStatus") VALUES ('2a601e7c-6dc3-48c6-b215-77f243da4ee6', 2, 0);
INSERT INTO public."LeagueStatuses" ("PlayerId", "LeagueId", "LeagueStatus") VALUES ('35f2c7d4-799c-4f05-9313-f80e102140ec', 1, 1);
INSERT INTO public."LeagueStatuses" ("PlayerId", "LeagueId", "LeagueStatus") VALUES ('3c88638b-291f-45f8-8bb2-a11d403604c5', 1, 1);
INSERT INTO public."LeagueStatuses" ("PlayerId", "LeagueId", "LeagueStatus") VALUES ('3c88638b-291f-45f8-8bb2-a11d403604c5', 2, 2);
INSERT INTO public."LeagueStatuses" ("PlayerId", "LeagueId", "LeagueStatus") VALUES ('35f2c7d4-799c-4f05-9313-f80e102140ec', 2, 1);
INSERT INTO public."LeagueStatuses" ("PlayerId", "LeagueId", "LeagueStatus") VALUES ('488e88e9-2d20-4a48-9edf-dbdbf21f429c', 1, 0);
INSERT INTO public."LeagueStatuses" ("PlayerId", "LeagueId", "LeagueStatus") VALUES ('488e88e9-2d20-4a48-9edf-dbdbf21f429c', 2, 0);
INSERT INTO public."LeagueStatuses" ("PlayerId", "LeagueId", "LeagueStatus") VALUES ('51a61d66-e85b-480a-bbf8-995dd0436f29', 2, 2);
INSERT INTO public."LeagueStatuses" ("PlayerId", "LeagueId", "LeagueStatus") VALUES ('5b92e19b-3bfd-40dd-9546-73cccede2638', 2, 1);
INSERT INTO public."LeagueStatuses" ("PlayerId", "LeagueId", "LeagueStatus") VALUES ('61a0a509-7d45-489b-a6be-2e19700173ac', 1, 1);
INSERT INTO public."LeagueStatuses" ("PlayerId", "LeagueId", "LeagueStatus") VALUES ('61a0a509-7d45-489b-a6be-2e19700173ac', 2, 2);
INSERT INTO public."LeagueStatuses" ("PlayerId", "LeagueId", "LeagueStatus") VALUES ('4947afdf-6d0d-4d36-a656-d1687789cfd8', 2, 1);
INSERT INTO public."LeagueStatuses" ("PlayerId", "LeagueId", "LeagueStatus") VALUES ('6102c1c5-0022-4a73-93cd-ead484f4e735', 2, 2);
INSERT INTO public."LeagueStatuses" ("PlayerId", "LeagueId", "LeagueStatus") VALUES ('51a61d66-e85b-480a-bbf8-995dd0436f29', 1, 2);
INSERT INTO public."LeagueStatuses" ("PlayerId", "LeagueId", "LeagueStatus") VALUES ('5b92e19b-3bfd-40dd-9546-73cccede2638', 1, 2);
INSERT INTO public."LeagueStatuses" ("PlayerId", "LeagueId", "LeagueStatus") VALUES ('4947afdf-6d0d-4d36-a656-d1687789cfd8', 1, 2);
INSERT INTO public."LeagueStatuses" ("PlayerId", "LeagueId", "LeagueStatus") VALUES ('6102c1c5-0022-4a73-93cd-ead484f4e735', 1, 1);
INSERT INTO public."LeagueStatuses" ("PlayerId", "LeagueId", "LeagueStatus") VALUES ('780e4821-a9ab-459b-90d9-06a5308cd24f', 1, 0);
INSERT INTO public."LeagueStatuses" ("PlayerId", "LeagueId", "LeagueStatus") VALUES ('780e4821-a9ab-459b-90d9-06a5308cd24f', 2, 0);
INSERT INTO public."LeagueStatuses" ("PlayerId", "LeagueId", "LeagueStatus") VALUES ('6d56f922-c389-4716-950b-2fa0073cda78', 2, 1);
INSERT INTO public."LeagueStatuses" ("PlayerId", "LeagueId", "LeagueStatus") VALUES ('7106b85c-47e2-4e4f-95a3-2e0d72f252e4', 1, 0);
INSERT INTO public."LeagueStatuses" ("PlayerId", "LeagueId", "LeagueStatus") VALUES ('647cdd37-00ae-46b6-b69d-7a76174f71b3', 2, 2);
INSERT INTO public."LeagueStatuses" ("PlayerId", "LeagueId", "LeagueStatus") VALUES ('79442841-8e3a-40a2-a08e-77a4daeb3969', 2, 2);
INSERT INTO public."LeagueStatuses" ("PlayerId", "LeagueId", "LeagueStatus") VALUES ('7106b85c-47e2-4e4f-95a3-2e0d72f252e4', 2, 0);
INSERT INTO public."LeagueStatuses" ("PlayerId", "LeagueId", "LeagueStatus") VALUES ('6d56f922-c389-4716-950b-2fa0073cda78', 1, 2);
INSERT INTO public."LeagueStatuses" ("PlayerId", "LeagueId", "LeagueStatus") VALUES ('647cdd37-00ae-46b6-b69d-7a76174f71b3', 1, 1);
INSERT INTO public."LeagueStatuses" ("PlayerId", "LeagueId", "LeagueStatus") VALUES ('79442841-8e3a-40a2-a08e-77a4daeb3969', 1, 1);
INSERT INTO public."LeagueStatuses" ("PlayerId", "LeagueId", "LeagueStatus") VALUES ('89ef3592-b576-408a-829a-526aad713b95', 1, 0);
INSERT INTO public."LeagueStatuses" ("PlayerId", "LeagueId", "LeagueStatus") VALUES ('89ef3592-b576-408a-829a-526aad713b95', 2, 0);
INSERT INTO public."LeagueStatuses" ("PlayerId", "LeagueId", "LeagueStatus") VALUES ('82ce40a9-45cd-453c-ab03-0fcfba2b62d9', 2, 1);
INSERT INTO public."LeagueStatuses" ("PlayerId", "LeagueId", "LeagueStatus") VALUES ('9ff79a30-3c1b-44c7-96a0-d33633c847df', 2, 1);
INSERT INTO public."LeagueStatuses" ("PlayerId", "LeagueId", "LeagueStatus") VALUES ('9bd677e7-ba97-4bd7-89e8-5cf61dedba78', 2, 2);
INSERT INTO public."LeagueStatuses" ("PlayerId", "LeagueId", "LeagueStatus") VALUES ('973e9c12-762b-4303-aea4-65bed4c4edd2', 2, 1);
INSERT INTO public."LeagueStatuses" ("PlayerId", "LeagueId", "LeagueStatus") VALUES ('8372ff25-ff7f-4825-8960-d4e1206647a9', 2, 2);
INSERT INTO public."LeagueStatuses" ("PlayerId", "LeagueId", "LeagueStatus") VALUES ('9ff79a30-3c1b-44c7-96a0-d33633c847df', 1, 2);
INSERT INTO public."LeagueStatuses" ("PlayerId", "LeagueId", "LeagueStatus") VALUES ('9e6a26f6-e752-43ae-9327-9092c51ce23a', 1, 2);
INSERT INTO public."LeagueStatuses" ("PlayerId", "LeagueId", "LeagueStatus") VALUES ('973e9c12-762b-4303-aea4-65bed4c4edd2', 1, 1);
INSERT INTO public."LeagueStatuses" ("PlayerId", "LeagueId", "LeagueStatus") VALUES ('8372ff25-ff7f-4825-8960-d4e1206647a9', 1, 1);
INSERT INTO public."LeagueStatuses" ("PlayerId", "LeagueId", "LeagueStatus") VALUES ('9d7257bc-e6a4-46bc-9200-91b73f437a82', 2, 2);
INSERT INTO public."LeagueStatuses" ("PlayerId", "LeagueId", "LeagueStatus") VALUES ('b6832adf-a496-4d5d-81e7-605030a0e028', 1, 0);
INSERT INTO public."LeagueStatuses" ("PlayerId", "LeagueId", "LeagueStatus") VALUES ('b6832adf-a496-4d5d-81e7-605030a0e028', 2, 0);
INSERT INTO public."LeagueStatuses" ("PlayerId", "LeagueId", "LeagueStatus") VALUES ('c4a6ee18-6242-4501-b781-b1b7f2b27e49', 2, 2);
INSERT INTO public."LeagueStatuses" ("PlayerId", "LeagueId", "LeagueStatus") VALUES ('a75dadee-3586-4b2b-a371-2beffd6884a7', 2, 1);
INSERT INTO public."LeagueStatuses" ("PlayerId", "LeagueId", "LeagueStatus") VALUES ('b850bfff-7f85-40a9-abff-28348754dbe9', 2, 2);
INSERT INTO public."LeagueStatuses" ("PlayerId", "LeagueId", "LeagueStatus") VALUES ('a75dadee-3586-4b2b-a371-2beffd6884a7', 1, 2);
INSERT INTO public."LeagueStatuses" ("PlayerId", "LeagueId", "LeagueStatus") VALUES ('ac0af2b7-e715-4a7f-a13d-d3a4ecc95555', 1, 2);
INSERT INTO public."LeagueStatuses" ("PlayerId", "LeagueId", "LeagueStatus") VALUES ('b5df2e6f-cccc-42f9-ac06-0a505fa724ae', 1, 2);
INSERT INTO public."LeagueStatuses" ("PlayerId", "LeagueId", "LeagueStatus") VALUES ('b850bfff-7f85-40a9-abff-28348754dbe9', 1, 2);
INSERT INTO public."LeagueStatuses" ("PlayerId", "LeagueId", "LeagueStatus") VALUES ('b5df2e6f-cccc-42f9-ac06-0a505fa724ae', 2, 1);
INSERT INTO public."LeagueStatuses" ("PlayerId", "LeagueId", "LeagueStatus") VALUES ('cefdf564-6134-4030-b384-c3f6c9285114', 1, 0);
INSERT INTO public."LeagueStatuses" ("PlayerId", "LeagueId", "LeagueStatus") VALUES ('cefdf564-6134-4030-b384-c3f6c9285114', 2, 0);
INSERT INTO public."LeagueStatuses" ("PlayerId", "LeagueId", "LeagueStatus") VALUES ('d7f01c58-2f34-4bb3-8978-b4f0c4bfd54b', 1, 0);
INSERT INTO public."LeagueStatuses" ("PlayerId", "LeagueId", "LeagueStatus") VALUES ('d7f01c58-2f34-4bb3-8978-b4f0c4bfd54b', 2, 0);
INSERT INTO public."LeagueStatuses" ("PlayerId", "LeagueId", "LeagueStatus") VALUES ('da2190fb-0dbd-4edc-8d83-e7808266d630', 1, 0);
INSERT INTO public."LeagueStatuses" ("PlayerId", "LeagueId", "LeagueStatus") VALUES ('da2190fb-0dbd-4edc-8d83-e7808266d630', 2, 0);
INSERT INTO public."LeagueStatuses" ("PlayerId", "LeagueId", "LeagueStatus") VALUES ('e45125f0-e38b-466a-bb06-62b1ccda2c5f', 1, 0);
INSERT INTO public."LeagueStatuses" ("PlayerId", "LeagueId", "LeagueStatus") VALUES ('e45125f0-e38b-466a-bb06-62b1ccda2c5f', 2, 0);
INSERT INTO public."LeagueStatuses" ("PlayerId", "LeagueId", "LeagueStatus") VALUES ('cddc33ec-062e-4779-8057-75cd691c8abb', 2, 1);
INSERT INTO public."LeagueStatuses" ("PlayerId", "LeagueId", "LeagueStatus") VALUES ('d3bcbd0a-4ad2-4604-b82b-c9620013260b', 2, 2);
INSERT INTO public."LeagueStatuses" ("PlayerId", "LeagueId", "LeagueStatus") VALUES ('e3090c33-043b-4f89-a6ad-955b1b4b7c6d', 2, 1);
INSERT INTO public."LeagueStatuses" ("PlayerId", "LeagueId", "LeagueStatus") VALUES ('d3bcbd0a-4ad2-4604-b82b-c9620013260b', 1, 2);
INSERT INTO public."LeagueStatuses" ("PlayerId", "LeagueId", "LeagueStatus") VALUES ('e3090c33-043b-4f89-a6ad-955b1b4b7c6d', 1, 2);
INSERT INTO public."LeagueStatuses" ("PlayerId", "LeagueId", "LeagueStatus") VALUES ('01317e6c-91ca-410d-93d6-d3ee9c46b241', 1, 0);
INSERT INTO public."LeagueStatuses" ("PlayerId", "LeagueId", "LeagueStatus") VALUES ('01317e6c-91ca-410d-93d6-d3ee9c46b241', 2, 0);
INSERT INTO public."LeagueStatuses" ("PlayerId", "LeagueId", "LeagueStatus") VALUES ('ac0af2b7-e715-4a7f-a13d-d3a4ecc95555', 2, 1);
INSERT INTO public."LeagueStatuses" ("PlayerId", "LeagueId", "LeagueStatus") VALUES ('fba56342-e6ef-41d1-a393-c62a85df7f92', 2, 2);
INSERT INTO public."LeagueStatuses" ("PlayerId", "LeagueId", "LeagueStatus") VALUES ('9e6a26f6-e752-43ae-9327-9092c51ce23a', 2, 1);
INSERT INTO public."LeagueStatuses" ("PlayerId", "LeagueId", "LeagueStatus") VALUES ('efd41ad2-4941-4d97-aca4-751c971cf33e', 1, 1);
INSERT INTO public."LeagueStatuses" ("PlayerId", "LeagueId", "LeagueStatus") VALUES ('1aa5b3dd-c616-4f3e-8bee-6a210467f4da', 1, 0);
INSERT INTO public."LeagueStatuses" ("PlayerId", "LeagueId", "LeagueStatus") VALUES ('1aa5b3dd-c616-4f3e-8bee-6a210467f4da', 2, 0);
INSERT INTO public."LeagueStatuses" ("PlayerId", "LeagueId", "LeagueStatus") VALUES ('213c94cc-26b3-42b9-8544-eb6c34cabffb', 2, 1);
INSERT INTO public."LeagueStatuses" ("PlayerId", "LeagueId", "LeagueStatus") VALUES ('139980d6-5eb2-4c52-ab6e-4730a21b7bb8', 2, 2);
INSERT INTO public."LeagueStatuses" ("PlayerId", "LeagueId", "LeagueStatus") VALUES ('213c94cc-26b3-42b9-8544-eb6c34cabffb', 1, 1);
INSERT INTO public."LeagueStatuses" ("PlayerId", "LeagueId", "LeagueStatus") VALUES ('139980d6-5eb2-4c52-ab6e-4730a21b7bb8', 1, 0);
INSERT INTO public."LeagueStatuses" ("PlayerId", "LeagueId", "LeagueStatus") VALUES ('22459580-ed4c-4809-a345-4f1c9abda82c', 1, 0);
INSERT INTO public."LeagueStatuses" ("PlayerId", "LeagueId", "LeagueStatus") VALUES ('22459580-ed4c-4809-a345-4f1c9abda82c', 2, 0);
INSERT INTO public."LeagueStatuses" ("PlayerId", "LeagueId", "LeagueStatus") VALUES ('25ae92fd-8592-4917-b051-8f71928a070c', 1, 0);
INSERT INTO public."LeagueStatuses" ("PlayerId", "LeagueId", "LeagueStatus") VALUES ('25ae92fd-8592-4917-b051-8f71928a070c', 2, 0);
INSERT INTO public."LeagueStatuses" ("PlayerId", "LeagueId", "LeagueStatus") VALUES ('30233b7f-5a84-47ad-a453-551c36929666', 1, 0);
INSERT INTO public."LeagueStatuses" ("PlayerId", "LeagueId", "LeagueStatus") VALUES ('30233b7f-5a84-47ad-a453-551c36929666', 2, 0);
INSERT INTO public."LeagueStatuses" ("PlayerId", "LeagueId", "LeagueStatus") VALUES ('31e9da1c-6f0e-4e17-b880-7bf3a4d3ba3d', 2, 2);
INSERT INTO public."LeagueStatuses" ("PlayerId", "LeagueId", "LeagueStatus") VALUES ('25e3a5de-4fae-4788-920e-20cd919acc0b', 2, 2);
INSERT INTO public."LeagueStatuses" ("PlayerId", "LeagueId", "LeagueStatus") VALUES ('21abe7f6-ce67-4138-90ad-eb3579ef3530', 2, 1);
INSERT INTO public."LeagueStatuses" ("PlayerId", "LeagueId", "LeagueStatus") VALUES ('31e9da1c-6f0e-4e17-b880-7bf3a4d3ba3d', 1, 1);
INSERT INTO public."LeagueStatuses" ("PlayerId", "LeagueId", "LeagueStatus") VALUES ('21abe7f6-ce67-4138-90ad-eb3579ef3530', 1, 2);
INSERT INTO public."LeagueStatuses" ("PlayerId", "LeagueId", "LeagueStatus") VALUES ('25e3a5de-4fae-4788-920e-20cd919acc0b', 1, 1);
INSERT INTO public."LeagueStatuses" ("PlayerId", "LeagueId", "LeagueStatus") VALUES ('410fd6d5-bd15-4618-96f4-3ff12a803795', 1, 0);
INSERT INTO public."LeagueStatuses" ("PlayerId", "LeagueId", "LeagueStatus") VALUES ('410fd6d5-bd15-4618-96f4-3ff12a803795', 2, 0);
INSERT INTO public."LeagueStatuses" ("PlayerId", "LeagueId", "LeagueStatus") VALUES ('44c34d0e-1cb0-4582-be47-080949e0061b', 2, 0);
INSERT INTO public."LeagueStatuses" ("PlayerId", "LeagueId", "LeagueStatus") VALUES ('4656ff39-53bc-4ce1-a87f-5c0431ffcf3f', 1, 0);
INSERT INTO public."LeagueStatuses" ("PlayerId", "LeagueId", "LeagueStatus") VALUES ('4656ff39-53bc-4ce1-a87f-5c0431ffcf3f', 2, 0);
INSERT INTO public."LeagueStatuses" ("PlayerId", "LeagueId", "LeagueStatus") VALUES ('5136c058-282b-4c37-bba2-56f7408c7803', 1, 0);
INSERT INTO public."LeagueStatuses" ("PlayerId", "LeagueId", "LeagueStatus") VALUES ('5169be32-19c3-477e-a8c8-dda1980be29b', 2, 1);
INSERT INTO public."LeagueStatuses" ("PlayerId", "LeagueId", "LeagueStatus") VALUES ('5578672e-d4a9-495c-8aaa-d0a9824a4a37', 2, 1);
INSERT INTO public."LeagueStatuses" ("PlayerId", "LeagueId", "LeagueStatus") VALUES ('40e2f815-821c-40dd-a33f-a037a3f238e5', 2, 2);
INSERT INTO public."LeagueStatuses" ("PlayerId", "LeagueId", "LeagueStatus") VALUES ('40cd2ee1-9c4d-44ec-87c3-407ac5b1523a', 2, 2);
INSERT INTO public."LeagueStatuses" ("PlayerId", "LeagueId", "LeagueStatus") VALUES ('5578672e-d4a9-495c-8aaa-d0a9824a4a37', 1, 2);
INSERT INTO public."LeagueStatuses" ("PlayerId", "LeagueId", "LeagueStatus") VALUES ('5169be32-19c3-477e-a8c8-dda1980be29b', 1, 2);
INSERT INTO public."LeagueStatuses" ("PlayerId", "LeagueId", "LeagueStatus") VALUES ('40e2f815-821c-40dd-a33f-a037a3f238e5', 1, 1);
INSERT INTO public."LeagueStatuses" ("PlayerId", "LeagueId", "LeagueStatus") VALUES ('40cd2ee1-9c4d-44ec-87c3-407ac5b1523a', 1, 2);
INSERT INTO public."LeagueStatuses" ("PlayerId", "LeagueId", "LeagueStatus") VALUES ('44c34d0e-1cb0-4582-be47-080949e0061b', 1, 1);
INSERT INTO public."LeagueStatuses" ("PlayerId", "LeagueId", "LeagueStatus") VALUES ('4bbd13bd-2559-4b5f-bc42-3a0b730113ff', 1, 2);
INSERT INTO public."LeagueStatuses" ("PlayerId", "LeagueId", "LeagueStatus") VALUES ('5136c058-282b-4c37-bba2-56f7408c7803', 2, 2);
INSERT INTO public."LeagueStatuses" ("PlayerId", "LeagueId", "LeagueStatus") VALUES ('4bbd13bd-2559-4b5f-bc42-3a0b730113ff', 2, 2);
INSERT INTO public."LeagueStatuses" ("PlayerId", "LeagueId", "LeagueStatus") VALUES ('6040b76b-0674-45da-9349-d90d2e3ccf64', 1, 0);
INSERT INTO public."LeagueStatuses" ("PlayerId", "LeagueId", "LeagueStatus") VALUES ('6040b76b-0674-45da-9349-d90d2e3ccf64', 2, 0);
INSERT INTO public."LeagueStatuses" ("PlayerId", "LeagueId", "LeagueStatus") VALUES ('61795270-ae6d-488d-8f8b-8f9a1d10730d', 1, 0);
INSERT INTO public."LeagueStatuses" ("PlayerId", "LeagueId", "LeagueStatus") VALUES ('61795270-ae6d-488d-8f8b-8f9a1d10730d', 2, 0);
INSERT INTO public."LeagueStatuses" ("PlayerId", "LeagueId", "LeagueStatus") VALUES ('69034182-a2d7-4840-82b6-c67dcd39634e', 1, 0);
INSERT INTO public."LeagueStatuses" ("PlayerId", "LeagueId", "LeagueStatus") VALUES ('6be652db-a1d2-4aad-afe8-98bd04170e8a', 2, 2);
INSERT INTO public."LeagueStatuses" ("PlayerId", "LeagueId", "LeagueStatus") VALUES ('69034182-a2d7-4840-82b6-c67dcd39634e', 2, 1);
INSERT INTO public."LeagueStatuses" ("PlayerId", "LeagueId", "LeagueStatus") VALUES ('6be652db-a1d2-4aad-afe8-98bd04170e8a', 1, 2);
INSERT INTO public."LeagueStatuses" ("PlayerId", "LeagueId", "LeagueStatus") VALUES ('77571748-f98b-46a2-b99c-01e01a220fc9', 2, 1);
INSERT INTO public."LeagueStatuses" ("PlayerId", "LeagueId", "LeagueStatus") VALUES ('77571748-f98b-46a2-b99c-01e01a220fc9', 1, 2);
INSERT INTO public."LeagueStatuses" ("PlayerId", "LeagueId", "LeagueStatus") VALUES ('80967cf1-c8c2-4ac1-92a2-615207ef7734', 1, 0);
INSERT INTO public."LeagueStatuses" ("PlayerId", "LeagueId", "LeagueStatus") VALUES ('82b81710-c5c4-4b08-9cc1-1419f5ffd382', 1, 0);
INSERT INTO public."LeagueStatuses" ("PlayerId", "LeagueId", "LeagueStatus") VALUES ('82b81710-c5c4-4b08-9cc1-1419f5ffd382', 2, 0);
INSERT INTO public."LeagueStatuses" ("PlayerId", "LeagueId", "LeagueStatus") VALUES ('83d9f9c9-9f5d-4d25-af3b-9af30700b82a', 2, 0);
INSERT INTO public."LeagueStatuses" ("PlayerId", "LeagueId", "LeagueStatus") VALUES ('80967cf1-c8c2-4ac1-92a2-615207ef7734', 2, 1);
INSERT INTO public."LeagueStatuses" ("PlayerId", "LeagueId", "LeagueStatus") VALUES ('7afbc714-c48a-4052-aab2-4da66c5059df', 2, 2);
INSERT INTO public."LeagueStatuses" ("PlayerId", "LeagueId", "LeagueStatus") VALUES ('85a74a1f-d654-4c39-830e-105e384937eb', 2, 1);
INSERT INTO public."LeagueStatuses" ("PlayerId", "LeagueId", "LeagueStatus") VALUES ('85a74a1f-d654-4c39-830e-105e384937eb', 1, 0);
INSERT INTO public."LeagueStatuses" ("PlayerId", "LeagueId", "LeagueStatus") VALUES ('83d9f9c9-9f5d-4d25-af3b-9af30700b82a', 1, 1);
INSERT INTO public."LeagueStatuses" ("PlayerId", "LeagueId", "LeagueStatus") VALUES ('a8fde7de-dd37-4bca-982e-7ac0d0916ea1', 1, 0);
INSERT INTO public."LeagueStatuses" ("PlayerId", "LeagueId", "LeagueStatus") VALUES ('a8fde7de-dd37-4bca-982e-7ac0d0916ea1', 2, 0);
INSERT INTO public."LeagueStatuses" ("PlayerId", "LeagueId", "LeagueStatus") VALUES ('ad69f157-23d5-4c6e-91bf-d5fb00747a87', 1, 0);
INSERT INTO public."LeagueStatuses" ("PlayerId", "LeagueId", "LeagueStatus") VALUES ('ad69f157-23d5-4c6e-91bf-d5fb00747a87', 2, 0);
INSERT INTO public."LeagueStatuses" ("PlayerId", "LeagueId", "LeagueStatus") VALUES ('b4e74de3-6c7d-42c6-9b6a-7270e2b22971', 2, 2);
INSERT INTO public."LeagueStatuses" ("PlayerId", "LeagueId", "LeagueStatus") VALUES ('aacc5ef2-96dd-4ca8-8e03-66973f50f002', 2, 1);
INSERT INTO public."LeagueStatuses" ("PlayerId", "LeagueId", "LeagueStatus") VALUES ('b4e74de3-6c7d-42c6-9b6a-7270e2b22971', 1, 1);
INSERT INTO public."LeagueStatuses" ("PlayerId", "LeagueId", "LeagueStatus") VALUES ('aacc5ef2-96dd-4ca8-8e03-66973f50f002', 1, 2);
INSERT INTO public."LeagueStatuses" ("PlayerId", "LeagueId", "LeagueStatus") VALUES ('a25cf946-49af-4faa-8049-601142377ab8', 1, 1);
INSERT INTO public."LeagueStatuses" ("PlayerId", "LeagueId", "LeagueStatus") VALUES ('a25cf946-49af-4faa-8049-601142377ab8', 2, 0);
INSERT INTO public."LeagueStatuses" ("PlayerId", "LeagueId", "LeagueStatus") VALUES ('c254c3ba-18a0-4f8f-bb4b-a7db2f020f0c', 1, 2);
INSERT INTO public."LeagueStatuses" ("PlayerId", "LeagueId", "LeagueStatus") VALUES ('c81dd2ce-130a-46a9-87f7-32caf8478b49', 2, 1);
INSERT INTO public."LeagueStatuses" ("PlayerId", "LeagueId", "LeagueStatus") VALUES ('c81dd2ce-130a-46a9-87f7-32caf8478b49', 1, 2);
INSERT INTO public."LeagueStatuses" ("PlayerId", "LeagueId", "LeagueStatus") VALUES ('c254c3ba-18a0-4f8f-bb4b-a7db2f020f0c', 2, 1);
INSERT INTO public."LeagueStatuses" ("PlayerId", "LeagueId", "LeagueStatus") VALUES ('db291251-e95e-4334-92f0-606d7bda7aef', 1, 0);
INSERT INTO public."LeagueStatuses" ("PlayerId", "LeagueId", "LeagueStatus") VALUES ('efce08f7-800a-4be5-a188-2cd796dc824b', 1, 0);
INSERT INTO public."LeagueStatuses" ("PlayerId", "LeagueId", "LeagueStatus") VALUES ('efce08f7-800a-4be5-a188-2cd796dc824b', 2, 0);
INSERT INTO public."LeagueStatuses" ("PlayerId", "LeagueId", "LeagueStatus") VALUES ('f1099553-5c27-4a12-a097-3939e919f804', 1, 0);
INSERT INTO public."LeagueStatuses" ("PlayerId", "LeagueId", "LeagueStatus") VALUES ('f1099553-5c27-4a12-a097-3939e919f804', 2, 0);
INSERT INTO public."LeagueStatuses" ("PlayerId", "LeagueId", "LeagueStatus") VALUES ('db291251-e95e-4334-92f0-606d7bda7aef', 2, 2);
INSERT INTO public."LeagueStatuses" ("PlayerId", "LeagueId", "LeagueStatus") VALUES ('e6366fff-e824-496b-8d73-eb1d691fe51f', 1, 2);
INSERT INTO public."LeagueStatuses" ("PlayerId", "LeagueId", "LeagueStatus") VALUES ('e6366fff-e824-496b-8d73-eb1d691fe51f', 2, 0);
INSERT INTO public."LeagueStatuses" ("PlayerId", "LeagueId", "LeagueStatus") VALUES ('efa00874-5c8e-428a-bf14-f15d68812975', 2, 1);
INSERT INTO public."LeagueStatuses" ("PlayerId", "LeagueId", "LeagueStatus") VALUES ('efa00874-5c8e-428a-bf14-f15d68812975', 1, 1);
INSERT INTO public."LeagueStatuses" ("PlayerId", "LeagueId", "LeagueStatus") VALUES ('f5b7aafd-b1f9-4bc5-a37b-e804874f90a0', 1, 0);
INSERT INTO public."LeagueStatuses" ("PlayerId", "LeagueId", "LeagueStatus") VALUES ('f5b7aafd-b1f9-4bc5-a37b-e804874f90a0', 2, 0);
INSERT INTO public."LeagueStatuses" ("PlayerId", "LeagueId", "LeagueStatus") VALUES ('f97f940a-2af3-4ce4-aa9c-520dd836e69a', 1, 0);
INSERT INTO public."LeagueStatuses" ("PlayerId", "LeagueId", "LeagueStatus") VALUES ('f97f940a-2af3-4ce4-aa9c-520dd836e69a', 2, 0);
INSERT INTO public."LeagueStatuses" ("PlayerId", "LeagueId", "LeagueStatus") VALUES ('efd41ad2-4941-4d97-aca4-751c971cf33e', 2, 2);
INSERT INTO public."LeagueStatuses" ("PlayerId", "LeagueId", "LeagueStatus") VALUES ('c4a6ee18-6242-4501-b781-b1b7f2b27e49', 1, 1);
INSERT INTO public."LeagueStatuses" ("PlayerId", "LeagueId", "LeagueStatus") VALUES ('20e17640-9552-490c-b90f-652395ac6951', 1, 1);
INSERT INTO public."LeagueStatuses" ("PlayerId", "LeagueId", "LeagueStatus") VALUES ('7afbc714-c48a-4052-aab2-4da66c5059df', 1, 1);
INSERT INTO public."LeagueStatuses" ("PlayerId", "LeagueId", "LeagueStatus") VALUES ('cddc33ec-062e-4779-8057-75cd691c8abb', 1, 2);
INSERT INTO public."LeagueStatuses" ("PlayerId", "LeagueId", "LeagueStatus") VALUES ('fba56342-e6ef-41d1-a393-c62a85df7f92', 1, 1);
INSERT INTO public."LeagueStatuses" ("PlayerId", "LeagueId", "LeagueStatus") VALUES ('f43372b7-ae6f-4013-8351-ae4be4efbaa4', 2, 1);
INSERT INTO public."LeagueStatuses" ("PlayerId", "LeagueId", "LeagueStatus") VALUES ('f43372b7-ae6f-4013-8351-ae4be4efbaa4', 1, 2);
INSERT INTO public."LeagueStatuses" ("PlayerId", "LeagueId", "LeagueStatus") VALUES ('19347bdc-b38e-49bb-9938-1e004bd5bcb8', 2, 2);
INSERT INTO public."LeagueStatuses" ("PlayerId", "LeagueId", "LeagueStatus") VALUES ('82ce40a9-45cd-453c-ab03-0fcfba2b62d9', 1, 2);
INSERT INTO public."LeagueStatuses" ("PlayerId", "LeagueId", "LeagueStatus") VALUES ('19347bdc-b38e-49bb-9938-1e004bd5bcb8', 1, 1);
INSERT INTO public."LeagueStatuses" ("PlayerId", "LeagueId", "LeagueStatus") VALUES ('9bd677e7-ba97-4bd7-89e8-5cf61dedba78', 1, 1);
INSERT INTO public."LeagueStatuses" ("PlayerId", "LeagueId", "LeagueStatus") VALUES ('4707d3a6-35cc-4f86-88f3-122e83de82b9', 1, 0);
INSERT INTO public."LeagueStatuses" ("PlayerId", "LeagueId", "LeagueStatus") VALUES ('4707d3a6-35cc-4f86-88f3-122e83de82b9', 2, 0);
INSERT INTO public."LeagueStatuses" ("PlayerId", "LeagueId", "LeagueStatus") VALUES ('9d7257bc-e6a4-46bc-9200-91b73f437a82', 1, 1);
INSERT INTO public."LeagueStatuses" ("PlayerId", "LeagueId", "LeagueStatus") VALUES ('2742eeb2-bcb4-4241-b934-fd6addc66352', 1, 0);
INSERT INTO public."LeagueStatuses" ("PlayerId", "LeagueId", "LeagueStatus") VALUES ('2742eeb2-bcb4-4241-b934-fd6addc66352', 2, 0);
INSERT INTO public."LeagueStatuses" ("PlayerId", "LeagueId", "LeagueStatus") VALUES ('e48f6045-a7da-4b8a-b2ee-d4aeac401f6a', 1, 0);
INSERT INTO public."LeagueStatuses" ("PlayerId", "LeagueId", "LeagueStatus") VALUES ('e48f6045-a7da-4b8a-b2ee-d4aeac401f6a', 2, 0);


--
-- TOC entry 3353 (class 0 OID 16391)
-- Dependencies: 211
-- Data for Name: PitchingStats; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public."PitchingStats" ("PlayerId", "StatsType", "Wins", "Losses", "QualityStarts", "Saves", "BlownSaves", "Holds", "InningsPitched", "HitsAllowed", "EarnedRuns", "HomeRunsAllowed", "BaseOnBallsAllowed", "StrikeOuts", "FlyBallRate", "GroundBallRate") VALUES ('139980d6-5eb2-4c52-ab6e-4730a21b7bb8', 1, 0, 1, 0, 0, 0, 0, 12.2, 22, 10, 4, 5, 10, 0.4, 0.38);
INSERT INTO public."PitchingStats" ("PlayerId", "StatsType", "Wins", "Losses", "QualityStarts", "Saves", "BlownSaves", "Holds", "InningsPitched", "HitsAllowed", "EarnedRuns", "HomeRunsAllowed", "BaseOnBallsAllowed", "StrikeOuts", "FlyBallRate", "GroundBallRate") VALUES ('19347bdc-b38e-49bb-9938-1e004bd5bcb8', 1, 0, 0, 0, 3, 0, 0, 5, 5, 2, 0, 0, 3, 0.29, 0.35);
INSERT INTO public."PitchingStats" ("PlayerId", "StatsType", "Wins", "Losses", "QualityStarts", "Saves", "BlownSaves", "Holds", "InningsPitched", "HitsAllowed", "EarnedRuns", "HomeRunsAllowed", "BaseOnBallsAllowed", "StrikeOuts", "FlyBallRate", "GroundBallRate") VALUES ('1aa5b3dd-c616-4f3e-8bee-6a210467f4da', 1, 2, 0, 0, 0, 0, 0, 16.2, 17, 5, 2, 3, 11, 0.35, 0.33);
INSERT INTO public."PitchingStats" ("PlayerId", "StatsType", "Wins", "Losses", "QualityStarts", "Saves", "BlownSaves", "Holds", "InningsPitched", "HitsAllowed", "EarnedRuns", "HomeRunsAllowed", "BaseOnBallsAllowed", "StrikeOuts", "FlyBallRate", "GroundBallRate") VALUES ('213c94cc-26b3-42b9-8544-eb6c34cabffb', 1, 0, 1, 0, 0, 0, 0, 16.2, 14, 9, 2, 6, 22, 0.43, 0.41);
INSERT INTO public."PitchingStats" ("PlayerId", "StatsType", "Wins", "Losses", "QualityStarts", "Saves", "BlownSaves", "Holds", "InningsPitched", "HitsAllowed", "EarnedRuns", "HomeRunsAllowed", "BaseOnBallsAllowed", "StrikeOuts", "FlyBallRate", "GroundBallRate") VALUES ('21abe7f6-ce67-4138-90ad-eb3579ef3530', 1, 0, 3, 0, 1, 1, 0, 7.2, 4, 4, 1, 10, 7, 0.27, 0.54);
INSERT INTO public."PitchingStats" ("PlayerId", "StatsType", "Wins", "Losses", "QualityStarts", "Saves", "BlownSaves", "Holds", "InningsPitched", "HitsAllowed", "EarnedRuns", "HomeRunsAllowed", "BaseOnBallsAllowed", "StrikeOuts", "FlyBallRate", "GroundBallRate") VALUES ('22459580-ed4c-4809-a345-4f1c9abda82c', 1, 1, 1, 0, 0, 0, 0, 14.2, 16, 8, 0, 8, 14, 0.34, 0.48);
INSERT INTO public."PitchingStats" ("PlayerId", "StatsType", "Wins", "Losses", "QualityStarts", "Saves", "BlownSaves", "Holds", "InningsPitched", "HitsAllowed", "EarnedRuns", "HomeRunsAllowed", "BaseOnBallsAllowed", "StrikeOuts", "FlyBallRate", "GroundBallRate") VALUES ('25ae92fd-8592-4917-b051-8f71928a070c', 1, 0, 0, 0, 0, 0, 0, 4, 3, 1, 0, 1, 4, 0.36, 0.27);
INSERT INTO public."PitchingStats" ("PlayerId", "StatsType", "Wins", "Losses", "QualityStarts", "Saves", "BlownSaves", "Holds", "InningsPitched", "HitsAllowed", "EarnedRuns", "HomeRunsAllowed", "BaseOnBallsAllowed", "StrikeOuts", "FlyBallRate", "GroundBallRate") VALUES ('30233b7f-5a84-47ad-a453-551c36929666', 1, 0, 0, 0, 0, 0, 0, 4, 1, 1, 0, 2, 0, 0.27, 0.54);
INSERT INTO public."PitchingStats" ("PlayerId", "StatsType", "Wins", "Losses", "QualityStarts", "Saves", "BlownSaves", "Holds", "InningsPitched", "HitsAllowed", "EarnedRuns", "HomeRunsAllowed", "BaseOnBallsAllowed", "StrikeOuts", "FlyBallRate", "GroundBallRate") VALUES ('31e9da1c-6f0e-4e17-b880-7bf3a4d3ba3d', 1, 0, 0, 0, 4, 0, 0, 6, 2, 1, 1, 2, 8, 0.53, 0.38);
INSERT INTO public."PitchingStats" ("PlayerId", "StatsType", "Wins", "Losses", "QualityStarts", "Saves", "BlownSaves", "Holds", "InningsPitched", "HitsAllowed", "EarnedRuns", "HomeRunsAllowed", "BaseOnBallsAllowed", "StrikeOuts", "FlyBallRate", "GroundBallRate") VALUES ('40cd2ee1-9c4d-44ec-87c3-407ac5b1523a', 1, 0, 1, 0, 1, 1, 2, 5.1, 5, 4, 0, 0, 4, 0.47, 0.17);
INSERT INTO public."PitchingStats" ("PlayerId", "StatsType", "Wins", "Losses", "QualityStarts", "Saves", "BlownSaves", "Holds", "InningsPitched", "HitsAllowed", "EarnedRuns", "HomeRunsAllowed", "BaseOnBallsAllowed", "StrikeOuts", "FlyBallRate", "GroundBallRate") VALUES ('40e2f815-821c-40dd-a33f-a037a3f238e5', 1, 0, 1, 0, 3, 0, 0, 5, 5, 5, 0, 6, 8, 0.41, 0.41);
INSERT INTO public."PitchingStats" ("PlayerId", "StatsType", "Wins", "Losses", "QualityStarts", "Saves", "BlownSaves", "Holds", "InningsPitched", "HitsAllowed", "EarnedRuns", "HomeRunsAllowed", "BaseOnBallsAllowed", "StrikeOuts", "FlyBallRate", "GroundBallRate") VALUES ('4656ff39-53bc-4ce1-a87f-5c0431ffcf3f', 1, 1, 0, 0, 0, 0, 0, 8.2, 8, 5, 3, 1, 10, 0.45, 0.31);
INSERT INTO public."PitchingStats" ("PlayerId", "StatsType", "Wins", "Losses", "QualityStarts", "Saves", "BlownSaves", "Holds", "InningsPitched", "HitsAllowed", "EarnedRuns", "HomeRunsAllowed", "BaseOnBallsAllowed", "StrikeOuts", "FlyBallRate", "GroundBallRate") VALUES ('5136c058-282b-4c37-bba2-56f7408c7803', 1, 0, 0, 0, 0, 0, 1, 2, 2, 0, 0, 1, 3, 0.6, 0.2);
INSERT INTO public."PitchingStats" ("PlayerId", "StatsType", "Wins", "Losses", "QualityStarts", "Saves", "BlownSaves", "Holds", "InningsPitched", "HitsAllowed", "EarnedRuns", "HomeRunsAllowed", "BaseOnBallsAllowed", "StrikeOuts", "FlyBallRate", "GroundBallRate") VALUES ('5169be32-19c3-477e-a8c8-dda1980be29b', 1, 1, 1, 0, 2, 0, 2, 6, 2, 2, 1, 5, 8, 0.41, 0.41);
INSERT INTO public."PitchingStats" ("PlayerId", "StatsType", "Wins", "Losses", "QualityStarts", "Saves", "BlownSaves", "Holds", "InningsPitched", "HitsAllowed", "EarnedRuns", "HomeRunsAllowed", "BaseOnBallsAllowed", "StrikeOuts", "FlyBallRate", "GroundBallRate") VALUES ('5578672e-d4a9-495c-8aaa-d0a9824a4a37', 1, 0, 0, 0, 4, 1, 0, 7, 8, 1, 0, 0, 6, 0.09, 0.5);
INSERT INTO public."PitchingStats" ("PlayerId", "StatsType", "Wins", "Losses", "QualityStarts", "Saves", "BlownSaves", "Holds", "InningsPitched", "HitsAllowed", "EarnedRuns", "HomeRunsAllowed", "BaseOnBallsAllowed", "StrikeOuts", "FlyBallRate", "GroundBallRate") VALUES ('6040b76b-0674-45da-9349-d90d2e3ccf64', 1, 0, 0, 0, 1, 0, 0, 8.1, 3, 3, 1, 5, 9, 0.36, 0.42);
INSERT INTO public."PitchingStats" ("PlayerId", "StatsType", "Wins", "Losses", "QualityStarts", "Saves", "BlownSaves", "Holds", "InningsPitched", "HitsAllowed", "EarnedRuns", "HomeRunsAllowed", "BaseOnBallsAllowed", "StrikeOuts", "FlyBallRate", "GroundBallRate") VALUES ('61795270-ae6d-488d-8f8b-8f9a1d10730d', 1, 0, 0, 0, 0, 0, 2, 6.1, 7, 4, 3, 2, 2, 0.37, 0.45);
INSERT INTO public."PitchingStats" ("PlayerId", "StatsType", "Wins", "Losses", "QualityStarts", "Saves", "BlownSaves", "Holds", "InningsPitched", "HitsAllowed", "EarnedRuns", "HomeRunsAllowed", "BaseOnBallsAllowed", "StrikeOuts", "FlyBallRate", "GroundBallRate") VALUES ('6be652db-a1d2-4aad-afe8-98bd04170e8a', 1, 2, 0, 0, 0, 0, 0, 17.2, 10, 5, 2, 2, 26, 0.5, 0.36);
INSERT INTO public."PitchingStats" ("PlayerId", "StatsType", "Wins", "Losses", "QualityStarts", "Saves", "BlownSaves", "Holds", "InningsPitched", "HitsAllowed", "EarnedRuns", "HomeRunsAllowed", "BaseOnBallsAllowed", "StrikeOuts", "FlyBallRate", "GroundBallRate") VALUES ('77571748-f98b-46a2-b99c-01e01a220fc9', 1, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 1, 1, 0.5, 0.5);
INSERT INTO public."PitchingStats" ("PlayerId", "StatsType", "Wins", "Losses", "QualityStarts", "Saves", "BlownSaves", "Holds", "InningsPitched", "HitsAllowed", "EarnedRuns", "HomeRunsAllowed", "BaseOnBallsAllowed", "StrikeOuts", "FlyBallRate", "GroundBallRate") VALUES ('7afbc714-c48a-4052-aab2-4da66c5059df', 1, 2, 2, 0, 0, 0, 0, 24.1, 32, 17, 3, 11, 20, 0.27, 0.38);
INSERT INTO public."PitchingStats" ("PlayerId", "StatsType", "Wins", "Losses", "QualityStarts", "Saves", "BlownSaves", "Holds", "InningsPitched", "HitsAllowed", "EarnedRuns", "HomeRunsAllowed", "BaseOnBallsAllowed", "StrikeOuts", "FlyBallRate", "GroundBallRate") VALUES ('80967cf1-c8c2-4ac1-92a2-615207ef7734', 1, 2, 1, 0, 0, 0, 0, 17.2, 19, 4, 1, 2, 19, 0.26, 0.47);
INSERT INTO public."PitchingStats" ("PlayerId", "StatsType", "Wins", "Losses", "QualityStarts", "Saves", "BlownSaves", "Holds", "InningsPitched", "HitsAllowed", "EarnedRuns", "HomeRunsAllowed", "BaseOnBallsAllowed", "StrikeOuts", "FlyBallRate", "GroundBallRate") VALUES ('83d9f9c9-9f5d-4d25-af3b-9af30700b82a', 1, 2, 0, 0, 1, 0, 2, 6.2, 6, 4, 3, 3, 9, 0.41, 0.52);
INSERT INTO public."PitchingStats" ("PlayerId", "StatsType", "Wins", "Losses", "QualityStarts", "Saves", "BlownSaves", "Holds", "InningsPitched", "HitsAllowed", "EarnedRuns", "HomeRunsAllowed", "BaseOnBallsAllowed", "StrikeOuts", "FlyBallRate", "GroundBallRate") VALUES ('85a74a1f-d654-4c39-830e-105e384937eb', 1, 1, 1, 0, 0, 0, 0, 11, 8, 1, 1, 1, 13, 0.44, 0.4);
INSERT INTO public."PitchingStats" ("PlayerId", "StatsType", "Wins", "Losses", "QualityStarts", "Saves", "BlownSaves", "Holds", "InningsPitched", "HitsAllowed", "EarnedRuns", "HomeRunsAllowed", "BaseOnBallsAllowed", "StrikeOuts", "FlyBallRate", "GroundBallRate") VALUES ('a8fde7de-dd37-4bca-982e-7ac0d0916ea1', 1, 0, 0, 0, 0, 0, 1, 6, 3, 1, 1, 1, 6, 0.33, 0.46);
INSERT INTO public."PitchingStats" ("PlayerId", "StatsType", "Wins", "Losses", "QualityStarts", "Saves", "BlownSaves", "Holds", "InningsPitched", "HitsAllowed", "EarnedRuns", "HomeRunsAllowed", "BaseOnBallsAllowed", "StrikeOuts", "FlyBallRate", "GroundBallRate") VALUES ('aacc5ef2-96dd-4ca8-8e03-66973f50f002', 1, 0, 1, 0, 0, 0, 2, 5.2, 9, 6, 1, 3, 8, 0.22, 0.44);
INSERT INTO public."PitchingStats" ("PlayerId", "StatsType", "Wins", "Losses", "QualityStarts", "Saves", "BlownSaves", "Holds", "InningsPitched", "HitsAllowed", "EarnedRuns", "HomeRunsAllowed", "BaseOnBallsAllowed", "StrikeOuts", "FlyBallRate", "GroundBallRate") VALUES ('e6366fff-e824-496b-8d73-eb1d691fe51f', 2, 2, 2, 0, 9, 2, 12, 51, 33, 18, 2, 33, 72, 0.26, 0.53);
INSERT INTO public."PitchingStats" ("PlayerId", "StatsType", "Wins", "Losses", "QualityStarts", "Saves", "BlownSaves", "Holds", "InningsPitched", "HitsAllowed", "EarnedRuns", "HomeRunsAllowed", "BaseOnBallsAllowed", "StrikeOuts", "FlyBallRate", "GroundBallRate") VALUES ('efa00874-5c8e-428a-bf14-f15d68812975', 2, 7, 7, 10, 0, 0, 0, 147, 125, 62, 17, 56, 167, 0.41, 0.37);
INSERT INTO public."PitchingStats" ("PlayerId", "StatsType", "Wins", "Losses", "QualityStarts", "Saves", "BlownSaves", "Holds", "InningsPitched", "HitsAllowed", "EarnedRuns", "HomeRunsAllowed", "BaseOnBallsAllowed", "StrikeOuts", "FlyBallRate", "GroundBallRate") VALUES ('efce08f7-800a-4be5-a188-2cd796dc824b', 2, 3, 1, 0, 0, 3, 4, 38, 31, 15, 3, 17, 47, 0.36, 0.44);
INSERT INTO public."PitchingStats" ("PlayerId", "StatsType", "Wins", "Losses", "QualityStarts", "Saves", "BlownSaves", "Holds", "InningsPitched", "HitsAllowed", "EarnedRuns", "HomeRunsAllowed", "BaseOnBallsAllowed", "StrikeOuts", "FlyBallRate", "GroundBallRate") VALUES ('f1099553-5c27-4a12-a097-3939e919f804', 2, 1, 0, 0, 0, 0, 0, 13, 12, 5, 1, 4, 8, 0.36, 0.44);
INSERT INTO public."PitchingStats" ("PlayerId", "StatsType", "Wins", "Losses", "QualityStarts", "Saves", "BlownSaves", "Holds", "InningsPitched", "HitsAllowed", "EarnedRuns", "HomeRunsAllowed", "BaseOnBallsAllowed", "StrikeOuts", "FlyBallRate", "GroundBallRate") VALUES ('f43372b7-ae6f-4013-8351-ae4be4efbaa4', 2, 7, 7, 9, 0, 0, 0, 140, 141, 69, 17, 43, 125, 0.3, 0.5);
INSERT INTO public."PitchingStats" ("PlayerId", "StatsType", "Wins", "Losses", "QualityStarts", "Saves", "BlownSaves", "Holds", "InningsPitched", "HitsAllowed", "EarnedRuns", "HomeRunsAllowed", "BaseOnBallsAllowed", "StrikeOuts", "FlyBallRate", "GroundBallRate") VALUES ('f5b7aafd-b1f9-4bc5-a37b-e804874f90a0', 2, 3, 3, 0, 1, 4, 12, 51, 43, 19, 4, 20, 43, 0.23, 0.58);
INSERT INTO public."PitchingStats" ("PlayerId", "StatsType", "Wins", "Losses", "QualityStarts", "Saves", "BlownSaves", "Holds", "InningsPitched", "HitsAllowed", "EarnedRuns", "HomeRunsAllowed", "BaseOnBallsAllowed", "StrikeOuts", "FlyBallRate", "GroundBallRate") VALUES ('f97f940a-2af3-4ce4-aa9c-520dd836e69a', 2, 0, 0, 0, 0, 0, 0, 6, 4, 2, 0, 3, 7, 0.36, 0.44);
INSERT INTO public."PitchingStats" ("PlayerId", "StatsType", "Wins", "Losses", "QualityStarts", "Saves", "BlownSaves", "Holds", "InningsPitched", "HitsAllowed", "EarnedRuns", "HomeRunsAllowed", "BaseOnBallsAllowed", "StrikeOuts", "FlyBallRate", "GroundBallRate") VALUES ('b4e74de3-6c7d-42c6-9b6a-7270e2b22971', 1, 0, 1, 0, 0, 0, 0, 23.2, 20, 11, 2, 10, 22, 0.39, 0.3);
INSERT INTO public."PitchingStats" ("PlayerId", "StatsType", "Wins", "Losses", "QualityStarts", "Saves", "BlownSaves", "Holds", "InningsPitched", "HitsAllowed", "EarnedRuns", "HomeRunsAllowed", "BaseOnBallsAllowed", "StrikeOuts", "FlyBallRate", "GroundBallRate") VALUES ('c254c3ba-18a0-4f8f-bb4b-a7db2f020f0c', 1, 0, 0, 0, 3, 2, 0, 8.1, 8, 3, 1, 2, 10, 0.37, 0.37);
INSERT INTO public."PitchingStats" ("PlayerId", "StatsType", "Wins", "Losses", "QualityStarts", "Saves", "BlownSaves", "Holds", "InningsPitched", "HitsAllowed", "EarnedRuns", "HomeRunsAllowed", "BaseOnBallsAllowed", "StrikeOuts", "FlyBallRate", "GroundBallRate") VALUES ('01317e6c-91ca-410d-93d6-d3ee9c46b241', 2, 1, 1, 0, 0, 0, 0, 13, 15, 7, 1, 4, 7, 0.36, 0.44);
INSERT INTO public."PitchingStats" ("PlayerId", "StatsType", "Wins", "Losses", "QualityStarts", "Saves", "BlownSaves", "Holds", "InningsPitched", "HitsAllowed", "EarnedRuns", "HomeRunsAllowed", "BaseOnBallsAllowed", "StrikeOuts", "FlyBallRate", "GroundBallRate") VALUES ('139980d6-5eb2-4c52-ab6e-4730a21b7bb8', 2, 7, 7, 8, 1, 2, 0, 121, 106, 51, 12, 43, 133, 0.34, 0.48);
INSERT INTO public."PitchingStats" ("PlayerId", "StatsType", "Wins", "Losses", "QualityStarts", "Saves", "BlownSaves", "Holds", "InningsPitched", "HitsAllowed", "EarnedRuns", "HomeRunsAllowed", "BaseOnBallsAllowed", "StrikeOuts", "FlyBallRate", "GroundBallRate") VALUES ('19347bdc-b38e-49bb-9938-1e004bd5bcb8', 2, 4, 4, 0, 26, 4, 0, 57, 47, 19, 8, 14, 75, 0.4, 0.39);
INSERT INTO public."PitchingStats" ("PlayerId", "StatsType", "Wins", "Losses", "QualityStarts", "Saves", "BlownSaves", "Holds", "InningsPitched", "HitsAllowed", "EarnedRuns", "HomeRunsAllowed", "BaseOnBallsAllowed", "StrikeOuts", "FlyBallRate", "GroundBallRate") VALUES ('1aa5b3dd-c616-4f3e-8bee-6a210467f4da', 2, 8, 8, 8, 0, 0, 0, 128, 128, 61, 20, 38, 108, 0.38, 0.43);
INSERT INTO public."PitchingStats" ("PlayerId", "StatsType", "Wins", "Losses", "QualityStarts", "Saves", "BlownSaves", "Holds", "InningsPitched", "HitsAllowed", "EarnedRuns", "HomeRunsAllowed", "BaseOnBallsAllowed", "StrikeOuts", "FlyBallRate", "GroundBallRate") VALUES ('213c94cc-26b3-42b9-8544-eb6c34cabffb', 2, 9, 6, 10, 0, 0, 0, 128, 113, 60, 18, 51, 172, 0.47, 0.34);
INSERT INTO public."PitchingStats" ("PlayerId", "StatsType", "Wins", "Losses", "QualityStarts", "Saves", "BlownSaves", "Holds", "InningsPitched", "HitsAllowed", "EarnedRuns", "HomeRunsAllowed", "BaseOnBallsAllowed", "StrikeOuts", "FlyBallRate", "GroundBallRate") VALUES ('21abe7f6-ce67-4138-90ad-eb3579ef3530', 2, 4, 2, 0, 22, 3, 4, 57, 39, 18, 4, 20, 75, 0.26, 0.5);
INSERT INTO public."PitchingStats" ("PlayerId", "StatsType", "Wins", "Losses", "QualityStarts", "Saves", "BlownSaves", "Holds", "InningsPitched", "HitsAllowed", "EarnedRuns", "HomeRunsAllowed", "BaseOnBallsAllowed", "StrikeOuts", "FlyBallRate", "GroundBallRate") VALUES ('22459580-ed4c-4809-a345-4f1c9abda82c', 2, 2, 5, 4, 0, 0, 0, 64, 57, 38, 10, 25, 57, 0.34, 0.44);
INSERT INTO public."PitchingStats" ("PlayerId", "StatsType", "Wins", "Losses", "QualityStarts", "Saves", "BlownSaves", "Holds", "InningsPitched", "HitsAllowed", "EarnedRuns", "HomeRunsAllowed", "BaseOnBallsAllowed", "StrikeOuts", "FlyBallRate", "GroundBallRate") VALUES ('25ae92fd-8592-4917-b051-8f71928a070c', 2, 4, 4, 0, 0, 1, 0, 89, 93, 39, 12, 24, 90, 0.36, 0.43);
INSERT INTO public."PitchingStats" ("PlayerId", "StatsType", "Wins", "Losses", "QualityStarts", "Saves", "BlownSaves", "Holds", "InningsPitched", "HitsAllowed", "EarnedRuns", "HomeRunsAllowed", "BaseOnBallsAllowed", "StrikeOuts", "FlyBallRate", "GroundBallRate") VALUES ('25e3a5de-4fae-4788-920e-20cd919acc0b', 2, 3, 3, 4, 0, 0, 0, 38, 28, 13, 3, 6, 57, 0.4, 0.41);
INSERT INTO public."PitchingStats" ("PlayerId", "StatsType", "Wins", "Losses", "QualityStarts", "Saves", "BlownSaves", "Holds", "InningsPitched", "HitsAllowed", "EarnedRuns", "HomeRunsAllowed", "BaseOnBallsAllowed", "StrikeOuts", "FlyBallRate", "GroundBallRate") VALUES ('2742eeb2-bcb4-4241-b934-fd6addc66352', 2, 0, 0, 0, 0, 0, 0, 6, 9, 4, 1, 3, 5, 0.36, 0.44);
INSERT INTO public."PitchingStats" ("PlayerId", "StatsType", "Wins", "Losses", "QualityStarts", "Saves", "BlownSaves", "Holds", "InningsPitched", "HitsAllowed", "EarnedRuns", "HomeRunsAllowed", "BaseOnBallsAllowed", "StrikeOuts", "FlyBallRate", "GroundBallRate") VALUES ('30233b7f-5a84-47ad-a453-551c36929666', 2, 8, 6, 7, 0, 0, 0, 115, 117, 50, 13, 38, 77, 0.34, 0.48);
INSERT INTO public."PitchingStats" ("PlayerId", "StatsType", "Wins", "Losses", "QualityStarts", "Saves", "BlownSaves", "Holds", "InningsPitched", "HitsAllowed", "EarnedRuns", "HomeRunsAllowed", "BaseOnBallsAllowed", "StrikeOuts", "FlyBallRate", "GroundBallRate") VALUES ('31e9da1c-6f0e-4e17-b880-7bf3a4d3ba3d', 2, 3, 3, 0, 29, 4, 0, 57, 38, 18, 5, 18, 93, 0.39, 0.41);
INSERT INTO public."PitchingStats" ("PlayerId", "StatsType", "Wins", "Losses", "QualityStarts", "Saves", "BlownSaves", "Holds", "InningsPitched", "HitsAllowed", "EarnedRuns", "HomeRunsAllowed", "BaseOnBallsAllowed", "StrikeOuts", "FlyBallRate", "GroundBallRate") VALUES ('40cd2ee1-9c4d-44ec-87c3-407ac5b1523a', 2, 4, 3, 0, 6, 2, 12, 51, 46, 19, 5, 13, 47, 0.38, 0.46);
INSERT INTO public."PitchingStats" ("PlayerId", "StatsType", "Wins", "Losses", "QualityStarts", "Saves", "BlownSaves", "Holds", "InningsPitched", "HitsAllowed", "EarnedRuns", "HomeRunsAllowed", "BaseOnBallsAllowed", "StrikeOuts", "FlyBallRate", "GroundBallRate") VALUES ('40e2f815-821c-40dd-a33f-a037a3f238e5', 2, 3, 3, 0, 26, 4, 8, 51, 34, 16, 4, 19, 72, 0.32, 0.47);
INSERT INTO public."PitchingStats" ("PlayerId", "StatsType", "Wins", "Losses", "QualityStarts", "Saves", "BlownSaves", "Holds", "InningsPitched", "HitsAllowed", "EarnedRuns", "HomeRunsAllowed", "BaseOnBallsAllowed", "StrikeOuts", "FlyBallRate", "GroundBallRate") VALUES ('410fd6d5-bd15-4618-96f4-3ff12a803795', 2, 3, 0, 0, 0, 0, 0, 38, 38, 17, 4, 14, 41, 0.36, 0.44);
INSERT INTO public."PitchingStats" ("PlayerId", "StatsType", "Wins", "Losses", "QualityStarts", "Saves", "BlownSaves", "Holds", "InningsPitched", "HitsAllowed", "EarnedRuns", "HomeRunsAllowed", "BaseOnBallsAllowed", "StrikeOuts", "FlyBallRate", "GroundBallRate") VALUES ('44c34d0e-1cb0-4582-be47-080949e0061b', 2, 2, 2, 0, 1, 1, 16, 38, 31, 13, 2, 9, 30, 0.22, 0.63);
INSERT INTO public."PitchingStats" ("PlayerId", "StatsType", "Wins", "Losses", "QualityStarts", "Saves", "BlownSaves", "Holds", "InningsPitched", "HitsAllowed", "EarnedRuns", "HomeRunsAllowed", "BaseOnBallsAllowed", "StrikeOuts", "FlyBallRate", "GroundBallRate") VALUES ('4656ff39-53bc-4ce1-a87f-5c0431ffcf3f', 2, 4, 3, 0, 0, 0, 8, 51, 54, 26, 8, 14, 38, 0.41, 0.39);
INSERT INTO public."PitchingStats" ("PlayerId", "StatsType", "Wins", "Losses", "QualityStarts", "Saves", "BlownSaves", "Holds", "InningsPitched", "HitsAllowed", "EarnedRuns", "HomeRunsAllowed", "BaseOnBallsAllowed", "StrikeOuts", "FlyBallRate", "GroundBallRate") VALUES ('4bbd13bd-2559-4b5f-bc42-3a0b730113ff', 2, 2, 1, 0, 12, 1, 4, 26, 16, 7, 2, 12, 39, 0.32, 0.48);
INSERT INTO public."PitchingStats" ("PlayerId", "StatsType", "Wins", "Losses", "QualityStarts", "Saves", "BlownSaves", "Holds", "InningsPitched", "HitsAllowed", "EarnedRuns", "HomeRunsAllowed", "BaseOnBallsAllowed", "StrikeOuts", "FlyBallRate", "GroundBallRate") VALUES ('5136c058-282b-4c37-bba2-56f7408c7803', 2, 2, 2, 0, 0, 0, 12, 45, 37, 18, 5, 16, 57, 0.38, 0.4);
INSERT INTO public."PitchingStats" ("PlayerId", "StatsType", "Wins", "Losses", "QualityStarts", "Saves", "BlownSaves", "Holds", "InningsPitched", "HitsAllowed", "EarnedRuns", "HomeRunsAllowed", "BaseOnBallsAllowed", "StrikeOuts", "FlyBallRate", "GroundBallRate") VALUES ('5169be32-19c3-477e-a8c8-dda1980be29b', 2, 3, 3, 0, 26, 4, 7, 51, 37, 16, 4, 19, 67, 0.28, 0.56);
INSERT INTO public."PitchingStats" ("PlayerId", "StatsType", "Wins", "Losses", "QualityStarts", "Saves", "BlownSaves", "Holds", "InningsPitched", "HitsAllowed", "EarnedRuns", "HomeRunsAllowed", "BaseOnBallsAllowed", "StrikeOuts", "FlyBallRate", "GroundBallRate") VALUES ('c81dd2ce-130a-46a9-87f7-32caf8478b49', 1, 3, 1, 0, 0, 0, 0, 29, 19, 12, 4, 9, 34, 0.37, 0.4);
INSERT INTO public."PitchingStats" ("PlayerId", "StatsType", "Wins", "Losses", "QualityStarts", "Saves", "BlownSaves", "Holds", "InningsPitched", "HitsAllowed", "EarnedRuns", "HomeRunsAllowed", "BaseOnBallsAllowed", "StrikeOuts", "FlyBallRate", "GroundBallRate") VALUES ('db291251-e95e-4334-92f0-606d7bda7aef', 1, 0, 1, 0, 0, 0, 0, 3.2, 6, 4, 1, 2, 2, 0.11, 0.66);
INSERT INTO public."PitchingStats" ("PlayerId", "StatsType", "Wins", "Losses", "QualityStarts", "Saves", "BlownSaves", "Holds", "InningsPitched", "HitsAllowed", "EarnedRuns", "HomeRunsAllowed", "BaseOnBallsAllowed", "StrikeOuts", "FlyBallRate", "GroundBallRate") VALUES ('5578672e-d4a9-495c-8aaa-d0a9824a4a37', 2, 3, 3, 0, 29, 6, 0, 57, 49, 19, 3, 11, 55, 0.23, 0.59);
INSERT INTO public."PitchingStats" ("PlayerId", "StatsType", "Wins", "Losses", "QualityStarts", "Saves", "BlownSaves", "Holds", "InningsPitched", "HitsAllowed", "EarnedRuns", "HomeRunsAllowed", "BaseOnBallsAllowed", "StrikeOuts", "FlyBallRate", "GroundBallRate") VALUES ('6040b76b-0674-45da-9349-d90d2e3ccf64', 2, 2, 2, 0, 0, 2, 0, 38, 38, 17, 4, 17, 38, 0.36, 0.44);
INSERT INTO public."PitchingStats" ("PlayerId", "StatsType", "Wins", "Losses", "QualityStarts", "Saves", "BlownSaves", "Holds", "InningsPitched", "HitsAllowed", "EarnedRuns", "HomeRunsAllowed", "BaseOnBallsAllowed", "StrikeOuts", "FlyBallRate", "GroundBallRate") VALUES ('61795270-ae6d-488d-8f8b-8f9a1d10730d', 2, 2, 2, 0, 0, 2, 12, 51, 48, 19, 5, 9, 46, 0.34, 0.51);
INSERT INTO public."PitchingStats" ("PlayerId", "StatsType", "Wins", "Losses", "QualityStarts", "Saves", "BlownSaves", "Holds", "InningsPitched", "HitsAllowed", "EarnedRuns", "HomeRunsAllowed", "BaseOnBallsAllowed", "StrikeOuts", "FlyBallRate", "GroundBallRate") VALUES ('69034182-a2d7-4840-82b6-c67dcd39634e', 2, 5, 4, 9, 0, 0, 0, 89, 76, 37, 14, 23, 102, 0.48, 0.33);
INSERT INTO public."PitchingStats" ("PlayerId", "StatsType", "Wins", "Losses", "QualityStarts", "Saves", "BlownSaves", "Holds", "InningsPitched", "HitsAllowed", "EarnedRuns", "HomeRunsAllowed", "BaseOnBallsAllowed", "StrikeOuts", "FlyBallRate", "GroundBallRate") VALUES ('6be652db-a1d2-4aad-afe8-98bd04170e8a', 2, 10, 8, 10, 0, 0, 0, 140, 105, 56, 18, 48, 181, 0.42, 0.39);
INSERT INTO public."PitchingStats" ("PlayerId", "StatsType", "Wins", "Losses", "QualityStarts", "Saves", "BlownSaves", "Holds", "InningsPitched", "HitsAllowed", "EarnedRuns", "HomeRunsAllowed", "BaseOnBallsAllowed", "StrikeOuts", "FlyBallRate", "GroundBallRate") VALUES ('77571748-f98b-46a2-b99c-01e01a220fc9', 2, 1, 1, 0, 1, 1, 4, 32, 26, 11, 3, 7, 40, 0.36, 0.44);
INSERT INTO public."PitchingStats" ("PlayerId", "StatsType", "Wins", "Losses", "QualityStarts", "Saves", "BlownSaves", "Holds", "InningsPitched", "HitsAllowed", "EarnedRuns", "HomeRunsAllowed", "BaseOnBallsAllowed", "StrikeOuts", "FlyBallRate", "GroundBallRate") VALUES ('7afbc714-c48a-4052-aab2-4da66c5059df', 2, 10, 8, 11, 0, 0, 0, 140, 117, 50, 16, 34, 153, 0.32, 0.46);
INSERT INTO public."PitchingStats" ("PlayerId", "StatsType", "Wins", "Losses", "QualityStarts", "Saves", "BlownSaves", "Holds", "InningsPitched", "HitsAllowed", "EarnedRuns", "HomeRunsAllowed", "BaseOnBallsAllowed", "StrikeOuts", "FlyBallRate", "GroundBallRate") VALUES ('80967cf1-c8c2-4ac1-92a2-615207ef7734', 2, 5, 4, 8, 0, 0, 0, 102, 93, 45, 9, 39, 100, 0.28, 0.53);
INSERT INTO public."PitchingStats" ("PlayerId", "StatsType", "Wins", "Losses", "QualityStarts", "Saves", "BlownSaves", "Holds", "InningsPitched", "HitsAllowed", "EarnedRuns", "HomeRunsAllowed", "BaseOnBallsAllowed", "StrikeOuts", "FlyBallRate", "GroundBallRate") VALUES ('82b81710-c5c4-4b08-9cc1-1419f5ffd382', 2, 1, 1, 0, 0, 1, 4, 19, 19, 11, 4, 8, 21, 0.45, 0.34);
INSERT INTO public."PitchingStats" ("PlayerId", "StatsType", "Wins", "Losses", "QualityStarts", "Saves", "BlownSaves", "Holds", "InningsPitched", "HitsAllowed", "EarnedRuns", "HomeRunsAllowed", "BaseOnBallsAllowed", "StrikeOuts", "FlyBallRate", "GroundBallRate") VALUES ('83d9f9c9-9f5d-4d25-af3b-9af30700b82a', 2, 2, 2, 0, 7, 5, 18, 45, 38, 18, 6, 10, 52, 0.48, 0.34);
INSERT INTO public."PitchingStats" ("PlayerId", "StatsType", "Wins", "Losses", "QualityStarts", "Saves", "BlownSaves", "Holds", "InningsPitched", "HitsAllowed", "EarnedRuns", "HomeRunsAllowed", "BaseOnBallsAllowed", "StrikeOuts", "FlyBallRate", "GroundBallRate") VALUES ('85a74a1f-d654-4c39-830e-105e384937eb', 2, 8, 7, 7, 0, 1, 0, 121, 102, 53, 17, 39, 139, 0.41, 0.38);
INSERT INTO public."PitchingStats" ("PlayerId", "StatsType", "Wins", "Losses", "QualityStarts", "Saves", "BlownSaves", "Holds", "InningsPitched", "HitsAllowed", "EarnedRuns", "HomeRunsAllowed", "BaseOnBallsAllowed", "StrikeOuts", "FlyBallRate", "GroundBallRate") VALUES ('e48f6045-a7da-4b8a-b2ee-d4aeac401f6a', 1, 0, 0, 0, 0, 1, 0, 4, 3, 3, 1, 2, 4, 0.54, 0.18);
INSERT INTO public."PitchingStats" ("PlayerId", "StatsType", "Wins", "Losses", "QualityStarts", "Saves", "BlownSaves", "Holds", "InningsPitched", "HitsAllowed", "EarnedRuns", "HomeRunsAllowed", "BaseOnBallsAllowed", "StrikeOuts", "FlyBallRate", "GroundBallRate") VALUES ('a25cf946-49af-4faa-8049-601142377ab8', 2, 2, 2, 0, 4, 3, 4, 38, 28, 13, 5, 9, 50, 0.46, 0.35);
INSERT INTO public."PitchingStats" ("PlayerId", "StatsType", "Wins", "Losses", "QualityStarts", "Saves", "BlownSaves", "Holds", "InningsPitched", "HitsAllowed", "EarnedRuns", "HomeRunsAllowed", "BaseOnBallsAllowed", "StrikeOuts", "FlyBallRate", "GroundBallRate") VALUES ('e6366fff-e824-496b-8d73-eb1d691fe51f', 1, 1, 1, 0, 3, 2, 0, 6, 8, 5, 1, 3, 5, 0.21, 0.57);
INSERT INTO public."PitchingStats" ("PlayerId", "StatsType", "Wins", "Losses", "QualityStarts", "Saves", "BlownSaves", "Holds", "InningsPitched", "HitsAllowed", "EarnedRuns", "HomeRunsAllowed", "BaseOnBallsAllowed", "StrikeOuts", "FlyBallRate", "GroundBallRate") VALUES ('efa00874-5c8e-428a-bf14-f15d68812975', 1, 3, 0, 0, 0, 0, 0, 17.1, 8, 2, 0, 6, 26, 0.35, 0.41);
INSERT INTO public."PitchingStats" ("PlayerId", "StatsType", "Wins", "Losses", "QualityStarts", "Saves", "BlownSaves", "Holds", "InningsPitched", "HitsAllowed", "EarnedRuns", "HomeRunsAllowed", "BaseOnBallsAllowed", "StrikeOuts", "FlyBallRate", "GroundBallRate") VALUES ('efce08f7-800a-4be5-a188-2cd796dc824b', 1, 0, 0, 0, 0, 0, 2, 7, 5, 1, 1, 1, 8, 0.22, 0.44);
INSERT INTO public."PitchingStats" ("PlayerId", "StatsType", "Wins", "Losses", "QualityStarts", "Saves", "BlownSaves", "Holds", "InningsPitched", "HitsAllowed", "EarnedRuns", "HomeRunsAllowed", "BaseOnBallsAllowed", "StrikeOuts", "FlyBallRate", "GroundBallRate") VALUES ('f43372b7-ae6f-4013-8351-ae4be4efbaa4', 1, 2, 0, 0, 0, 0, 0, 18.1, 10, 2, 2, 4, 18, 0.26, 0.65);
INSERT INTO public."PitchingStats" ("PlayerId", "StatsType", "Wins", "Losses", "QualityStarts", "Saves", "BlownSaves", "Holds", "InningsPitched", "HitsAllowed", "EarnedRuns", "HomeRunsAllowed", "BaseOnBallsAllowed", "StrikeOuts", "FlyBallRate", "GroundBallRate") VALUES ('f5b7aafd-b1f9-4bc5-a37b-e804874f90a0', 1, 3, 0, 0, 0, 0, 1, 8, 6, 2, 0, 2, 9, 0.28, 0.57);
INSERT INTO public."PitchingStats" ("PlayerId", "StatsType", "Wins", "Losses", "QualityStarts", "Saves", "BlownSaves", "Holds", "InningsPitched", "HitsAllowed", "EarnedRuns", "HomeRunsAllowed", "BaseOnBallsAllowed", "StrikeOuts", "FlyBallRate", "GroundBallRate") VALUES ('a8fde7de-dd37-4bca-982e-7ac0d0916ea1', 2, 1, 1, 0, 0, 0, 0, 13, 14, 6, 1, 4, 12, 0.36, 0.44);
INSERT INTO public."PitchingStats" ("PlayerId", "StatsType", "Wins", "Losses", "QualityStarts", "Saves", "BlownSaves", "Holds", "InningsPitched", "HitsAllowed", "EarnedRuns", "HomeRunsAllowed", "BaseOnBallsAllowed", "StrikeOuts", "FlyBallRate", "GroundBallRate") VALUES ('aacc5ef2-96dd-4ca8-8e03-66973f50f002', 2, 4, 4, 0, 8, 4, 21, 51, 40, 19, 5, 12, 62, 0.3, 0.52);
INSERT INTO public."PitchingStats" ("PlayerId", "StatsType", "Wins", "Losses", "QualityStarts", "Saves", "BlownSaves", "Holds", "InningsPitched", "HitsAllowed", "EarnedRuns", "HomeRunsAllowed", "BaseOnBallsAllowed", "StrikeOuts", "FlyBallRate", "GroundBallRate") VALUES ('ad69f157-23d5-4c6e-91bf-d5fb00747a87', 2, 0, 0, 0, 0, 0, 0, 6, 6, 3, 1, 4, 5, 0.41, 0.39);
INSERT INTO public."PitchingStats" ("PlayerId", "StatsType", "Wins", "Losses", "QualityStarts", "Saves", "BlownSaves", "Holds", "InningsPitched", "HitsAllowed", "EarnedRuns", "HomeRunsAllowed", "BaseOnBallsAllowed", "StrikeOuts", "FlyBallRate", "GroundBallRate") VALUES ('b4e74de3-6c7d-42c6-9b6a-7270e2b22971', 2, 9, 6, 11, 0, 0, 0, 140, 126, 61, 18, 39, 153, 0.38, 0.4);
INSERT INTO public."PitchingStats" ("PlayerId", "StatsType", "Wins", "Losses", "QualityStarts", "Saves", "BlownSaves", "Holds", "InningsPitched", "HitsAllowed", "EarnedRuns", "HomeRunsAllowed", "BaseOnBallsAllowed", "StrikeOuts", "FlyBallRate", "GroundBallRate") VALUES ('c254c3ba-18a0-4f8f-bb4b-a7db2f020f0c', 2, 5, 3, 0, 16, 2, 11, 57, 44, 18, 4, 21, 65, 0.35, 0.49);
INSERT INTO public."PitchingStats" ("PlayerId", "StatsType", "Wins", "Losses", "QualityStarts", "Saves", "BlownSaves", "Holds", "InningsPitched", "HitsAllowed", "EarnedRuns", "HomeRunsAllowed", "BaseOnBallsAllowed", "StrikeOuts", "FlyBallRate", "GroundBallRate") VALUES ('c81dd2ce-130a-46a9-87f7-32caf8478b49', 2, 10, 6, 12, 0, 0, 0, 128, 98, 49, 19, 42, 172, 0.34, 0.46);
INSERT INTO public."PitchingStats" ("PlayerId", "StatsType", "Wins", "Losses", "QualityStarts", "Saves", "BlownSaves", "Holds", "InningsPitched", "HitsAllowed", "EarnedRuns", "HomeRunsAllowed", "BaseOnBallsAllowed", "StrikeOuts", "FlyBallRate", "GroundBallRate") VALUES ('db291251-e95e-4334-92f0-606d7bda7aef', 2, 5, 5, 6, 0, 1, 0, 102, 89, 44, 12, 48, 109, 0.27, 0.57);


--
-- TOC entry 3354 (class 0 OID 16394)
-- Dependencies: 212
-- Data for Name: PlayerPositionEntity; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public."PlayerPositionEntity" ("PlayerId", "PositionCode") VALUES ('3c88638b-291f-45f8-8bb2-a11d403604c5', 'OF');
INSERT INTO public."PlayerPositionEntity" ("PlayerId", "PositionCode") VALUES ('d3bcbd0a-4ad2-4604-b82b-c9620013260b', '2B');
INSERT INTO public."PlayerPositionEntity" ("PlayerId", "PositionCode") VALUES ('d3bcbd0a-4ad2-4604-b82b-c9620013260b', 'SS');
INSERT INTO public."PlayerPositionEntity" ("PlayerId", "PositionCode") VALUES ('51a61d66-e85b-480a-bbf8-995dd0436f29', 'C');
INSERT INTO public."PlayerPositionEntity" ("PlayerId", "PositionCode") VALUES ('82b81710-c5c4-4b08-9cc1-1419f5ffd382', 'RP');
INSERT INTO public."PlayerPositionEntity" ("PlayerId", "PositionCode") VALUES ('5578672e-d4a9-495c-8aaa-d0a9824a4a37', 'RP');
INSERT INTO public."PlayerPositionEntity" ("PlayerId", "PositionCode") VALUES ('83d9f9c9-9f5d-4d25-af3b-9af30700b82a', 'RP');
INSERT INTO public."PlayerPositionEntity" ("PlayerId", "PositionCode") VALUES ('6d56f922-c389-4716-950b-2fa0073cda78', '3B');
INSERT INTO public."PlayerPositionEntity" ("PlayerId", "PositionCode") VALUES ('6d56f922-c389-4716-950b-2fa0073cda78', 'SS');
INSERT INTO public."PlayerPositionEntity" ("PlayerId", "PositionCode") VALUES ('647cdd37-00ae-46b6-b69d-7a76174f71b3', 'OF');
INSERT INTO public."PlayerPositionEntity" ("PlayerId", "PositionCode") VALUES ('db291251-e95e-4334-92f0-606d7bda7aef', 'SP');
INSERT INTO public."PlayerPositionEntity" ("PlayerId", "PositionCode") VALUES ('7106b85c-47e2-4e4f-95a3-2e0d72f252e4', 'OF');
INSERT INTO public."PlayerPositionEntity" ("PlayerId", "PositionCode") VALUES ('b4e74de3-6c7d-42c6-9b6a-7270e2b22971', 'SP');
INSERT INTO public."PlayerPositionEntity" ("PlayerId", "PositionCode") VALUES ('efa00874-5c8e-428a-bf14-f15d68812975', 'SP');
INSERT INTO public."PlayerPositionEntity" ("PlayerId", "PositionCode") VALUES ('31e9da1c-6f0e-4e17-b880-7bf3a4d3ba3d', 'RP');
INSERT INTO public."PlayerPositionEntity" ("PlayerId", "PositionCode") VALUES ('410fd6d5-bd15-4618-96f4-3ff12a803795', 'SP');
INSERT INTO public."PlayerPositionEntity" ("PlayerId", "PositionCode") VALUES ('c254c3ba-18a0-4f8f-bb4b-a7db2f020f0c', 'RP');
INSERT INTO public."PlayerPositionEntity" ("PlayerId", "PositionCode") VALUES ('c81dd2ce-130a-46a9-87f7-32caf8478b49', 'SP');
INSERT INTO public."PlayerPositionEntity" ("PlayerId", "PositionCode") VALUES ('80967cf1-c8c2-4ac1-92a2-615207ef7734', 'SP');
INSERT INTO public."PlayerPositionEntity" ("PlayerId", "PositionCode") VALUES ('efce08f7-800a-4be5-a188-2cd796dc824b', 'RP');
INSERT INTO public."PlayerPositionEntity" ("PlayerId", "PositionCode") VALUES ('4bbd13bd-2559-4b5f-bc42-3a0b730113ff', 'RP');
INSERT INTO public."PlayerPositionEntity" ("PlayerId", "PositionCode") VALUES ('4947afdf-6d0d-4d36-a656-d1687789cfd8', 'OF');
INSERT INTO public."PlayerPositionEntity" ("PlayerId", "PositionCode") VALUES ('61795270-ae6d-488d-8f8b-8f9a1d10730d', 'RP');
INSERT INTO public."PlayerPositionEntity" ("PlayerId", "PositionCode") VALUES ('973e9c12-762b-4303-aea4-65bed4c4edd2', 'OF');
INSERT INTO public."PlayerPositionEntity" ("PlayerId", "PositionCode") VALUES ('a8fde7de-dd37-4bca-982e-7ac0d0916ea1', 'RP');
INSERT INTO public."PlayerPositionEntity" ("PlayerId", "PositionCode") VALUES ('19347bdc-b38e-49bb-9938-1e004bd5bcb8', 'RP');
INSERT INTO public."PlayerPositionEntity" ("PlayerId", "PositionCode") VALUES ('cddc33ec-062e-4779-8057-75cd691c8abb', 'SS');
INSERT INTO public."PlayerPositionEntity" ("PlayerId", "PositionCode") VALUES ('5b92e19b-3bfd-40dd-9546-73cccede2638', '2B');
INSERT INTO public."PlayerPositionEntity" ("PlayerId", "PositionCode") VALUES ('da2190fb-0dbd-4edc-8d83-e7808266d630', '1B');
INSERT INTO public."PlayerPositionEntity" ("PlayerId", "PositionCode") VALUES ('da2190fb-0dbd-4edc-8d83-e7808266d630', 'OF');
INSERT INTO public."PlayerPositionEntity" ("PlayerId", "PositionCode") VALUES ('fba56342-e6ef-41d1-a393-c62a85df7f92', '1B');
INSERT INTO public."PlayerPositionEntity" ("PlayerId", "PositionCode") VALUES ('fba56342-e6ef-41d1-a393-c62a85df7f92', 'OF');
INSERT INTO public."PlayerPositionEntity" ("PlayerId", "PositionCode") VALUES ('b6832adf-a496-4d5d-81e7-605030a0e028', '2B');
INSERT INTO public."PlayerPositionEntity" ("PlayerId", "PositionCode") VALUES ('b6832adf-a496-4d5d-81e7-605030a0e028', '3B');
INSERT INTO public."PlayerPositionEntity" ("PlayerId", "PositionCode") VALUES ('b5df2e6f-cccc-42f9-ac06-0a505fa724ae', '3B');
INSERT INTO public."PlayerPositionEntity" ("PlayerId", "PositionCode") VALUES ('9d7257bc-e6a4-46bc-9200-91b73f437a82', '2B');
INSERT INTO public."PlayerPositionEntity" ("PlayerId", "PositionCode") VALUES ('9d7257bc-e6a4-46bc-9200-91b73f437a82', '3B');
INSERT INTO public."PlayerPositionEntity" ("PlayerId", "PositionCode") VALUES ('9d7257bc-e6a4-46bc-9200-91b73f437a82', 'OF');
INSERT INTO public."PlayerPositionEntity" ("PlayerId", "PositionCode") VALUES ('9d7257bc-e6a4-46bc-9200-91b73f437a82', 'SS');
INSERT INTO public."PlayerPositionEntity" ("PlayerId", "PositionCode") VALUES ('9e6a26f6-e752-43ae-9327-9092c51ce23a', '1B');
INSERT INTO public."PlayerPositionEntity" ("PlayerId", "PositionCode") VALUES ('82ce40a9-45cd-453c-ab03-0fcfba2b62d9', 'OF');
INSERT INTO public."PlayerPositionEntity" ("PlayerId", "PositionCode") VALUES ('01317e6c-91ca-410d-93d6-d3ee9c46b241', 'P');
INSERT INTO public."PlayerPositionEntity" ("PlayerId", "PositionCode") VALUES ('77571748-f98b-46a2-b99c-01e01a220fc9', 'RP');
INSERT INTO public."PlayerPositionEntity" ("PlayerId", "PositionCode") VALUES ('b5df2e6f-cccc-42f9-ac06-0a505fa724ae', '1B');
INSERT INTO public."PlayerPositionEntity" ("PlayerId", "PositionCode") VALUES ('e48f6045-a7da-4b8a-b2ee-d4aeac401f6a', 'RP');
INSERT INTO public."PlayerPositionEntity" ("PlayerId", "PositionCode") VALUES ('2742eeb2-bcb4-4241-b934-fd6addc66352', 'RP');
INSERT INTO public."PlayerPositionEntity" ("PlayerId", "PositionCode") VALUES ('6102c1c5-0022-4a73-93cd-ead484f4e735', 'OF');
INSERT INTO public."PlayerPositionEntity" ("PlayerId", "PositionCode") VALUES ('f97f940a-2af3-4ce4-aa9c-520dd836e69a', 'SP');
INSERT INTO public."PlayerPositionEntity" ("PlayerId", "PositionCode") VALUES ('22459580-ed4c-4809-a345-4f1c9abda82c', 'SP');
INSERT INTO public."PlayerPositionEntity" ("PlayerId", "PositionCode") VALUES ('4656ff39-53bc-4ce1-a87f-5c0431ffcf3f', 'RP');
INSERT INTO public."PlayerPositionEntity" ("PlayerId", "PositionCode") VALUES ('5b92e19b-3bfd-40dd-9546-73cccede2638', '1B');
INSERT INTO public."PlayerPositionEntity" ("PlayerId", "PositionCode") VALUES ('cefdf564-6134-4030-b384-c3f6c9285114', '3B');
INSERT INTO public."PlayerPositionEntity" ("PlayerId", "PositionCode") VALUES ('5169be32-19c3-477e-a8c8-dda1980be29b', 'RP');
INSERT INTO public."PlayerPositionEntity" ("PlayerId", "PositionCode") VALUES ('139980d6-5eb2-4c52-ab6e-4730a21b7bb8', 'SP');
INSERT INTO public."PlayerPositionEntity" ("PlayerId", "PositionCode") VALUES ('e6366fff-e824-496b-8d73-eb1d691fe51f', 'RP');
INSERT INTO public."PlayerPositionEntity" ("PlayerId", "PositionCode") VALUES ('25e3a5de-4fae-4788-920e-20cd919acc0b', 'SP');
INSERT INTO public."PlayerPositionEntity" ("PlayerId", "PositionCode") VALUES ('40cd2ee1-9c4d-44ec-87c3-407ac5b1523a', 'RP');
INSERT INTO public."PlayerPositionEntity" ("PlayerId", "PositionCode") VALUES ('f5b7aafd-b1f9-4bc5-a37b-e804874f90a0', 'RP');
INSERT INTO public."PlayerPositionEntity" ("PlayerId", "PositionCode") VALUES ('69034182-a2d7-4840-82b6-c67dcd39634e', 'SP');
INSERT INTO public."PlayerPositionEntity" ("PlayerId", "PositionCode") VALUES ('ad69f157-23d5-4c6e-91bf-d5fb00747a87', 'P');
INSERT INTO public."PlayerPositionEntity" ("PlayerId", "PositionCode") VALUES ('21abe7f6-ce67-4138-90ad-eb3579ef3530', 'RP');
INSERT INTO public."PlayerPositionEntity" ("PlayerId", "PositionCode") VALUES ('a25cf946-49af-4faa-8049-601142377ab8', 'RP');
INSERT INTO public."PlayerPositionEntity" ("PlayerId", "PositionCode") VALUES ('6040b76b-0674-45da-9349-d90d2e3ccf64', 'RP');
INSERT INTO public."PlayerPositionEntity" ("PlayerId", "PositionCode") VALUES ('4707d3a6-35cc-4f86-88f3-122e83de82b9', '2B');
INSERT INTO public."PlayerPositionEntity" ("PlayerId", "PositionCode") VALUES ('4707d3a6-35cc-4f86-88f3-122e83de82b9', '3B');
INSERT INTO public."PlayerPositionEntity" ("PlayerId", "PositionCode") VALUES ('6be652db-a1d2-4aad-afe8-98bd04170e8a', 'SP');
INSERT INTO public."PlayerPositionEntity" ("PlayerId", "PositionCode") VALUES ('85a74a1f-d654-4c39-830e-105e384937eb', 'RP');
INSERT INTO public."PlayerPositionEntity" ("PlayerId", "PositionCode") VALUES ('85a74a1f-d654-4c39-830e-105e384937eb', 'SP');
INSERT INTO public."PlayerPositionEntity" ("PlayerId", "PositionCode") VALUES ('f1099553-5c27-4a12-a097-3939e919f804', 'P');
INSERT INTO public."PlayerPositionEntity" ("PlayerId", "PositionCode") VALUES ('c4a6ee18-6242-4501-b781-b1b7f2b27e49', 'OF');
INSERT INTO public."PlayerPositionEntity" ("PlayerId", "PositionCode") VALUES ('9bd677e7-ba97-4bd7-89e8-5cf61dedba78', '1B');
INSERT INTO public."PlayerPositionEntity" ("PlayerId", "PositionCode") VALUES ('9ff79a30-3c1b-44c7-96a0-d33633c847df', 'OF');
INSERT INTO public."PlayerPositionEntity" ("PlayerId", "PositionCode") VALUES ('e3090c33-043b-4f89-a6ad-955b1b4b7c6d', '2B');
INSERT INTO public."PlayerPositionEntity" ("PlayerId", "PositionCode") VALUES ('e3090c33-043b-4f89-a6ad-955b1b4b7c6d', '3B');
INSERT INTO public."PlayerPositionEntity" ("PlayerId", "PositionCode") VALUES ('20e17640-9552-490c-b90f-652395ac6951', '2B');
INSERT INTO public."PlayerPositionEntity" ("PlayerId", "PositionCode") VALUES ('20e17640-9552-490c-b90f-652395ac6951', '3B');
INSERT INTO public."PlayerPositionEntity" ("PlayerId", "PositionCode") VALUES ('20e17640-9552-490c-b90f-652395ac6951', 'SS');
INSERT INTO public."PlayerPositionEntity" ("PlayerId", "PositionCode") VALUES ('efd41ad2-4941-4d97-aca4-751c971cf33e', '2B');
INSERT INTO public."PlayerPositionEntity" ("PlayerId", "PositionCode") VALUES ('2a601e7c-6dc3-48c6-b215-77f243da4ee6', 'IF');
INSERT INTO public."PlayerPositionEntity" ("PlayerId", "PositionCode") VALUES ('8372ff25-ff7f-4825-8960-d4e1206647a9', 'OF');
INSERT INTO public."PlayerPositionEntity" ("PlayerId", "PositionCode") VALUES ('79442841-8e3a-40a2-a08e-77a4daeb3969', '2B');
INSERT INTO public."PlayerPositionEntity" ("PlayerId", "PositionCode") VALUES ('79442841-8e3a-40a2-a08e-77a4daeb3969', '3B');
INSERT INTO public."PlayerPositionEntity" ("PlayerId", "PositionCode") VALUES ('6102c1c5-0022-4a73-93cd-ead484f4e735', 'SS');
INSERT INTO public."PlayerPositionEntity" ("PlayerId", "PositionCode") VALUES ('488e88e9-2d20-4a48-9edf-dbdbf21f429c', '1B');
INSERT INTO public."PlayerPositionEntity" ("PlayerId", "PositionCode") VALUES ('488e88e9-2d20-4a48-9edf-dbdbf21f429c', '2B');
INSERT INTO public."PlayerPositionEntity" ("PlayerId", "PositionCode") VALUES ('488e88e9-2d20-4a48-9edf-dbdbf21f429c', '3B');
INSERT INTO public."PlayerPositionEntity" ("PlayerId", "PositionCode") VALUES ('b850bfff-7f85-40a9-abff-28348754dbe9', 'OF');
INSERT INTO public."PlayerPositionEntity" ("PlayerId", "PositionCode") VALUES ('89ef3592-b576-408a-829a-526aad713b95', '2B');
INSERT INTO public."PlayerPositionEntity" ("PlayerId", "PositionCode") VALUES ('89ef3592-b576-408a-829a-526aad713b95', '3B');
INSERT INTO public."PlayerPositionEntity" ("PlayerId", "PositionCode") VALUES ('89ef3592-b576-408a-829a-526aad713b95', 'SS');
INSERT INTO public."PlayerPositionEntity" ("PlayerId", "PositionCode") VALUES ('cefdf564-6134-4030-b384-c3f6c9285114', '2B');
INSERT INTO public."PlayerPositionEntity" ("PlayerId", "PositionCode") VALUES ('e45125f0-e38b-466a-bb06-62b1ccda2c5f', 'OF');
INSERT INTO public."PlayerPositionEntity" ("PlayerId", "PositionCode") VALUES ('a75dadee-3586-4b2b-a371-2beffd6884a7', '3B');
INSERT INTO public."PlayerPositionEntity" ("PlayerId", "PositionCode") VALUES ('35f2c7d4-799c-4f05-9313-f80e102140ec', 'C');
INSERT INTO public."PlayerPositionEntity" ("PlayerId", "PositionCode") VALUES ('083931a0-68ac-4d5c-a045-78ecf437a444', 'OF');
INSERT INTO public."PlayerPositionEntity" ("PlayerId", "PositionCode") VALUES ('ac0af2b7-e715-4a7f-a13d-d3a4ecc95555', 'OF');
INSERT INTO public."PlayerPositionEntity" ("PlayerId", "PositionCode") VALUES ('780e4821-a9ab-459b-90d9-06a5308cd24f', 'C');
INSERT INTO public."PlayerPositionEntity" ("PlayerId", "PositionCode") VALUES ('61a0a509-7d45-489b-a6be-2e19700173ac', 'OF');
INSERT INTO public."PlayerPositionEntity" ("PlayerId", "PositionCode") VALUES ('40e2f815-821c-40dd-a33f-a037a3f238e5', 'RP');
INSERT INTO public."PlayerPositionEntity" ("PlayerId", "PositionCode") VALUES ('44c34d0e-1cb0-4582-be47-080949e0061b', 'RP');
INSERT INTO public."PlayerPositionEntity" ("PlayerId", "PositionCode") VALUES ('7afbc714-c48a-4052-aab2-4da66c5059df', 'SP');
INSERT INTO public."PlayerPositionEntity" ("PlayerId", "PositionCode") VALUES ('d7f01c58-2f34-4bb3-8978-b4f0c4bfd54b', 'OF');
INSERT INTO public."PlayerPositionEntity" ("PlayerId", "PositionCode") VALUES ('213c94cc-26b3-42b9-8544-eb6c34cabffb', 'SP');
INSERT INTO public."PlayerPositionEntity" ("PlayerId", "PositionCode") VALUES ('139980d6-5eb2-4c52-ab6e-4730a21b7bb8', 'RP');
INSERT INTO public."PlayerPositionEntity" ("PlayerId", "PositionCode") VALUES ('25ae92fd-8592-4917-b051-8f71928a070c', 'RP');
INSERT INTO public."PlayerPositionEntity" ("PlayerId", "PositionCode") VALUES ('25ae92fd-8592-4917-b051-8f71928a070c', 'SP');
INSERT INTO public."PlayerPositionEntity" ("PlayerId", "PositionCode") VALUES ('5136c058-282b-4c37-bba2-56f7408c7803', 'RP');
INSERT INTO public."PlayerPositionEntity" ("PlayerId", "PositionCode") VALUES ('30233b7f-5a84-47ad-a453-551c36929666', 'SP');
INSERT INTO public."PlayerPositionEntity" ("PlayerId", "PositionCode") VALUES ('aacc5ef2-96dd-4ca8-8e03-66973f50f002', 'RP');
INSERT INTO public."PlayerPositionEntity" ("PlayerId", "PositionCode") VALUES ('1aa5b3dd-c616-4f3e-8bee-6a210467f4da', 'SP');
INSERT INTO public."PlayerPositionEntity" ("PlayerId", "PositionCode") VALUES ('f43372b7-ae6f-4013-8351-ae4be4efbaa4', 'SP');


--
-- TOC entry 3355 (class 0 OID 16397)
-- Dependencies: 213
-- Data for Name: Players; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public."Players" ("Id", "Type", "FirstName", "LastName", "Age", "Team", "Status", "AverageDraftPickMin", "AverageDraftPick", "MlbAmId", "Reliability", "MayberryMethod", "AverageDraftPickMax") VALUES ('25ae92fd-8592-4917-b051-8f71928a070c', 2, 'Jakob', 'Junis', 31, 'MIL', 0, 242, 661.48, 596001, 0, 0, 750);
INSERT INTO public."Players" ("Id", "Type", "FirstName", "LastName", "Age", "Team", "Status", "AverageDraftPickMin", "AverageDraftPick", "MlbAmId", "Reliability", "MayberryMethod", "AverageDraftPickMax") VALUES ('25e3a5de-4fae-4788-920e-20cd919acc0b', 2, 'Jacob', 'deGrom', 35, 'TEX', 1, 100, 547.5, 594798, 0.6, 0, 609);
INSERT INTO public."Players" ("Id", "Type", "FirstName", "LastName", "Age", "Team", "Status", "AverageDraftPickMin", "AverageDraftPick", "MlbAmId", "Reliability", "MayberryMethod", "AverageDraftPickMax") VALUES ('30233b7f-5a84-47ad-a453-551c36929666', 2, 'Wade', 'Miley', 37, 'MIL', 0, 249, 600.36, 489119, 0, 0, 680);
INSERT INTO public."Players" ("Id", "Type", "FirstName", "LastName", "Age", "Team", "Status", "AverageDraftPickMin", "AverageDraftPick", "MlbAmId", "Reliability", "MayberryMethod", "AverageDraftPickMax") VALUES ('31e9da1c-6f0e-4e17-b880-7bf3a4d3ba3d', 2, 'Edwin', 'Diaz', 30, 'NYM', 0, 16, 48.73, 621242, 0, 0, 110);
INSERT INTO public."Players" ("Id", "Type", "FirstName", "LastName", "Age", "Team", "Status", "AverageDraftPickMin", "AverageDraftPick", "MlbAmId", "Reliability", "MayberryMethod", "AverageDraftPickMax") VALUES ('40cd2ee1-9c4d-44ec-87c3-407ac5b1523a', 2, 'Joel', 'Payamps', 30, 'MIL', 0, 170, 493.77, 606303, 0, 0, 660);
INSERT INTO public."Players" ("Id", "Type", "FirstName", "LastName", "Age", "Team", "Status", "AverageDraftPickMin", "AverageDraftPick", "MlbAmId", "Reliability", "MayberryMethod", "AverageDraftPickMax") VALUES ('40e2f815-821c-40dd-a33f-a037a3f238e5', 2, 'Pete', 'Fairbanks', 30, 'TB', 0, 61, 110.55, 664126, 0, 0, 299);
INSERT INTO public."Players" ("Id", "Type", "FirstName", "LastName", "Age", "Team", "Status", "AverageDraftPickMin", "AverageDraftPick", "MlbAmId", "Reliability", "MayberryMethod", "AverageDraftPickMax") VALUES ('410fd6d5-bd15-4618-96f4-3ff12a803795', 2, 'Robert', 'Gasser', 24, 'MIL', 0, 328, 608.14, 688107, 0.4666666666666666, 0, 741);
INSERT INTO public."Players" ("Id", "Type", "FirstName", "LastName", "Age", "Team", "Status", "AverageDraftPickMin", "AverageDraftPick", "MlbAmId", "Reliability", "MayberryMethod", "AverageDraftPickMax") VALUES ('4656ff39-53bc-4ce1-a87f-5c0431ffcf3f', 2, 'Bryse', 'Wilson', 26, 'MIL', 0, 318, 747.86, 669060, 0, 0, 737);
INSERT INTO public."Players" ("Id", "Type", "FirstName", "LastName", "Age", "Team", "Status", "AverageDraftPickMin", "AverageDraftPick", "MlbAmId", "Reliability", "MayberryMethod", "AverageDraftPickMax") VALUES ('4bbd13bd-2559-4b5f-bc42-3a0b730113ff', 2, 'Devin', 'Williams', 29, 'MIL', 1, 2, 168.15, 642207, 0.9333333333333332, 34, 489);
INSERT INTO public."Players" ("Id", "Type", "FirstName", "LastName", "Age", "Team", "Status", "AverageDraftPickMin", "AverageDraftPick", "MlbAmId", "Reliability", "MayberryMethod", "AverageDraftPickMax") VALUES ('6040b76b-0674-45da-9349-d90d2e3ccf64', 2, 'Thyago', 'Vieira', 30, 'MIL', 0, 0, 0, 600986, 0, 0, 0);
INSERT INTO public."Players" ("Id", "Type", "FirstName", "LastName", "Age", "Team", "Status", "AverageDraftPickMin", "AverageDraftPick", "MlbAmId", "Reliability", "MayberryMethod", "AverageDraftPickMax") VALUES ('61795270-ae6d-488d-8f8b-8f9a1d10730d', 2, 'Hoby', 'Milner', 33, 'MIL', 0, 562, 749.9, 571948, 0, 0, 742);
INSERT INTO public."Players" ("Id", "Type", "FirstName", "LastName", "Age", "Team", "Status", "AverageDraftPickMin", "AverageDraftPick", "MlbAmId", "Reliability", "MayberryMethod", "AverageDraftPickMax") VALUES ('69034182-a2d7-4840-82b6-c67dcd39634e', 2, 'Max', 'Scherzer', 39, 'TEX', 1, 44, 359.45, 453286, 0.7333333333333334, 11, 510);
INSERT INTO public."Players" ("Id", "Type", "FirstName", "LastName", "Age", "Team", "Status", "AverageDraftPickMin", "AverageDraftPick", "MlbAmId", "Reliability", "MayberryMethod", "AverageDraftPickMax") VALUES ('6be652db-a1d2-4aad-afe8-98bd04170e8a', 2, 'Freddy', 'Peralta', 27, 'MIL', 0, 26, 59.21, 642547, 0, 0, 111);
INSERT INTO public."Players" ("Id", "Type", "FirstName", "LastName", "Age", "Team", "Status", "AverageDraftPickMin", "AverageDraftPick", "MlbAmId", "Reliability", "MayberryMethod", "AverageDraftPickMax") VALUES ('77571748-f98b-46a2-b99c-01e01a220fc9', 2, 'Orion', 'Kerkering', 23, 'PHI', 0, 194, 541.73, 689147, 0, 0, 619);
INSERT INTO public."Players" ("Id", "Type", "FirstName", "LastName", "Age", "Team", "Status", "AverageDraftPickMin", "AverageDraftPick", "MlbAmId", "Reliability", "MayberryMethod", "AverageDraftPickMax") VALUES ('7afbc714-c48a-4052-aab2-4da66c5059df', 2, 'Joe', 'Musgrove', 31, 'SD', 0, 67, 106.28, 605397, 0, 0, 167);
INSERT INTO public."Players" ("Id", "Type", "FirstName", "LastName", "Age", "Team", "Status", "AverageDraftPickMin", "AverageDraftPick", "MlbAmId", "Reliability", "MayberryMethod", "AverageDraftPickMax") VALUES ('80967cf1-c8c2-4ac1-92a2-615207ef7734', 2, 'Tanner', 'Houck', 27, 'BOS', 0, 212, 455.31, 656557, 0, 0, 574);
INSERT INTO public."Players" ("Id", "Type", "FirstName", "LastName", "Age", "Team", "Status", "AverageDraftPickMin", "AverageDraftPick", "MlbAmId", "Reliability", "MayberryMethod", "AverageDraftPickMax") VALUES ('82b81710-c5c4-4b08-9cc1-1419f5ffd382', 2, 'Taylor', 'Clarke', 30, 'MIL', 0, 331, 750.43, 664199, 0.4666666666666666, 0, 746);
INSERT INTO public."Players" ("Id", "Type", "FirstName", "LastName", "Age", "Team", "Status", "AverageDraftPickMin", "AverageDraftPick", "MlbAmId", "Reliability", "MayberryMethod", "AverageDraftPickMax") VALUES ('83d9f9c9-9f5d-4d25-af3b-9af30700b82a', 2, 'Giovanny', 'Gallegos', 32, 'STL', 0, 254, 639.2, 606149, 0, 0, 719);
INSERT INTO public."Players" ("Id", "Type", "FirstName", "LastName", "Age", "Team", "Status", "AverageDraftPickMin", "AverageDraftPick", "MlbAmId", "Reliability", "MayberryMethod", "AverageDraftPickMax") VALUES ('85a74a1f-d654-4c39-830e-105e384937eb', 2, 'Nick', 'Pivetta', 31, 'BOS', 1, 95, 173.81, 601713, 0, 0, 294);
INSERT INTO public."Players" ("Id", "Type", "FirstName", "LastName", "Age", "Team", "Status", "AverageDraftPickMin", "AverageDraftPick", "MlbAmId", "Reliability", "MayberryMethod", "AverageDraftPickMax") VALUES ('a25cf946-49af-4faa-8049-601142377ab8', 2, 'Robert', 'Stephenson', 31, 'LAA', 1, 111, 393.09, 596112, 0.6, 16, 569);
INSERT INTO public."Players" ("Id", "Type", "FirstName", "LastName", "Age", "Team", "Status", "AverageDraftPickMin", "AverageDraftPick", "MlbAmId", "Reliability", "MayberryMethod", "AverageDraftPickMax") VALUES ('a8fde7de-dd37-4bca-982e-7ac0d0916ea1', 2, 'J.B.', 'Bukauskas', 27, 'MIL', 0, 542, 750.86, 656266, 0, 0, 542);
INSERT INTO public."Players" ("Id", "Type", "FirstName", "LastName", "Age", "Team", "Status", "AverageDraftPickMin", "AverageDraftPick", "MlbAmId", "Reliability", "MayberryMethod", "AverageDraftPickMax") VALUES ('aacc5ef2-96dd-4ca8-8e03-66973f50f002', 2, 'Ryan', 'Pressly', 35, 'HOU', 0, 57, 304.28, 519151, 0, 0, 549);
INSERT INTO public."Players" ("Id", "Type", "FirstName", "LastName", "Age", "Team", "Status", "AverageDraftPickMin", "AverageDraftPick", "MlbAmId", "Reliability", "MayberryMethod", "AverageDraftPickMax") VALUES ('ad69f157-23d5-4c6e-91bf-d5fb00747a87', 2, 'Rob', 'Zastryzny', 32, 'MIL', 2, 0, 0, 642239, 0.39999999999999997, 0, 0);
INSERT INTO public."Players" ("Id", "Type", "FirstName", "LastName", "Age", "Team", "Status", "AverageDraftPickMin", "AverageDraftPick", "MlbAmId", "Reliability", "MayberryMethod", "AverageDraftPickMax") VALUES ('c254c3ba-18a0-4f8f-bb4b-a7db2f020f0c', 2, 'Kevin', 'Ginkel', 30, 'ARZ', 0, 149, 557.27, 656464, 0, 0, 618);
INSERT INTO public."Players" ("Id", "Type", "FirstName", "LastName", "Age", "Team", "Status", "AverageDraftPickMin", "AverageDraftPick", "MlbAmId", "Reliability", "MayberryMethod", "AverageDraftPickMax") VALUES ('c81dd2ce-130a-46a9-87f7-32caf8478b49', 2, 'Tyler', 'Glasnow', 30, 'LAD', 0, 11, 43.12, 607192, 0, 0, 85);
INSERT INTO public."Players" ("Id", "Type", "FirstName", "LastName", "Age", "Team", "Status", "AverageDraftPickMin", "AverageDraftPick", "MlbAmId", "Reliability", "MayberryMethod", "AverageDraftPickMax") VALUES ('e48f6045-a7da-4b8a-b2ee-d4aeac401f6a', 2, 'Vladimir', 'Gutierrez', 28, 'MIL', 0, 495, 750.81, 661269, 0, 0, 734);
INSERT INTO public."Players" ("Id", "Type", "FirstName", "LastName", "Age", "Team", "Status", "AverageDraftPickMin", "AverageDraftPick", "MlbAmId", "Reliability", "MayberryMethod", "AverageDraftPickMax") VALUES ('e6366fff-e824-496b-8d73-eb1d691fe51f', 2, 'Abner', 'Uribe', 23, 'MIL', 0, 136, 516.62, 682842, 0, 0, 614);
INSERT INTO public."Players" ("Id", "Type", "FirstName", "LastName", "Age", "Team", "Status", "AverageDraftPickMin", "AverageDraftPick", "MlbAmId", "Reliability", "MayberryMethod", "AverageDraftPickMax") VALUES ('19347bdc-b38e-49bb-9938-1e004bd5bcb8', 2, 'Raisel', 'Iglesias', 34, 'ATL', 0, 42, 75.68, 628452, 0, 0, 196);
INSERT INTO public."Players" ("Id", "Type", "FirstName", "LastName", "Age", "Team", "Status", "AverageDraftPickMin", "AverageDraftPick", "MlbAmId", "Reliability", "MayberryMethod", "AverageDraftPickMax") VALUES ('efa00874-5c8e-428a-bf14-f15d68812975', 2, 'Reid', 'Detmers', 24, 'LAA', 0, 167, 237.76, 672282, 0, 0, 317);
INSERT INTO public."Players" ("Id", "Type", "FirstName", "LastName", "Age", "Team", "Status", "AverageDraftPickMin", "AverageDraftPick", "MlbAmId", "Reliability", "MayberryMethod", "AverageDraftPickMax") VALUES ('efce08f7-800a-4be5-a188-2cd796dc824b', 2, 'Bryan', 'Hudson', 26, 'MIL', 0, 743, 750.99, 663542, 0, 0, 743);
INSERT INTO public."Players" ("Id", "Type", "FirstName", "LastName", "Age", "Team", "Status", "AverageDraftPickMin", "AverageDraftPick", "MlbAmId", "Reliability", "MayberryMethod", "AverageDraftPickMax") VALUES ('f1099553-5c27-4a12-a097-3939e919f804', 2, 'Easton', 'McGee', 26, 'MIL', 2, 0, 0, 668834, 0.4666666666666666, 0, 0);
INSERT INTO public."Players" ("Id", "Type", "FirstName", "LastName", "Age", "Team", "Status", "AverageDraftPickMin", "AverageDraftPick", "MlbAmId", "Reliability", "MayberryMethod", "AverageDraftPickMax") VALUES ('f97f940a-2af3-4ce4-aa9c-520dd836e69a', 2, 'Carlos', 'Rodriguez', 22, 'MIL', 0, 0, 0, 692230, 0.4666666666666666, 0, 0);
INSERT INTO public."Players" ("Id", "Type", "FirstName", "LastName", "Age", "Team", "Status", "AverageDraftPickMin", "AverageDraftPick", "MlbAmId", "Reliability", "MayberryMethod", "AverageDraftPickMax") VALUES ('35f2c7d4-799c-4f05-9313-f80e102140ec', 1, 'J.T.', 'Realmuto', 33, 'PHI', 0, 31, 71.62, 592663, 0, 0, 110);
INSERT INTO public."Players" ("Id", "Type", "FirstName", "LastName", "Age", "Team", "Status", "AverageDraftPickMin", "AverageDraftPick", "MlbAmId", "Reliability", "MayberryMethod", "AverageDraftPickMax") VALUES ('2a601e7c-6dc3-48c6-b215-77f243da4ee6', 1, 'Vinny', 'Capra', 27, 'MIL', 0, 0, 0, 681962, 0.4666666666666666, 0, 0);
INSERT INTO public."Players" ("Id", "Type", "FirstName", "LastName", "Age", "Team", "Status", "AverageDraftPickMin", "AverageDraftPick", "MlbAmId", "Reliability", "MayberryMethod", "AverageDraftPickMax") VALUES ('7106b85c-47e2-4e4f-95a3-2e0d72f252e4', 1, 'Sal', 'Frelick', 23, 'MIL', 0, 171, 280.37, 686217, 0, 0, 421);
INSERT INTO public."Players" ("Id", "Type", "FirstName", "LastName", "Age", "Team", "Status", "AverageDraftPickMin", "AverageDraftPick", "MlbAmId", "Reliability", "MayberryMethod", "AverageDraftPickMax") VALUES ('3c88638b-291f-45f8-8bb2-a11d403604c5', 1, 'Juan', 'Soto', 25, 'NYY', 0, 2, 10.26, 665742, 0, 0, 34);
INSERT INTO public."Players" ("Id", "Type", "FirstName", "LastName", "Age", "Team", "Status", "AverageDraftPickMin", "AverageDraftPick", "MlbAmId", "Reliability", "MayberryMethod", "AverageDraftPickMax") VALUES ('780e4821-a9ab-459b-90d9-06a5308cd24f', 1, 'Gary', 'Sanchez', 31, 'MIL', 0, 192, 465.04, 596142, 0, 0, 598);
INSERT INTO public."Players" ("Id", "Type", "FirstName", "LastName", "Age", "Team", "Status", "AverageDraftPickMin", "AverageDraftPick", "MlbAmId", "Reliability", "MayberryMethod", "AverageDraftPickMax") VALUES ('79442841-8e3a-40a2-a08e-77a4daeb3969', 1, 'Ryan', 'McMahon', 29, 'COL', 0, 135, 223.67, 641857, 0, 0, 304);
INSERT INTO public."Players" ("Id", "Type", "FirstName", "LastName", "Age", "Team", "Status", "AverageDraftPickMin", "AverageDraftPick", "MlbAmId", "Reliability", "MayberryMethod", "AverageDraftPickMax") VALUES ('82ce40a9-45cd-453c-ab03-0fcfba2b62d9', 1, 'Jackson', 'Chourio', 20, 'MIL', 0, 37, 133.03, 694192, 0, 0, 306);
INSERT INTO public."Players" ("Id", "Type", "FirstName", "LastName", "Age", "Team", "Status", "AverageDraftPickMin", "AverageDraftPick", "MlbAmId", "Reliability", "MayberryMethod", "AverageDraftPickMax") VALUES ('8372ff25-ff7f-4825-8960-d4e1206647a9', 1, 'J.D.', 'Martinez', 36, 'NYM', 0, 125, 248.35, 502110, 0.7999999999999999, 36, 419);
INSERT INTO public."Players" ("Id", "Type", "FirstName", "LastName", "Age", "Team", "Status", "AverageDraftPickMin", "AverageDraftPick", "MlbAmId", "Reliability", "MayberryMethod", "AverageDraftPickMax") VALUES ('89ef3592-b576-408a-829a-526aad713b95', 1, 'Andruw', 'Monasterio', 26, 'MIL', 0, 385, 704.48, 655316, 0, 0, 747);
INSERT INTO public."Players" ("Id", "Type", "FirstName", "LastName", "Age", "Team", "Status", "AverageDraftPickMin", "AverageDraftPick", "MlbAmId", "Reliability", "MayberryMethod", "AverageDraftPickMax") VALUES ('973e9c12-762b-4303-aea4-65bed4c4edd2', 1, 'Taylor', 'Ward', 30, 'LAA', 0, 109, 220.53, 621493, 0, 0, 313);
INSERT INTO public."Players" ("Id", "Type", "FirstName", "LastName", "Age", "Team", "Status", "AverageDraftPickMin", "AverageDraftPick", "MlbAmId", "Reliability", "MayberryMethod", "AverageDraftPickMax") VALUES ('9bd677e7-ba97-4bd7-89e8-5cf61dedba78', 1, 'Rhys', 'Hoskins', 31, 'MIL', 0, 116, 188.68, 656555, 0, 0, 290);
INSERT INTO public."Players" ("Id", "Type", "FirstName", "LastName", "Age", "Team", "Status", "AverageDraftPickMin", "AverageDraftPick", "MlbAmId", "Reliability", "MayberryMethod", "AverageDraftPickMax") VALUES ('9d7257bc-e6a4-46bc-9200-91b73f437a82', 1, 'Oswaldo', 'Cabrera', 25, 'NYY', 0, 370, 737.38, 665828, 0, 0, 750);
INSERT INTO public."Players" ("Id", "Type", "FirstName", "LastName", "Age", "Team", "Status", "AverageDraftPickMin", "AverageDraftPick", "MlbAmId", "Reliability", "MayberryMethod", "AverageDraftPickMax") VALUES ('4707d3a6-35cc-4f86-88f3-122e83de82b9', 1, 'Oliver', 'Dunn', 26, 'MIL', 0, 588, 750.63, 686554, 0, 0, 750);
INSERT INTO public."Players" ("Id", "Type", "FirstName", "LastName", "Age", "Team", "Status", "AverageDraftPickMin", "AverageDraftPick", "MlbAmId", "Reliability", "MayberryMethod", "AverageDraftPickMax") VALUES ('9e6a26f6-e752-43ae-9327-9092c51ce23a', 1, 'Triston', 'Casas', 24, 'BOS', 0, 42, 97.54, 671213, 0, 0, 151);
INSERT INTO public."Players" ("Id", "Type", "FirstName", "LastName", "Age", "Team", "Status", "AverageDraftPickMin", "AverageDraftPick", "MlbAmId", "Reliability", "MayberryMethod", "AverageDraftPickMax") VALUES ('9ff79a30-3c1b-44c7-96a0-d33633c847df', 1, 'Aaron', 'Judge', 31, 'NYY', 0, 2, 11.84, 592450, 0, 0, 26);
INSERT INTO public."Players" ("Id", "Type", "FirstName", "LastName", "Age", "Team", "Status", "AverageDraftPickMin", "AverageDraftPick", "MlbAmId", "Reliability", "MayberryMethod", "AverageDraftPickMax") VALUES ('a75dadee-3586-4b2b-a371-2beffd6884a7', 1, 'Jose', 'Ramirez', 31, 'CLE', 0, 6, 15.39, 608070, 0, 0, 26);
INSERT INTO public."Players" ("Id", "Type", "FirstName", "LastName", "Age", "Team", "Status", "AverageDraftPickMin", "AverageDraftPick", "MlbAmId", "Reliability", "MayberryMethod", "AverageDraftPickMax") VALUES ('ac0af2b7-e715-4a7f-a13d-d3a4ecc95555', 1, 'Julio', 'Rodriguez', 23, 'SEA', 0, 1, 3.26, 677594, 0, 0, 8);
INSERT INTO public."Players" ("Id", "Type", "FirstName", "LastName", "Age", "Team", "Status", "AverageDraftPickMin", "AverageDraftPick", "MlbAmId", "Reliability", "MayberryMethod", "AverageDraftPickMax") VALUES ('4947afdf-6d0d-4d36-a656-d1687789cfd8', 1, 'Jordan', 'Walker', 21, 'STL', 0, 45, 114.24, 691023, 0, 0, 216);
INSERT INTO public."Players" ("Id", "Type", "FirstName", "LastName", "Age", "Team", "Status", "AverageDraftPickMin", "AverageDraftPick", "MlbAmId", "Reliability", "MayberryMethod", "AverageDraftPickMax") VALUES ('b5df2e6f-cccc-42f9-ac06-0a505fa724ae', 1, 'Michael', 'Busch', 26, 'CHC', 0, 155, 419.2, 683737, 0, 0, 660);
INSERT INTO public."Players" ("Id", "Type", "FirstName", "LastName", "Age", "Team", "Status", "AverageDraftPickMin", "AverageDraftPick", "MlbAmId", "Reliability", "MayberryMethod", "AverageDraftPickMax") VALUES ('b6832adf-a496-4d5d-81e7-605030a0e028', 1, 'Tyler', 'Black', 23, 'MIL', 0, 279, 537.52, 672012, 0.4666666666666666, 0, 610);
INSERT INTO public."Players" ("Id", "Type", "FirstName", "LastName", "Age", "Team", "Status", "AverageDraftPickMin", "AverageDraftPick", "MlbAmId", "Reliability", "MayberryMethod", "AverageDraftPickMax") VALUES ('b850bfff-7f85-40a9-abff-28348754dbe9', 1, 'Garrett', 'Mitchell', 25, 'MIL', 1, 178, 466.68, 669003, 0.26666666666666666, 7, 660);
INSERT INTO public."Players" ("Id", "Type", "FirstName", "LastName", "Age", "Team", "Status", "AverageDraftPickMin", "AverageDraftPick", "MlbAmId", "Reliability", "MayberryMethod", "AverageDraftPickMax") VALUES ('51a61d66-e85b-480a-bbf8-995dd0436f29', 1, 'William', 'Contreras', 26, 'MIL', 0, 17, 74.17, 661388, 0, 0, 119);
INSERT INTO public."Players" ("Id", "Type", "FirstName", "LastName", "Age", "Team", "Status", "AverageDraftPickMin", "AverageDraftPick", "MlbAmId", "Reliability", "MayberryMethod", "AverageDraftPickMax") VALUES ('b4e74de3-6c7d-42c6-9b6a-7270e2b22971', 2, 'Yu', 'Darvish', 37, 'SD', 0, 110, 188.81, 506433, 0, 0, 277);
INSERT INTO public."Players" ("Id", "Type", "FirstName", "LastName", "Age", "Team", "Status", "AverageDraftPickMin", "AverageDraftPick", "MlbAmId", "Reliability", "MayberryMethod", "AverageDraftPickMax") VALUES ('5b92e19b-3bfd-40dd-9546-73cccede2638', 1, 'Luis', 'Arraez', 27, 'MIA', 0, 51, 157.33, 650333, 0, 0, 256);
INSERT INTO public."Players" ("Id", "Type", "FirstName", "LastName", "Age", "Team", "Status", "AverageDraftPickMin", "AverageDraftPick", "MlbAmId", "Reliability", "MayberryMethod", "AverageDraftPickMax") VALUES ('c4a6ee18-6242-4501-b781-b1b7f2b27e49', 1, 'Michael', 'Harris', 23, 'ATL', 0, 15, 30.39, 671739, 0, 0, 50);
INSERT INTO public."Players" ("Id", "Type", "FirstName", "LastName", "Age", "Team", "Status", "AverageDraftPickMin", "AverageDraftPick", "MlbAmId", "Reliability", "MayberryMethod", "AverageDraftPickMax") VALUES ('083931a0-68ac-4d5c-a045-78ecf437a444', 1, 'Bryan', 'Reynolds', 29, 'PIT', 0, 38, 87.87, 668804, 0, 0, 142);
INSERT INTO public."Players" ("Id", "Type", "FirstName", "LastName", "Age", "Team", "Status", "AverageDraftPickMin", "AverageDraftPick", "MlbAmId", "Reliability", "MayberryMethod", "AverageDraftPickMax") VALUES ('6102c1c5-0022-4a73-93cd-ead484f4e735', 1, 'Jackson', 'Merrill', 20, 'SD', 0, 132, 443.04, 701538, 0, 0, 735);
INSERT INTO public."Players" ("Id", "Type", "FirstName", "LastName", "Age", "Team", "Status", "AverageDraftPickMin", "AverageDraftPick", "MlbAmId", "Reliability", "MayberryMethod", "AverageDraftPickMax") VALUES ('61a0a509-7d45-489b-a6be-2e19700173ac', 1, 'Christian', 'Yelich', 32, 'MIL', 0, 31, 73.59, 592885, 0, 0, 104);
INSERT INTO public."Players" ("Id", "Type", "FirstName", "LastName", "Age", "Team", "Status", "AverageDraftPickMin", "AverageDraftPick", "MlbAmId", "Reliability", "MayberryMethod", "AverageDraftPickMax") VALUES ('647cdd37-00ae-46b6-b69d-7a76174f71b3', 1, 'Jung Hoo', 'Lee', 25, 'SF', 0, 69, 247.39, 808982, 0, 0, 687);
INSERT INTO public."Players" ("Id", "Type", "FirstName", "LastName", "Age", "Team", "Status", "AverageDraftPickMin", "AverageDraftPick", "MlbAmId", "Reliability", "MayberryMethod", "AverageDraftPickMax") VALUES ('cddc33ec-062e-4779-8057-75cd691c8abb', 1, 'Willy', 'Adames', 28, 'MIL', 0, 84, 178.65, 642715, 0, 0, 250);
INSERT INTO public."Players" ("Id", "Type", "FirstName", "LastName", "Age", "Team", "Status", "AverageDraftPickMin", "AverageDraftPick", "MlbAmId", "Reliability", "MayberryMethod", "AverageDraftPickMax") VALUES ('db291251-e95e-4334-92f0-606d7bda7aef', 2, 'Aaron', 'Ashby', 25, 'MIL', 0, 268, 568.35, 676879, 0, 0, 719);
INSERT INTO public."Players" ("Id", "Type", "FirstName", "LastName", "Age", "Team", "Status", "AverageDraftPickMin", "AverageDraftPick", "MlbAmId", "Reliability", "MayberryMethod", "AverageDraftPickMax") VALUES ('cefdf564-6134-4030-b384-c3f6c9285114', 1, 'Joey', 'Ortiz', 25, 'MIL', 0, 165, 605.74, 687401, 0, 0, 748);
INSERT INTO public."Players" ("Id", "Type", "FirstName", "LastName", "Age", "Team", "Status", "AverageDraftPickMin", "AverageDraftPick", "MlbAmId", "Reliability", "MayberryMethod", "AverageDraftPickMax") VALUES ('d3bcbd0a-4ad2-4604-b82b-c9620013260b', 1, 'Brice', 'Turang', 24, 'MIL', 0, 188, 373.02, 668930, 0, 0, 440);
INSERT INTO public."Players" ("Id", "Type", "FirstName", "LastName", "Age", "Team", "Status", "AverageDraftPickMin", "AverageDraftPick", "MlbAmId", "Reliability", "MayberryMethod", "AverageDraftPickMax") VALUES ('d7f01c58-2f34-4bb3-8978-b4f0c4bfd54b', 1, 'Joey', 'Wiemer', 25, 'MIL', 0, 333, 664.31, 686894, 0, 0, 735);
INSERT INTO public."Players" ("Id", "Type", "FirstName", "LastName", "Age", "Team", "Status", "AverageDraftPickMin", "AverageDraftPick", "MlbAmId", "Reliability", "MayberryMethod", "AverageDraftPickMax") VALUES ('da2190fb-0dbd-4edc-8d83-e7808266d630', 1, 'Jake', 'Bauers', 28, 'MIL', 0, 388, 696.07, 641343, 0, 0, 750);
INSERT INTO public."Players" ("Id", "Type", "FirstName", "LastName", "Age", "Team", "Status", "AverageDraftPickMin", "AverageDraftPick", "MlbAmId", "Reliability", "MayberryMethod", "AverageDraftPickMax") VALUES ('e3090c33-043b-4f89-a6ad-955b1b4b7c6d', 1, 'Colt', 'Keith', 22, 'DET', 0, 125, 324.82, 690993, 0, 0, 484);
INSERT INTO public."Players" ("Id", "Type", "FirstName", "LastName", "Age", "Team", "Status", "AverageDraftPickMin", "AverageDraftPick", "MlbAmId", "Reliability", "MayberryMethod", "AverageDraftPickMax") VALUES ('e45125f0-e38b-466a-bb06-62b1ccda2c5f', 1, 'Blake', 'Perkins', 27, 'MIL', 0, 577, 750.69, 663368, 0, 0, 749);
INSERT INTO public."Players" ("Id", "Type", "FirstName", "LastName", "Age", "Team", "Status", "AverageDraftPickMin", "AverageDraftPick", "MlbAmId", "Reliability", "MayberryMethod", "AverageDraftPickMax") VALUES ('6d56f922-c389-4716-950b-2fa0073cda78', 1, 'Gunnar', 'Henderson', 22, 'BAL', 0, 16, 30.72, 683002, 0, 0, 53);
INSERT INTO public."Players" ("Id", "Type", "FirstName", "LastName", "Age", "Team", "Status", "AverageDraftPickMin", "AverageDraftPick", "MlbAmId", "Reliability", "MayberryMethod", "AverageDraftPickMax") VALUES ('488e88e9-2d20-4a48-9edf-dbdbf21f429c', 1, 'Owen', 'Miller', 27, 'MIL', 0, 400, 721.04, 680911, 0.9333333333333332, 0, 749);
INSERT INTO public."Players" ("Id", "Type", "FirstName", "LastName", "Age", "Team", "Status", "AverageDraftPickMin", "AverageDraftPick", "MlbAmId", "Reliability", "MayberryMethod", "AverageDraftPickMax") VALUES ('1aa5b3dd-c616-4f3e-8bee-6a210467f4da', 2, 'Colin', 'Rea', 33, 'MIL', 0, 307, 623.49, 607067, 0, 0, 727);
INSERT INTO public."Players" ("Id", "Type", "FirstName", "LastName", "Age", "Team", "Status", "AverageDraftPickMin", "AverageDraftPick", "MlbAmId", "Reliability", "MayberryMethod", "AverageDraftPickMax") VALUES ('213c94cc-26b3-42b9-8544-eb6c34cabffb', 2, 'Hunter', 'Greene', 24, 'CIN', 0, 64, 140.47, 668881, 0, 0, 258);
INSERT INTO public."Players" ("Id", "Type", "FirstName", "LastName", "Age", "Team", "Status", "AverageDraftPickMin", "AverageDraftPick", "MlbAmId", "Reliability", "MayberryMethod", "AverageDraftPickMax") VALUES ('21abe7f6-ce67-4138-90ad-eb3579ef3530', 2, 'Tanner', 'Scott', 29, 'MIA', 0, 61, 130.74, 656945, 0, 0, 298);
INSERT INTO public."Players" ("Id", "Type", "FirstName", "LastName", "Age", "Team", "Status", "AverageDraftPickMin", "AverageDraftPick", "MlbAmId", "Reliability", "MayberryMethod", "AverageDraftPickMax") VALUES ('22459580-ed4c-4809-a345-4f1c9abda82c', 2, 'Joe', 'Ross', 30, 'MIL', 0, 424, 733.35, 605452, 0, 0, 750);
INSERT INTO public."Players" ("Id", "Type", "FirstName", "LastName", "Age", "Team", "Status", "AverageDraftPickMin", "AverageDraftPick", "MlbAmId", "Reliability", "MayberryMethod", "AverageDraftPickMax") VALUES ('01317e6c-91ca-410d-93d6-d3ee9c46b241', 2, 'Janson', 'Junk', 28, 'MIL', 0, 0, 0, 676083, 0.4666666666666666, 0, 0);
INSERT INTO public."Players" ("Id", "Type", "FirstName", "LastName", "Age", "Team", "Status", "AverageDraftPickMin", "AverageDraftPick", "MlbAmId", "Reliability", "MayberryMethod", "AverageDraftPickMax") VALUES ('efd41ad2-4941-4d97-aca4-751c971cf33e', 1, 'Ketel', 'Marte', 30, 'ARZ', 0, 57, 111.82, 606466, 0, 0, 160);
INSERT INTO public."Players" ("Id", "Type", "FirstName", "LastName", "Age", "Team", "Status", "AverageDraftPickMin", "AverageDraftPick", "MlbAmId", "Reliability", "MayberryMethod", "AverageDraftPickMax") VALUES ('fba56342-e6ef-41d1-a393-c62a85df7f92', 1, 'Cody', 'Bellinger', 28, 'CHC', 0, 22, 55.4, 641355, 0, 0, 98);
INSERT INTO public."Players" ("Id", "Type", "FirstName", "LastName", "Age", "Team", "Status", "AverageDraftPickMin", "AverageDraftPick", "MlbAmId", "Reliability", "MayberryMethod", "AverageDraftPickMax") VALUES ('139980d6-5eb2-4c52-ab6e-4730a21b7bb8', 2, 'DL', 'Hall', 25, 'MIL', 0, 181, 373.68, 669084, 0, 0, 567);
INSERT INTO public."Players" ("Id", "Type", "FirstName", "LastName", "Age", "Team", "Status", "AverageDraftPickMin", "AverageDraftPick", "MlbAmId", "Reliability", "MayberryMethod", "AverageDraftPickMax") VALUES ('44c34d0e-1cb0-4582-be47-080949e0061b', 2, 'Brusdar', 'Graterol', 25, 'LAD', 1, 240, 564.2, 660813, 0.6666666666666666, 10, 713);
INSERT INTO public."Players" ("Id", "Type", "FirstName", "LastName", "Age", "Team", "Status", "AverageDraftPickMin", "AverageDraftPick", "MlbAmId", "Reliability", "MayberryMethod", "AverageDraftPickMax") VALUES ('20e17640-9552-490c-b90f-652395ac6951', 1, 'Ha-Seong', 'Kim', 28, 'SD', 0, 37, 82.35, 673490, 0, 0, 133);
INSERT INTO public."Players" ("Id", "Type", "FirstName", "LastName", "Age", "Team", "Status", "AverageDraftPickMin", "AverageDraftPick", "MlbAmId", "Reliability", "MayberryMethod", "AverageDraftPickMax") VALUES ('5136c058-282b-4c37-bba2-56f7408c7803', 2, 'Trevor', 'Megill', 30, 'MIL', 1, 195, 619.26, 656730, 0, 0, 750);
INSERT INTO public."Players" ("Id", "Type", "FirstName", "LastName", "Age", "Team", "Status", "AverageDraftPickMin", "AverageDraftPick", "MlbAmId", "Reliability", "MayberryMethod", "AverageDraftPickMax") VALUES ('5169be32-19c3-477e-a8c8-dda1980be29b', 2, 'Andres', 'Munoz', 25, 'SEA', 0, 50, 104.14, 662253, 0, 0, 309);
INSERT INTO public."Players" ("Id", "Type", "FirstName", "LastName", "Age", "Team", "Status", "AverageDraftPickMin", "AverageDraftPick", "MlbAmId", "Reliability", "MayberryMethod", "AverageDraftPickMax") VALUES ('5578672e-d4a9-495c-8aaa-d0a9824a4a37', 2, 'Emmanuel', 'Clase', 26, 'CLE', 0, 24, 61.19, 661403, 0, 0, 134);
INSERT INTO public."Players" ("Id", "Type", "FirstName", "LastName", "Age", "Team", "Status", "AverageDraftPickMin", "AverageDraftPick", "MlbAmId", "Reliability", "MayberryMethod", "AverageDraftPickMax") VALUES ('2742eeb2-bcb4-4241-b934-fd6addc66352', 2, 'Kevin', 'Herget', 33, 'MIL', 0, 0, 0, 643361, 0.4666666666666666, 0, 0);
INSERT INTO public."Players" ("Id", "Type", "FirstName", "LastName", "Age", "Team", "Status", "AverageDraftPickMin", "AverageDraftPick", "MlbAmId", "Reliability", "MayberryMethod", "AverageDraftPickMax") VALUES ('f43372b7-ae6f-4013-8351-ae4be4efbaa4', 2, 'Brady', 'Singer', 27, 'KC', 0, 222, 521.54, 663903, 0, 0, 572);
INSERT INTO public."Players" ("Id", "Type", "FirstName", "LastName", "Age", "Team", "Status", "AverageDraftPickMin", "AverageDraftPick", "MlbAmId", "Reliability", "MayberryMethod", "AverageDraftPickMax") VALUES ('f5b7aafd-b1f9-4bc5-a37b-e804874f90a0', 2, 'Elvis', 'Peguero', 27, 'MIL', 0, 437, 750.66, 665625, 0, 0, 734);


--
-- TOC entry 3356 (class 0 OID 16401)
-- Dependencies: 214
-- Data for Name: Teams; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public."Teams" ("Code", "AlternativeCode", "LeagueId", "City", "Nickname") VALUES ('', NULL, '', 'Free Agent', 'Free Agent');
INSERT INTO public."Teams" ("Code", "AlternativeCode", "LeagueId", "City", "Nickname") VALUES ('ARZ', 'ARI', 'NL', 'Arizona', 'Diamondbacks');
INSERT INTO public."Teams" ("Code", "AlternativeCode", "LeagueId", "City", "Nickname") VALUES ('ATL', NULL, 'NL', 'Atlanta', 'Braves');
INSERT INTO public."Teams" ("Code", "AlternativeCode", "LeagueId", "City", "Nickname") VALUES ('BAL', NULL, 'AL', 'Baltimore', 'Orioles');
INSERT INTO public."Teams" ("Code", "AlternativeCode", "LeagueId", "City", "Nickname") VALUES ('BOS', NULL, 'AL', 'Boston', 'Red Sox');
INSERT INTO public."Teams" ("Code", "AlternativeCode", "LeagueId", "City", "Nickname") VALUES ('CIN', NULL, 'NL', 'Cincinnati', 'Reds');
INSERT INTO public."Teams" ("Code", "AlternativeCode", "LeagueId", "City", "Nickname") VALUES ('CLE', NULL, 'AL', 'Cleveland', 'Guardians');
INSERT INTO public."Teams" ("Code", "AlternativeCode", "LeagueId", "City", "Nickname") VALUES ('COL', NULL, 'NL', 'Colorado', 'Rockies');
INSERT INTO public."Teams" ("Code", "AlternativeCode", "LeagueId", "City", "Nickname") VALUES ('CWS', 'CHW', 'AL', 'Chicago', 'White Sox');
INSERT INTO public."Teams" ("Code", "AlternativeCode", "LeagueId", "City", "Nickname") VALUES ('DET', NULL, 'AL', 'Detriot', 'Tigers');
INSERT INTO public."Teams" ("Code", "AlternativeCode", "LeagueId", "City", "Nickname") VALUES ('HOU', NULL, 'AL', 'Houston', 'Astros');
INSERT INTO public."Teams" ("Code", "AlternativeCode", "LeagueId", "City", "Nickname") VALUES ('KC', NULL, 'AL', 'Kansas City', 'Royals');
INSERT INTO public."Teams" ("Code", "AlternativeCode", "LeagueId", "City", "Nickname") VALUES ('LAA', NULL, 'AL', 'Los Angeles', 'Angels');
INSERT INTO public."Teams" ("Code", "AlternativeCode", "LeagueId", "City", "Nickname") VALUES ('LAD', 'LA', 'NL', 'Los Angeles', 'Dodgers');
INSERT INTO public."Teams" ("Code", "AlternativeCode", "LeagueId", "City", "Nickname") VALUES ('MIA', NULL, 'NL', 'Miami', 'Marlins');
INSERT INTO public."Teams" ("Code", "AlternativeCode", "LeagueId", "City", "Nickname") VALUES ('MIL', NULL, 'NL', 'Milwaukee', 'Brewers');
INSERT INTO public."Teams" ("Code", "AlternativeCode", "LeagueId", "City", "Nickname") VALUES ('MIN', NULL, 'AL', 'Minnesota', 'Twins');
INSERT INTO public."Teams" ("Code", "AlternativeCode", "LeagueId", "City", "Nickname") VALUES ('NYM', NULL, 'NL', 'New York', 'Mets');
INSERT INTO public."Teams" ("Code", "AlternativeCode", "LeagueId", "City", "Nickname") VALUES ('NYY', NULL, 'AL', 'New York', 'Yankees');
INSERT INTO public."Teams" ("Code", "AlternativeCode", "LeagueId", "City", "Nickname") VALUES ('OAK', NULL, 'AL', 'Oakland', 'Athletics');
INSERT INTO public."Teams" ("Code", "AlternativeCode", "LeagueId", "City", "Nickname") VALUES ('PHI', NULL, 'NL', 'Philadelphia', 'Phillies');
INSERT INTO public."Teams" ("Code", "AlternativeCode", "LeagueId", "City", "Nickname") VALUES ('PIT', NULL, 'NL', 'Pittsburgh', 'Pirates');
INSERT INTO public."Teams" ("Code", "AlternativeCode", "LeagueId", "City", "Nickname") VALUES ('SD', NULL, 'NL', 'San Diego', 'Padres');
INSERT INTO public."Teams" ("Code", "AlternativeCode", "LeagueId", "City", "Nickname") VALUES ('SEA', NULL, 'AL', 'Seattle', 'Mariners');
INSERT INTO public."Teams" ("Code", "AlternativeCode", "LeagueId", "City", "Nickname") VALUES ('SF', NULL, 'NL', 'San Francisco', 'Giants');
INSERT INTO public."Teams" ("Code", "AlternativeCode", "LeagueId", "City", "Nickname") VALUES ('STL', NULL, 'NL', 'St. Louis', 'Cardinals');
INSERT INTO public."Teams" ("Code", "AlternativeCode", "LeagueId", "City", "Nickname") VALUES ('TB', 'TAM', 'AL', 'Tampa Bay', 'Rays');
INSERT INTO public."Teams" ("Code", "AlternativeCode", "LeagueId", "City", "Nickname") VALUES ('TEX', NULL, 'AL', 'Texas', 'Rangers');
INSERT INTO public."Teams" ("Code", "AlternativeCode", "LeagueId", "City", "Nickname") VALUES ('TOR', NULL, 'AL', 'Toronto', 'Blue Jays');
INSERT INTO public."Teams" ("Code", "AlternativeCode", "LeagueId", "City", "Nickname") VALUES ('CHC', 'CHI', 'NL', 'Chicago', 'Cubs');
INSERT INTO public."Teams" ("Code", "AlternativeCode", "LeagueId", "City", "Nickname") VALUES ('WAS', 'WSH', 'NL', 'Washington', 'Nationals');


--
-- TOC entry 3357 (class 0 OID 16404)
-- Dependencies: 215
-- Data for Name: __EFMigrationsHistory; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public."__EFMigrationsHistory" ("MigrationId", "ProductVersion") VALUES ('20200513041941_InitialCreate', '3.1.3');
INSERT INTO public."__EFMigrationsHistory" ("MigrationId", "ProductVersion") VALUES ('20221101060806_RemovePosition', '6.0.5');
INSERT INTO public."__EFMigrationsHistory" ("MigrationId", "ProductVersion") VALUES ('20221114075540_RenameTeams', '6.0.5');
INSERT INTO public."__EFMigrationsHistory" ("MigrationId", "ProductVersion") VALUES ('20221213065028_increase-pos-size', '8.0.2');
INSERT INTO public."__EFMigrationsHistory" ("MigrationId", "ProductVersion") VALUES ('20240222173322_team-alt-codes', '8.0.2');
INSERT INTO public."__EFMigrationsHistory" ("MigrationId", "ProductVersion") VALUES ('20240404202243_NewBhqFields', '8.0.2');
INSERT INTO public."__EFMigrationsHistory" ("MigrationId", "ProductVersion") VALUES ('20240419185534_RemoveBhqId', '8.0.2');


--
-- TOC entry 3191 (class 2606 OID 16408)
-- Name: BattingStats BattingStats_PK; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."BattingStats"
    ADD CONSTRAINT "BattingStats_PK" PRIMARY KEY ("PlayerId", "StatsType");


--
-- TOC entry 3193 (class 2606 OID 16410)
-- Name: LeagueStatuses LeagueStatus_PK; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."LeagueStatuses"
    ADD CONSTRAINT "LeagueStatus_PK" PRIMARY KEY ("PlayerId", "LeagueId");


--
-- TOC entry 3197 (class 2606 OID 16412)
-- Name: PlayerPositionEntity PK_PlayerPositionEntity; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."PlayerPositionEntity"
    ADD CONSTRAINT "PK_PlayerPositionEntity" PRIMARY KEY ("PlayerId", "PositionCode");


--
-- TOC entry 3206 (class 2606 OID 16414)
-- Name: __EFMigrationsHistory PK___EFMigrationsHistory; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."__EFMigrationsHistory"
    ADD CONSTRAINT "PK___EFMigrationsHistory" PRIMARY KEY ("MigrationId");


--
-- TOC entry 3195 (class 2606 OID 16416)
-- Name: PitchingStats PitchingStats_PK; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."PitchingStats"
    ADD CONSTRAINT "PitchingStats_PK" PRIMARY KEY ("PlayerId", "StatsType");


--
-- TOC entry 3200 (class 2606 OID 24645)
-- Name: Players Player_MlbAmId_AK; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Players"
    ADD CONSTRAINT "Player_MlbAmId_AK" UNIQUE ("MlbAmId", "Type");


--
-- TOC entry 3202 (class 2606 OID 16420)
-- Name: Players Player_PK; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Players"
    ADD CONSTRAINT "Player_PK" PRIMARY KEY ("Id");


--
-- TOC entry 3204 (class 2606 OID 16422)
-- Name: Teams Team_PK; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Teams"
    ADD CONSTRAINT "Team_PK" PRIMARY KEY ("Code");


--
-- TOC entry 3198 (class 1259 OID 16423)
-- Name: IX_Players_Team; Type: INDEX; Schema: public; Owner: postgres
--

CREATE INDEX "IX_Players_Team" ON public."Players" USING btree ("Team");


--
-- TOC entry 3207 (class 2606 OID 16424)
-- Name: BattingStats BattingStats_Player_FK; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."BattingStats"
    ADD CONSTRAINT "BattingStats_Player_FK" FOREIGN KEY ("PlayerId") REFERENCES public."Players"("Id") ON DELETE CASCADE;


--
-- TOC entry 3208 (class 2606 OID 16429)
-- Name: LeagueStatuses LeagueStatus_Player_FK; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."LeagueStatuses"
    ADD CONSTRAINT "LeagueStatus_Player_FK" FOREIGN KEY ("PlayerId") REFERENCES public."Players"("Id") ON DELETE CASCADE;


--
-- TOC entry 3209 (class 2606 OID 16434)
-- Name: PitchingStats PitchingStats_Player_FK; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."PitchingStats"
    ADD CONSTRAINT "PitchingStats_Player_FK" FOREIGN KEY ("PlayerId") REFERENCES public."Players"("Id") ON DELETE CASCADE;


--
-- TOC entry 3210 (class 2606 OID 16439)
-- Name: PlayerPositionEntity PlayerPosition_Player_FK; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."PlayerPositionEntity"
    ADD CONSTRAINT "PlayerPosition_Player_FK" FOREIGN KEY ("PlayerId") REFERENCES public."Players"("Id") ON DELETE CASCADE;


--
-- TOC entry 3211 (class 2606 OID 16444)
-- Name: Players Player_Team_FK; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Players"
    ADD CONSTRAINT "Player_Team_FK" FOREIGN KEY ("Team") REFERENCES public."Teams"("Code");


-- Completed on 2024-04-19 19:00:46 UTC

--
-- PostgreSQL database dump complete
--

