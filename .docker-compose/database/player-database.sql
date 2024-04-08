--
-- PostgreSQL database dump
--

-- Dumped from database version 14.1
-- Dumped by pg_dump version 14.2

-- Started on 2024-04-04 21:43:37 UTC

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
    "BhqId" integer NOT NULL,
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
-- TOC entry 214 (class 1259 OID 16400)
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
-- TOC entry 215 (class 1259 OID 16403)
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

INSERT INTO public."BattingStats" ("PlayerId", "StatsType", "AtBats", "Runs", "Hits", "Doubles", "Triples", "HomeRuns", "RunsBattedIn", "BaseOnBalls", "StrikeOuts", "StolenBases", "CaughtStealing", "Power", "Speed") VALUES ('d1df308b-1ea9-4419-8729-d2cac3753e6b', 3, 307, 54, 82, 17, 1, 11, 38, 37, 79, 6, 2, 103.10749185667753, 104.14983713355049);
INSERT INTO public."BattingStats" ("PlayerId", "StatsType", "AtBats", "Runs", "Hits", "Doubles", "Triples", "HomeRuns", "RunsBattedIn", "BaseOnBalls", "StrikeOuts", "StolenBases", "CaughtStealing", "Power", "Speed") VALUES ('643d1447-e90a-4677-898a-bd1d02bed609', 3, 423, 56, 101, 19, 3, 19, 64, 58, 114, 1, 3, 113.95744680851064, 106.36170212765957);
INSERT INTO public."BattingStats" ("PlayerId", "StatsType", "AtBats", "Runs", "Hits", "Doubles", "Triples", "HomeRuns", "RunsBattedIn", "BaseOnBalls", "StrikeOuts", "StolenBases", "CaughtStealing", "Power", "Speed") VALUES ('0354b4bf-2ef4-47be-bf08-ecaa1704873c', 3, 10, 1, 2, 1, 0, 0, 1, 1, 4, 0, 0, 90, 103);
INSERT INTO public."BattingStats" ("PlayerId", "StatsType", "AtBats", "Runs", "Hits", "Doubles", "Triples", "HomeRuns", "RunsBattedIn", "BaseOnBalls", "StrikeOuts", "StolenBases", "CaughtStealing", "Power", "Speed") VALUES ('29a2c849-3eca-4a32-a695-d42dfdc865cd', 3, 516, 60, 129, 31, 4, 8, 60, 54, 104, 12, 3, 80.69186046511628, 121.21511627906976);
INSERT INTO public."BattingStats" ("PlayerId", "StatsType", "AtBats", "Runs", "Hits", "Doubles", "Triples", "HomeRuns", "RunsBattedIn", "BaseOnBalls", "StrikeOuts", "StolenBases", "CaughtStealing", "Power", "Speed") VALUES ('1fe5d5b4-e833-4828-ac28-4bd253c78aa0', 3, 571, 120, 164, 23, 0, 55, 117, 74, 169, 10, 1, 194.94746059544659, 61.49562171628722);
INSERT INTO public."BattingStats" ("PlayerId", "StatsType", "AtBats", "Runs", "Hits", "Doubles", "Triples", "HomeRuns", "RunsBattedIn", "BaseOnBalls", "StrikeOuts", "StolenBases", "CaughtStealing", "Power", "Speed") VALUES ('17331001-9ba0-478d-ae5d-141f64d84196', 3, 526, 64, 125, 28, 0, 31, 100, 52, 115, 0, 0, 134.14638783269962, 52.81939163498099);
INSERT INTO public."BattingStats" ("PlayerId", "StatsType", "AtBats", "Runs", "Hits", "Doubles", "Triples", "HomeRuns", "RunsBattedIn", "BaseOnBalls", "StrikeOuts", "StolenBases", "CaughtStealing", "Power", "Speed") VALUES ('096483e1-eaf6-4eb8-85b1-6492ff7db10d', 3, 496, 60, 136, 25, 5, 16, 71, 25, 121, 20, 4, 102.56451612903226, 132.48387096774192);
INSERT INTO public."BattingStats" ("PlayerId", "StatsType", "AtBats", "Runs", "Hits", "Doubles", "Triples", "HomeRuns", "RunsBattedIn", "BaseOnBalls", "StrikeOuts", "StolenBases", "CaughtStealing", "Power", "Speed") VALUES ('010ae0a2-84ee-48cf-9cf7-8a2ec508cc33', 3, 115, 14, 29, 4, 1, 1, 10, 19, 33, 6, 1, 50.947826086956525, 98.6608695652174);
INSERT INTO public."BattingStats" ("PlayerId", "StatsType", "AtBats", "Runs", "Hits", "Doubles", "Triples", "HomeRuns", "RunsBattedIn", "BaseOnBalls", "StrikeOuts", "StolenBases", "CaughtStealing", "Power", "Speed") VALUES ('ac2a670c-6da8-4252-99fd-7d952706a816', 3, 200, 31, 49, 4, 0, 16, 32, 22, 96, 6, 1, 211.25, 94.5);
INSERT INTO public."BattingStats" ("PlayerId", "StatsType", "AtBats", "Runs", "Hits", "Doubles", "Triples", "HomeRuns", "RunsBattedIn", "BaseOnBalls", "StrikeOuts", "StolenBases", "CaughtStealing", "Power", "Speed") VALUES ('ef0b95a8-da60-4c25-926d-cf60476821b0', 3, 545, 78, 124, 23, 2, 36, 78, 81, 127, 0, 3, 137.6697247706422, 97.29908256880734);
INSERT INTO public."BattingStats" ("PlayerId", "StatsType", "AtBats", "Runs", "Hits", "Doubles", "Triples", "HomeRuns", "RunsBattedIn", "BaseOnBalls", "StrikeOuts", "StolenBases", "CaughtStealing", "Power", "Speed") VALUES ('5801e077-cc58-43e9-ad4a-f9802fee7369', 3, 478, 83, 122, 21, 7, 27, 87, 46, 151, 27, 10, 151.59623430962344, 130.32635983263597);
INSERT INTO public."BattingStats" ("PlayerId", "StatsType", "AtBats", "Runs", "Hits", "Doubles", "Triples", "HomeRuns", "RunsBattedIn", "BaseOnBalls", "StrikeOuts", "StolenBases", "CaughtStealing", "Power", "Speed") VALUES ('c4608bbb-dc81-4891-9775-78946407d39c', 3, 430, 65, 106, 24, 5, 10, 43, 42, 88, 17, 6, 93.76046511627906, 103.26279069767442);
INSERT INTO public."BattingStats" ("PlayerId", "StatsType", "AtBats", "Runs", "Hits", "Doubles", "Triples", "HomeRuns", "RunsBattedIn", "BaseOnBalls", "StrikeOuts", "StolenBases", "CaughtStealing", "Power", "Speed") VALUES ('b1f37406-2a67-4b8c-91c1-75a50a6f763d', 3, 204, 37, 50, 8, 0, 12, 34, 30, 52, 6, 3, 132.5441176470588, 93);
INSERT INTO public."BattingStats" ("PlayerId", "StatsType", "AtBats", "Runs", "Hits", "Doubles", "Triples", "HomeRuns", "RunsBattedIn", "BaseOnBalls", "StrikeOuts", "StolenBases", "CaughtStealing", "Power", "Speed") VALUES ('2399dd10-b652-4796-8248-80b3975a936a', 3, 101, 20, 30, 4, 0, 4, 14, 8, 21, 5, 1, 95.16831683168317, 121.99009900990099);
INSERT INTO public."BattingStats" ("PlayerId", "StatsType", "AtBats", "Runs", "Hits", "Doubles", "Triples", "HomeRuns", "RunsBattedIn", "BaseOnBalls", "StrikeOuts", "StolenBases", "CaughtStealing", "Power", "Speed") VALUES ('8a03b582-c34a-4f16-afa5-6f3447a4b47a', 3, 357, 47, 87, 17, 4, 8, 40, 31, 114, 4, 5, 95.593837535014, 125.05042016806723);
INSERT INTO public."BattingStats" ("PlayerId", "StatsType", "AtBats", "Runs", "Hits", "Doubles", "Triples", "HomeRuns", "RunsBattedIn", "BaseOnBalls", "StrikeOuts", "StolenBases", "CaughtStealing", "Power", "Speed") VALUES ('081f3aa5-b16c-4e83-80d7-1b905c525a72', 3, 335, 54, 78, 17, 0, 22, 50, 39, 62, 0, 1, 136.5134328358209, 70.7641791044776);
INSERT INTO public."BattingStats" ("PlayerId", "StatsType", "AtBats", "Runs", "Hits", "Doubles", "Triples", "HomeRuns", "RunsBattedIn", "BaseOnBalls", "StrikeOuts", "StolenBases", "CaughtStealing", "Power", "Speed") VALUES ('096483e1-eaf6-4eb8-85b1-6492ff7db10d', 2, 64, 8, 16, 4, 0, 3, 8, 4, 15, 3, 1, 117, 120);
INSERT INTO public."BattingStats" ("PlayerId", "StatsType", "AtBats", "Runs", "Hits", "Doubles", "Triples", "HomeRuns", "RunsBattedIn", "BaseOnBalls", "StrikeOuts", "StolenBases", "CaughtStealing", "Power", "Speed") VALUES ('e9137344-a90c-4d35-be6f-cd3f435542eb', 3, 301, 46, 82, 18, 3, 7, 35, 22, 35, 6, 1, 83.13953488372093, 106.30232558139535);
INSERT INTO public."BattingStats" ("PlayerId", "StatsType", "AtBats", "Runs", "Hits", "Doubles", "Triples", "HomeRuns", "RunsBattedIn", "BaseOnBalls", "StrikeOuts", "StolenBases", "CaughtStealing", "Power", "Speed") VALUES ('1b6f447e-affe-4509-845a-09aadeba3b4c', 2, 15, 2, 3, 1, 0, 0, 1, 1, 4, 1, 0, 99, 139);
INSERT INTO public."BattingStats" ("PlayerId", "StatsType", "AtBats", "Runs", "Hits", "Doubles", "Triples", "HomeRuns", "RunsBattedIn", "BaseOnBalls", "StrikeOuts", "StolenBases", "CaughtStealing", "Power", "Speed") VALUES ('0aa22cce-8c66-4b09-9b5d-7ac2db34bbe3', 2, 18, 2, 4, 1, 0, 1, 2, 2, 6, 0, 0, 120, 97);
INSERT INTO public."BattingStats" ("PlayerId", "StatsType", "AtBats", "Runs", "Hits", "Doubles", "Triples", "HomeRuns", "RunsBattedIn", "BaseOnBalls", "StrikeOuts", "StolenBases", "CaughtStealing", "Power", "Speed") VALUES ('1fe5d5b4-e833-4828-ac28-4bd253c78aa0', 1, 505, 113, 155, 23, 0, 55, 121, 87, 154, 16, 2, 233, 55);
INSERT INTO public."BattingStats" ("PlayerId", "StatsType", "AtBats", "Runs", "Hits", "Doubles", "Triples", "HomeRuns", "RunsBattedIn", "BaseOnBalls", "StrikeOuts", "StolenBases", "CaughtStealing", "Power", "Speed") VALUES ('096483e1-eaf6-4eb8-85b1-6492ff7db10d', 1, 418, 53, 125, 23, 2, 16, 62, 29, 94, 18, 3, 112, 135);
INSERT INTO public."BattingStats" ("PlayerId", "StatsType", "AtBats", "Runs", "Hits", "Doubles", "Triples", "HomeRuns", "RunsBattedIn", "BaseOnBalls", "StrikeOuts", "StolenBases", "CaughtStealing", "Power", "Speed") VALUES ('82a7ac73-8279-481f-b41e-49b0b9901250', 3, 519, 70, 126, 24, 0, 19, 70, 51, 118, 9, 7, 95.64739884393063, 80.878612716763);
INSERT INTO public."BattingStats" ("PlayerId", "StatsType", "AtBats", "Runs", "Hits", "Doubles", "Triples", "HomeRuns", "RunsBattedIn", "BaseOnBalls", "StrikeOuts", "StolenBases", "CaughtStealing", "Power", "Speed") VALUES ('47b9f5a7-811a-4a16-9385-f575de5d4389', 3, 458, 82, 118, 20, 3, 25, 67, 51, 99, 12, 2, 125.86899563318778, 111.02183406113537);
INSERT INTO public."BattingStats" ("PlayerId", "StatsType", "AtBats", "Runs", "Hits", "Doubles", "Triples", "HomeRuns", "RunsBattedIn", "BaseOnBalls", "StrikeOuts", "StolenBases", "CaughtStealing", "Power", "Speed") VALUES ('1fe5d5b4-e833-4828-ac28-4bd253c78aa0', 2, 62, 13, 18, 3, 0, 7, 14, 10, 19, 2, 0, 232, 73);
INSERT INTO public."BattingStats" ("PlayerId", "StatsType", "AtBats", "Runs", "Hits", "Doubles", "Triples", "HomeRuns", "RunsBattedIn", "BaseOnBalls", "StrikeOuts", "StolenBases", "CaughtStealing", "Power", "Speed") VALUES ('29a2c849-3eca-4a32-a695-d42dfdc865cd', 1, 444, 49, 111, 25, 3, 8, 51, 45, 88, 9, 2, 81, 120);
INSERT INTO public."BattingStats" ("PlayerId", "StatsType", "AtBats", "Runs", "Hits", "Doubles", "Triples", "HomeRuns", "RunsBattedIn", "BaseOnBalls", "StrikeOuts", "StolenBases", "CaughtStealing", "Power", "Speed") VALUES ('29a2c849-3eca-4a32-a695-d42dfdc865cd', 2, 66, 8, 16, 4, 0, 1, 8, 7, 13, 1, 0, 72, 104);
INSERT INTO public."BattingStats" ("PlayerId", "StatsType", "AtBats", "Runs", "Hits", "Doubles", "Triples", "HomeRuns", "RunsBattedIn", "BaseOnBalls", "StrikeOuts", "StolenBases", "CaughtStealing", "Power", "Speed") VALUES ('3d71e823-f1e8-49e5-aad1-97f39ca448ef', 2, 32, 3, 8, 1, 0, 1, 3, 4, 7, 0, 0, 84, 78);
INSERT INTO public."BattingStats" ("PlayerId", "StatsType", "AtBats", "Runs", "Hits", "Doubles", "Triples", "HomeRuns", "RunsBattedIn", "BaseOnBalls", "StrikeOuts", "StolenBases", "CaughtStealing", "Power", "Speed") VALUES ('379e76bb-af9c-490f-b8d1-73a0f3cdb9f8', 2, 66, 11, 16, 4, 0, 4, 12, 6, 19, 1, 0, 154, 96);
INSERT INTO public."BattingStats" ("PlayerId", "StatsType", "AtBats", "Runs", "Hits", "Doubles", "Triples", "HomeRuns", "RunsBattedIn", "BaseOnBalls", "StrikeOuts", "StolenBases", "CaughtStealing", "Power", "Speed") VALUES ('379f2dec-88b0-46c4-961e-40e5df7ba20f', 1, 468, 64, 121, 25, 1, 25, 90, 54, 83, 22, 2, 124, 77);
INSERT INTO public."BattingStats" ("PlayerId", "StatsType", "AtBats", "Runs", "Hits", "Doubles", "Triples", "HomeRuns", "RunsBattedIn", "BaseOnBalls", "StrikeOuts", "StolenBases", "CaughtStealing", "Power", "Speed") VALUES ('379f2dec-88b0-46c4-961e-40e5df7ba20f', 2, 68, 10, 18, 4, 0, 4, 13, 8, 12, 3, 0, 135, 100);
INSERT INTO public."BattingStats" ("PlayerId", "StatsType", "AtBats", "Runs", "Hits", "Doubles", "Triples", "HomeRuns", "RunsBattedIn", "BaseOnBalls", "StrikeOuts", "StolenBases", "CaughtStealing", "Power", "Speed") VALUES ('5801e077-cc58-43e9-ad4a-f9802fee7369', 1, 213, 39, 54, 10, 4, 14, 45, 21, 66, 12, 5, 179, 130);
INSERT INTO public."BattingStats" ("PlayerId", "StatsType", "AtBats", "Runs", "Hits", "Doubles", "Triples", "HomeRuns", "RunsBattedIn", "BaseOnBalls", "StrikeOuts", "StolenBases", "CaughtStealing", "Power", "Speed") VALUES ('e2f3a018-6216-43fa-a24c-96d5f6f61685', 3, 511, 77, 137, 26, 3, 25, 78, 41, 150, 28, 8, 134.57142857142858, 145.14285714285714);
INSERT INTO public."BattingStats" ("PlayerId", "StatsType", "AtBats", "Runs", "Hits", "Doubles", "Triples", "HomeRuns", "RunsBattedIn", "BaseOnBalls", "StrikeOuts", "StolenBases", "CaughtStealing", "Power", "Speed") VALUES ('a7da4769-9b95-4317-8a35-251d4ec5fd20', 3, 377, 41, 104, 27, 5, 7, 41, 20, 99, 7, 5, 107.0238726790451, 132.75596816976127);
INSERT INTO public."BattingStats" ("PlayerId", "StatsType", "AtBats", "Runs", "Hits", "Doubles", "Triples", "HomeRuns", "RunsBattedIn", "BaseOnBalls", "StrikeOuts", "StolenBases", "CaughtStealing", "Power", "Speed") VALUES ('b690f262-e87a-4038-add9-6d64af2ada29', 3, 330, 51, 76, 15, 0, 16, 42, 30, 116, 2, 0, 139.9030303030303, 93.10303030303031);
INSERT INTO public."BattingStats" ("PlayerId", "StatsType", "AtBats", "Runs", "Hits", "Doubles", "Triples", "HomeRuns", "RunsBattedIn", "BaseOnBalls", "StrikeOuts", "StolenBases", "CaughtStealing", "Power", "Speed") VALUES ('643d1447-e90a-4677-898a-bd1d02bed609', 1, 379, 43, 83, 16, 2, 15, 52, 55, 111, 1, 1, 113, 102);
INSERT INTO public."BattingStats" ("PlayerId", "StatsType", "AtBats", "Runs", "Hits", "Doubles", "Triples", "HomeRuns", "RunsBattedIn", "BaseOnBalls", "StrikeOuts", "StolenBases", "CaughtStealing", "Power", "Speed") VALUES ('643d1447-e90a-4677-898a-bd1d02bed609', 2, 60, 8, 15, 3, 0, 3, 10, 8, 17, 0, 0, 120, 105);
INSERT INTO public."BattingStats" ("PlayerId", "StatsType", "AtBats", "Runs", "Hits", "Doubles", "Triples", "HomeRuns", "RunsBattedIn", "BaseOnBalls", "StrikeOuts", "StolenBases", "CaughtStealing", "Power", "Speed") VALUES ('17331001-9ba0-478d-ae5d-141f64d84196', 1, 460, 56, 105, 23, 0, 30, 80, 55, 106, 2, 1, 146, 43);
INSERT INTO public."BattingStats" ("PlayerId", "StatsType", "AtBats", "Runs", "Hits", "Doubles", "Triples", "HomeRuns", "RunsBattedIn", "BaseOnBalls", "StrikeOuts", "StolenBases", "CaughtStealing", "Power", "Speed") VALUES ('17331001-9ba0-478d-ae5d-141f64d84196', 2, 57, 7, 15, 3, 0, 3, 10, 7, 14, 0, 0, 132, 74);
INSERT INTO public."BattingStats" ("PlayerId", "StatsType", "AtBats", "Runs", "Hits", "Doubles", "Triples", "HomeRuns", "RunsBattedIn", "BaseOnBalls", "StrikeOuts", "StolenBases", "CaughtStealing", "Power", "Speed") VALUES ('17c04c57-e2a3-4265-b4e7-173c97bbb1cd', 1, 292, 56, 90, 25, 1, 16, 55, 36, 67, 9, 4, 164, 84);
INSERT INTO public."BattingStats" ("PlayerId", "StatsType", "AtBats", "Runs", "Hits", "Doubles", "Triples", "HomeRuns", "RunsBattedIn", "BaseOnBalls", "StrikeOuts", "StolenBases", "CaughtStealing", "Power", "Speed") VALUES ('17c04c57-e2a3-4265-b4e7-173c97bbb1cd', 2, 58, 12, 17, 5, 0, 4, 12, 10, 15, 2, 1, 171, 94);
INSERT INTO public."BattingStats" ("PlayerId", "StatsType", "AtBats", "Runs", "Hits", "Doubles", "Triples", "HomeRuns", "RunsBattedIn", "BaseOnBalls", "StrikeOuts", "StolenBases", "CaughtStealing", "Power", "Speed") VALUES ('0aa22cce-8c66-4b09-9b5d-7ac2db34bbe3', 1, 124, 12, 33, 4, 0, 5, 19, 13, 40, 2, 0, 104, 91);
INSERT INTO public."BattingStats" ("PlayerId", "StatsType", "AtBats", "Runs", "Hits", "Doubles", "Triples", "HomeRuns", "RunsBattedIn", "BaseOnBalls", "StrikeOuts", "StolenBases", "CaughtStealing", "Power", "Speed") VALUES ('1a2b372b-44b2-4989-8af0-6499a2659c87', 1, 498, 90, 130, 22, 4, 12, 50, 75, 136, 16, 2, 89, 149);
INSERT INTO public."BattingStats" ("PlayerId", "StatsType", "AtBats", "Runs", "Hits", "Doubles", "Triples", "HomeRuns", "RunsBattedIn", "BaseOnBalls", "StrikeOuts", "StolenBases", "CaughtStealing", "Power", "Speed") VALUES ('1a2b372b-44b2-4989-8af0-6499a2659c87', 2, 59, 11, 15, 3, 0, 2, 6, 9, 16, 2, 0, 95, 112);
INSERT INTO public."BattingStats" ("PlayerId", "StatsType", "AtBats", "Runs", "Hits", "Doubles", "Triples", "HomeRuns", "RunsBattedIn", "BaseOnBalls", "StrikeOuts", "StolenBases", "CaughtStealing", "Power", "Speed") VALUES ('1b6f447e-affe-4509-845a-09aadeba3b4c', 1, 35, 3, 6, 1, 1, 0, 2, 1, 7, 1, 2, 49, 158);
INSERT INTO public."BattingStats" ("PlayerId", "StatsType", "AtBats", "Runs", "Hits", "Doubles", "Triples", "HomeRuns", "RunsBattedIn", "BaseOnBalls", "StrikeOuts", "StolenBases", "CaughtStealing", "Power", "Speed") VALUES ('23889720-3073-4c37-a7dd-63fdb633498b', 1, 398, 50, 100, 19, 1, 25, 62, 33, 101, 1, 1, 147, 88);
INSERT INTO public."BattingStats" ("PlayerId", "StatsType", "AtBats", "Runs", "Hits", "Doubles", "Triples", "HomeRuns", "RunsBattedIn", "BaseOnBalls", "StrikeOuts", "StolenBases", "CaughtStealing", "Power", "Speed") VALUES ('43ee2b05-10b6-4894-a6cd-5c47a2f45160', 2, 4, 0, 1, 0, 0, 0, 0, 0, 1, 0, 0, 81, 109);
INSERT INTO public."BattingStats" ("PlayerId", "StatsType", "AtBats", "Runs", "Hits", "Doubles", "Triples", "HomeRuns", "RunsBattedIn", "BaseOnBalls", "StrikeOuts", "StolenBases", "CaughtStealing", "Power", "Speed") VALUES ('5801e077-cc58-43e9-ad4a-f9802fee7369', 2, 11, 2, 3, 0, 0, 0, 2, 1, 3, 1, 0, 135, 119);
INSERT INTO public."BattingStats" ("PlayerId", "StatsType", "AtBats", "Runs", "Hits", "Doubles", "Triples", "HomeRuns", "RunsBattedIn", "BaseOnBalls", "StrikeOuts", "StolenBases", "CaughtStealing", "Power", "Speed") VALUES ('1b6f447e-affe-4509-845a-09aadeba3b4c', 3, 107, 11, 23, 5, 1, 2, 10, 6, 25, 8, 4, 74.20560747663552, 131.5607476635514);
INSERT INTO public."BattingStats" ("PlayerId", "StatsType", "AtBats", "Runs", "Hits", "Doubles", "Triples", "HomeRuns", "RunsBattedIn", "BaseOnBalls", "StrikeOuts", "StolenBases", "CaughtStealing", "Power", "Speed") VALUES ('19abc855-4ce0-40f7-8e58-8808a15f0462', 1, 12, 0, 3, 0, 0, 0, 0, 0, 7, 0, 0, 0, 114);
INSERT INTO public."BattingStats" ("PlayerId", "StatsType", "AtBats", "Runs", "Hits", "Doubles", "Triples", "HomeRuns", "RunsBattedIn", "BaseOnBalls", "StrikeOuts", "StolenBases", "CaughtStealing", "Power", "Speed") VALUES ('1e6f7190-9b05-4abe-b88d-e4624f4b555d', 1, 456, 69, 110, 20, 3, 24, 68, 43, 118, 10, 6, 132, 92);
INSERT INTO public."BattingStats" ("PlayerId", "StatsType", "AtBats", "Runs", "Hits", "Doubles", "Triples", "HomeRuns", "RunsBattedIn", "BaseOnBalls", "StrikeOuts", "StolenBases", "CaughtStealing", "Power", "Speed") VALUES ('1e6f7190-9b05-4abe-b88d-e4624f4b555d', 2, 51, 8, 13, 2, 1, 2, 7, 5, 13, 1, 1, 124, 107);
INSERT INTO public."BattingStats" ("PlayerId", "StatsType", "AtBats", "Runs", "Hits", "Doubles", "Triples", "HomeRuns", "RunsBattedIn", "BaseOnBalls", "StrikeOuts", "StolenBases", "CaughtStealing", "Power", "Speed") VALUES ('47b9f5a7-811a-4a16-9385-f575de5d4389', 2, 65, 11, 17, 3, 0, 3, 10, 8, 13, 2, 0, 105, 89);
INSERT INTO public."BattingStats" ("PlayerId", "StatsType", "AtBats", "Runs", "Hits", "Doubles", "Triples", "HomeRuns", "RunsBattedIn", "BaseOnBalls", "StrikeOuts", "StolenBases", "CaughtStealing", "Power", "Speed") VALUES ('23889720-3073-4c37-a7dd-63fdb633498b', 2, 63, 8, 15, 3, 0, 4, 10, 5, 16, 0, 0, 132, 81);
INSERT INTO public."BattingStats" ("PlayerId", "StatsType", "AtBats", "Runs", "Hits", "Doubles", "Triples", "HomeRuns", "RunsBattedIn", "BaseOnBalls", "StrikeOuts", "StolenBases", "CaughtStealing", "Power", "Speed") VALUES ('31ac324b-fed5-4aec-80ee-f14688e07919', 1, 324, 41, 73, 16, 3, 16, 46, 20, 92, 3, 2, 139, 113);
INSERT INTO public."BattingStats" ("PlayerId", "StatsType", "AtBats", "Runs", "Hits", "Doubles", "Triples", "HomeRuns", "RunsBattedIn", "BaseOnBalls", "StrikeOuts", "StolenBases", "CaughtStealing", "Power", "Speed") VALUES ('31ac324b-fed5-4aec-80ee-f14688e07919', 2, 37, 5, 9, 2, 1, 2, 5, 3, 10, 1, 0, 158, 122);
INSERT INTO public."BattingStats" ("PlayerId", "StatsType", "AtBats", "Runs", "Hits", "Doubles", "Triples", "HomeRuns", "RunsBattedIn", "BaseOnBalls", "StrikeOuts", "StolenBases", "CaughtStealing", "Power", "Speed") VALUES ('7b7017f3-7de6-4348-b4a9-81286367d15c', 1, 542, 86, 145, 21, 4, 22, 91, 56, 113, 15, 4, 101, 129);
INSERT INTO public."BattingStats" ("PlayerId", "StatsType", "AtBats", "Runs", "Hits", "Doubles", "Triples", "HomeRuns", "RunsBattedIn", "BaseOnBalls", "StrikeOuts", "StolenBases", "CaughtStealing", "Power", "Speed") VALUES ('081f3aa5-b16c-4e83-80d7-1b905c525a72', 1, 277, 43, 59, 13, 0, 18, 40, 31, 58, 0, 1, 139, 65);
INSERT INTO public."BattingStats" ("PlayerId", "StatsType", "AtBats", "Runs", "Hits", "Doubles", "Triples", "HomeRuns", "RunsBattedIn", "BaseOnBalls", "StrikeOuts", "StolenBases", "CaughtStealing", "Power", "Speed") VALUES ('081f3aa5-b16c-4e83-80d7-1b905c525a72', 2, 50, 7, 13, 2, 0, 2, 7, 6, 10, 0, 0, 105, 92);
INSERT INTO public."BattingStats" ("PlayerId", "StatsType", "AtBats", "Runs", "Hits", "Doubles", "Triples", "HomeRuns", "RunsBattedIn", "BaseOnBalls", "StrikeOuts", "StolenBases", "CaughtStealing", "Power", "Speed") VALUES ('82a7ac73-8279-481f-b41e-49b0b9901250', 1, 462, 62, 112, 21, 0, 16, 62, 44, 104, 8, 6, 94, 80);
INSERT INTO public."BattingStats" ("PlayerId", "StatsType", "AtBats", "Runs", "Hits", "Doubles", "Triples", "HomeRuns", "RunsBattedIn", "BaseOnBalls", "StrikeOuts", "StolenBases", "CaughtStealing", "Power", "Speed") VALUES ('379e76bb-af9c-490f-b8d1-73a0f3cdb9f8', 1, 479, 74, 111, 25, 0, 28, 83, 41, 139, 5, 2, 149, 86);
INSERT INTO public."BattingStats" ("PlayerId", "StatsType", "AtBats", "Runs", "Hits", "Doubles", "Triples", "HomeRuns", "RunsBattedIn", "BaseOnBalls", "StrikeOuts", "StolenBases", "CaughtStealing", "Power", "Speed") VALUES ('43ee2b05-10b6-4894-a6cd-5c47a2f45160', 1, 15, 1, 4, 0, 0, 0, 0, 1, 2, 0, 0, 0, 118);
INSERT INTO public."BattingStats" ("PlayerId", "StatsType", "AtBats", "Runs", "Hits", "Doubles", "Triples", "HomeRuns", "RunsBattedIn", "BaseOnBalls", "StrikeOuts", "StolenBases", "CaughtStealing", "Power", "Speed") VALUES ('47b9f5a7-811a-4a16-9385-f575de5d4389', 1, 431, 74, 113, 19, 3, 19, 58, 48, 85, 13, 1, 109, 124);
INSERT INTO public."BattingStats" ("PlayerId", "StatsType", "AtBats", "Runs", "Hits", "Doubles", "Triples", "HomeRuns", "RunsBattedIn", "BaseOnBalls", "StrikeOuts", "StolenBases", "CaughtStealing", "Power", "Speed") VALUES ('7b7017f3-7de6-4348-b4a9-81286367d15c', 2, 69, 11, 17, 3, 0, 3, 11, 7, 14, 2, 1, 105, 99);
INSERT INTO public."BattingStats" ("PlayerId", "StatsType", "AtBats", "Runs", "Hits", "Doubles", "Triples", "HomeRuns", "RunsBattedIn", "BaseOnBalls", "StrikeOuts", "StolenBases", "CaughtStealing", "Power", "Speed") VALUES ('a7da4769-9b95-4317-8a35-251d4ec5fd20', 1, 331, 36, 93, 24, 4, 6, 36, 17, 87, 6, 4, 108, 133);
INSERT INTO public."BattingStats" ("PlayerId", "StatsType", "AtBats", "Runs", "Hits", "Doubles", "Triples", "HomeRuns", "RunsBattedIn", "BaseOnBalls", "StrikeOuts", "StolenBases", "CaughtStealing", "Power", "Speed") VALUES ('3d71e823-f1e8-49e5-aad1-97f39ca448ef', 1, 226, 19, 48, 11, 1, 4, 21, 27, 50, 0, 0, 74, 58);
INSERT INTO public."BattingStats" ("PlayerId", "StatsType", "AtBats", "Runs", "Hits", "Doubles", "Triples", "HomeRuns", "RunsBattedIn", "BaseOnBalls", "StrikeOuts", "StolenBases", "CaughtStealing", "Power", "Speed") VALUES ('b1f37406-2a67-4b8c-91c1-75a50a6f763d', 2, 52, 9, 13, 2, 0, 2, 9, 8, 15, 2, 1, 120, 98);
INSERT INTO public."BattingStats" ("PlayerId", "StatsType", "AtBats", "Runs", "Hits", "Doubles", "Triples", "HomeRuns", "RunsBattedIn", "BaseOnBalls", "StrikeOuts", "StolenBases", "CaughtStealing", "Power", "Speed") VALUES ('0354b4bf-2ef4-47be-bf08-ecaa1704873c', 2, 8, 1, 1, 0, 0, 0, 1, 1, 3, 0, 0, 85, 104);
INSERT INTO public."BattingStats" ("PlayerId", "StatsType", "AtBats", "Runs", "Hits", "Doubles", "Triples", "HomeRuns", "RunsBattedIn", "BaseOnBalls", "StrikeOuts", "StolenBases", "CaughtStealing", "Power", "Speed") VALUES ('d017942e-c5f9-49bf-9fb7-dbd129dedcab', 3, 46, 5, 8, 0, 0, 1, 5, 4, 16, 1, 0, 37.43478260869565, 110.52173913043478);
INSERT INTO public."BattingStats" ("PlayerId", "StatsType", "AtBats", "Runs", "Hits", "Doubles", "Triples", "HomeRuns", "RunsBattedIn", "BaseOnBalls", "StrikeOuts", "StolenBases", "CaughtStealing", "Power", "Speed") VALUES ('18fa5de6-e188-45f4-be68-f95140061639', 2, 4, 0, 1, 0, 0, 0, 0, 0, 1, 0, 0, 36, 118);
INSERT INTO public."BattingStats" ("PlayerId", "StatsType", "AtBats", "Runs", "Hits", "Doubles", "Triples", "HomeRuns", "RunsBattedIn", "BaseOnBalls", "StrikeOuts", "StolenBases", "CaughtStealing", "Power", "Speed") VALUES ('17c04c57-e2a3-4265-b4e7-173c97bbb1cd', 3, 343, 68, 107, 28, 1, 22, 68, 44, 76, 11, 3, 170.51020408163265, 81.18367346938776);
INSERT INTO public."BattingStats" ("PlayerId", "StatsType", "AtBats", "Runs", "Hits", "Doubles", "Triples", "HomeRuns", "RunsBattedIn", "BaseOnBalls", "StrikeOuts", "StolenBases", "CaughtStealing", "Power", "Speed") VALUES ('a54864b7-9923-44aa-8627-3acb70462246', 1, 519, 75, 131, 27, 2, 28, 71, 66, 141, 2, 1, 141, 90);
INSERT INTO public."BattingStats" ("PlayerId", "StatsType", "AtBats", "Runs", "Hits", "Doubles", "Triples", "HomeRuns", "RunsBattedIn", "BaseOnBalls", "StrikeOuts", "StolenBases", "CaughtStealing", "Power", "Speed") VALUES ('a54864b7-9923-44aa-8627-3acb70462246', 2, 60, 9, 15, 4, 0, 4, 9, 8, 16, 0, 0, 154, 82);
INSERT INTO public."BattingStats" ("PlayerId", "StatsType", "AtBats", "Runs", "Hits", "Doubles", "Triples", "HomeRuns", "RunsBattedIn", "BaseOnBalls", "StrikeOuts", "StolenBases", "CaughtStealing", "Power", "Speed") VALUES ('b1f37406-2a67-4b8c-91c1-75a50a6f763d', 1, 158, 30, 40, 8, 0, 10, 23, 20, 37, 3, 1, 144, 95);
INSERT INTO public."BattingStats" ("PlayerId", "StatsType", "AtBats", "Runs", "Hits", "Doubles", "Triples", "HomeRuns", "RunsBattedIn", "BaseOnBalls", "StrikeOuts", "StolenBases", "CaughtStealing", "Power", "Speed") VALUES ('010ae0a2-84ee-48cf-9cf7-8a2ec508cc33', 1, 76, 9, 17, 1, 0, 0, 4, 14, 26, 7, 1, 14, 104);
INSERT INTO public."BattingStats" ("PlayerId", "StatsType", "AtBats", "Runs", "Hits", "Doubles", "Triples", "HomeRuns", "RunsBattedIn", "BaseOnBalls", "StrikeOuts", "StolenBases", "CaughtStealing", "Power", "Speed") VALUES ('010ae0a2-84ee-48cf-9cf7-8a2ec508cc33', 2, 3, 0, 1, 0, 0, 0, 0, 1, 1, 0, 0, 55, 97);
INSERT INTO public."BattingStats" ("PlayerId", "StatsType", "AtBats", "Runs", "Hits", "Doubles", "Triples", "HomeRuns", "RunsBattedIn", "BaseOnBalls", "StrikeOuts", "StolenBases", "CaughtStealing", "Power", "Speed") VALUES ('a7da4769-9b95-4317-8a35-251d4ec5fd20', 2, 46, 5, 11, 3, 1, 1, 5, 3, 12, 1, 1, 100, 131);
INSERT INTO public."BattingStats" ("PlayerId", "StatsType", "AtBats", "Runs", "Hits", "Doubles", "Triples", "HomeRuns", "RunsBattedIn", "BaseOnBalls", "StrikeOuts", "StolenBases", "CaughtStealing", "Power", "Speed") VALUES ('ac2a670c-6da8-4252-99fd-7d952706a816', 1, 203, 31, 48, 4, 1, 14, 30, 20, 96, 5, 1, 189, 126);
INSERT INTO public."BattingStats" ("PlayerId", "StatsType", "AtBats", "Runs", "Hits", "Doubles", "Triples", "HomeRuns", "RunsBattedIn", "BaseOnBalls", "StrikeOuts", "StolenBases", "CaughtStealing", "Power", "Speed") VALUES ('ac2a670c-6da8-4252-99fd-7d952706a816', 2, 30, 4, 6, 1, 0, 2, 4, 3, 13, 1, 0, 158, 105);
INSERT INTO public."BattingStats" ("PlayerId", "StatsType", "AtBats", "Runs", "Hits", "Doubles", "Triples", "HomeRuns", "RunsBattedIn", "BaseOnBalls", "StrikeOuts", "StolenBases", "CaughtStealing", "Power", "Speed") VALUES ('9f0384ee-02a9-43b7-88dc-4d9c7f530dda', 2, 61, 10, 14, 4, 0, 4, 9, 7, 20, 0, 0, 164, 89);
INSERT INTO public."BattingStats" ("PlayerId", "StatsType", "AtBats", "Runs", "Hits", "Doubles", "Triples", "HomeRuns", "RunsBattedIn", "BaseOnBalls", "StrikeOuts", "StolenBases", "CaughtStealing", "Power", "Speed") VALUES ('b690f262-e87a-4038-add9-6d64af2ada29', 1, 278, 44, 64, 13, 0, 14, 35, 26, 100, 1, 0, 144, 92);
INSERT INTO public."BattingStats" ("PlayerId", "StatsType", "AtBats", "Runs", "Hits", "Doubles", "Triples", "HomeRuns", "RunsBattedIn", "BaseOnBalls", "StrikeOuts", "StolenBases", "CaughtStealing", "Power", "Speed") VALUES ('b690f262-e87a-4038-add9-6d64af2ada29', 2, 52, 7, 12, 2, 0, 2, 7, 4, 16, 1, 0, 118, 99);
INSERT INTO public."BattingStats" ("PlayerId", "StatsType", "AtBats", "Runs", "Hits", "Doubles", "Triples", "HomeRuns", "RunsBattedIn", "BaseOnBalls", "StrikeOuts", "StolenBases", "CaughtStealing", "Power", "Speed") VALUES ('bf019d49-25bd-4885-9d2b-55ee958fe547', 1, 358, 48, 80, 12, 1, 15, 43, 48, 91, 1, 2, 101, 100);
INSERT INTO public."BattingStats" ("PlayerId", "StatsType", "AtBats", "Runs", "Hits", "Doubles", "Triples", "HomeRuns", "RunsBattedIn", "BaseOnBalls", "StrikeOuts", "StolenBases", "CaughtStealing", "Power", "Speed") VALUES ('bf019d49-25bd-4885-9d2b-55ee958fe547', 2, 61, 8, 15, 3, 0, 3, 8, 7, 15, 1, 0, 113, 98);
INSERT INTO public."BattingStats" ("PlayerId", "StatsType", "AtBats", "Runs", "Hits", "Doubles", "Triples", "HomeRuns", "RunsBattedIn", "BaseOnBalls", "StrikeOuts", "StolenBases", "CaughtStealing", "Power", "Speed") VALUES ('c4608bbb-dc81-4891-9775-78946407d39c', 1, 371, 56, 91, 21, 4, 11, 37, 37, 76, 14, 4, 103, 104);
INSERT INTO public."BattingStats" ("PlayerId", "StatsType", "AtBats", "Runs", "Hits", "Doubles", "Triples", "HomeRuns", "RunsBattedIn", "BaseOnBalls", "StrikeOuts", "StolenBases", "CaughtStealing", "Power", "Speed") VALUES ('c4608bbb-dc81-4891-9775-78946407d39c', 2, 55, 8, 14, 3, 1, 2, 6, 6, 11, 2, 1, 106, 102);
INSERT INTO public."BattingStats" ("PlayerId", "StatsType", "AtBats", "Runs", "Hits", "Doubles", "Triples", "HomeRuns", "RunsBattedIn", "BaseOnBalls", "StrikeOuts", "StolenBases", "CaughtStealing", "Power", "Speed") VALUES ('d1df308b-1ea9-4419-8729-d2cac3753e6b', 1, 317, 43, 83, 14, 2, 10, 35, 22, 78, 2, 4, 96, 130);
INSERT INTO public."BattingStats" ("PlayerId", "StatsType", "AtBats", "Runs", "Hits", "Doubles", "Triples", "HomeRuns", "RunsBattedIn", "BaseOnBalls", "StrikeOuts", "StolenBases", "CaughtStealing", "Power", "Speed") VALUES ('d1df308b-1ea9-4419-8729-d2cac3753e6b', 2, 66, 10, 16, 3, 0, 2, 8, 7, 16, 1, 1, 86, 103);
INSERT INTO public."BattingStats" ("PlayerId", "StatsType", "AtBats", "Runs", "Hits", "Doubles", "Triples", "HomeRuns", "RunsBattedIn", "BaseOnBalls", "StrikeOuts", "StolenBases", "CaughtStealing", "Power", "Speed") VALUES ('8a03b582-c34a-4f16-afa5-6f3447a4b47a', 1, 297, 39, 76, 13, 4, 5, 30, 25, 94, 1, 4, 87, 149);
INSERT INTO public."BattingStats" ("PlayerId", "StatsType", "AtBats", "Runs", "Hits", "Doubles", "Triples", "HomeRuns", "RunsBattedIn", "BaseOnBalls", "StrikeOuts", "StolenBases", "CaughtStealing", "Power", "Speed") VALUES ('e2f3a018-6216-43fa-a24c-96d5f6f61685', 1, 480, 76, 133, 23, 3, 25, 71, 39, 138, 24, 7, 140, 163);
INSERT INTO public."BattingStats" ("PlayerId", "StatsType", "AtBats", "Runs", "Hits", "Doubles", "Triples", "HomeRuns", "RunsBattedIn", "BaseOnBalls", "StrikeOuts", "StolenBases", "CaughtStealing", "Power", "Speed") VALUES ('e8774047-7ff9-43e7-b709-f7f66cb4def9', 1, 551, 91, 156, 30, 1, 19, 82, 45, 159, 17, 7, 112, 116);
INSERT INTO public."BattingStats" ("PlayerId", "StatsType", "AtBats", "Runs", "Hits", "Doubles", "Triples", "HomeRuns", "RunsBattedIn", "BaseOnBalls", "StrikeOuts", "StolenBases", "CaughtStealing", "Power", "Speed") VALUES ('e8774047-7ff9-43e7-b709-f7f66cb4def9', 2, 70, 11, 16, 4, 0, 2, 10, 6, 20, 2, 1, 103, 106);
INSERT INTO public."BattingStats" ("PlayerId", "StatsType", "AtBats", "Runs", "Hits", "Doubles", "Triples", "HomeRuns", "RunsBattedIn", "BaseOnBalls", "StrikeOuts", "StolenBases", "CaughtStealing", "Power", "Speed") VALUES ('e9137344-a90c-4d35-be6f-cd3f435542eb', 1, 238, 36, 63, 14, 2, 5, 26, 17, 27, 5, 0, 80, 104);
INSERT INTO public."BattingStats" ("PlayerId", "StatsType", "AtBats", "Runs", "Hits", "Doubles", "Triples", "HomeRuns", "RunsBattedIn", "BaseOnBalls", "StrikeOuts", "StolenBases", "CaughtStealing", "Power", "Speed") VALUES ('e9137344-a90c-4d35-be6f-cd3f435542eb', 2, 63, 10, 19, 4, 1, 2, 9, 5, 8, 1, 1, 95, 115);
INSERT INTO public."BattingStats" ("PlayerId", "StatsType", "AtBats", "Runs", "Hits", "Doubles", "Triples", "HomeRuns", "RunsBattedIn", "BaseOnBalls", "StrikeOuts", "StolenBases", "CaughtStealing", "Power", "Speed") VALUES ('82a7ac73-8279-481f-b41e-49b0b9901250', 2, 57, 8, 14, 3, 0, 3, 8, 7, 14, 1, 1, 109, 88);
INSERT INTO public."BattingStats" ("PlayerId", "StatsType", "AtBats", "Runs", "Hits", "Doubles", "Triples", "HomeRuns", "RunsBattedIn", "BaseOnBalls", "StrikeOuts", "StolenBases", "CaughtStealing", "Power", "Speed") VALUES ('8a03b582-c34a-4f16-afa5-6f3447a4b47a', 2, 58, 8, 15, 3, 1, 2, 8, 6, 19, 1, 0, 109, 130);
INSERT INTO public."BattingStats" ("PlayerId", "StatsType", "AtBats", "Runs", "Hits", "Doubles", "Triples", "HomeRuns", "RunsBattedIn", "BaseOnBalls", "StrikeOuts", "StolenBases", "CaughtStealing", "Power", "Speed") VALUES ('e2f3a018-6216-43fa-a24c-96d5f6f61685', 2, 63, 10, 16, 3, 0, 3, 9, 5, 18, 3, 1, 113, 128);
INSERT INTO public."BattingStats" ("PlayerId", "StatsType", "AtBats", "Runs", "Hits", "Doubles", "Triples", "HomeRuns", "RunsBattedIn", "BaseOnBalls", "StrikeOuts", "StolenBases", "CaughtStealing", "Power", "Speed") VALUES ('ef0b95a8-da60-4c25-926d-cf60476821b0', 1, 490, 74, 117, 21, 1, 32, 79, 66, 104, 1, 2, 138, 89);
INSERT INTO public."BattingStats" ("PlayerId", "StatsType", "AtBats", "Runs", "Hits", "Doubles", "Triples", "HomeRuns", "RunsBattedIn", "BaseOnBalls", "StrikeOuts", "StolenBases", "CaughtStealing", "Power", "Speed") VALUES ('ef0b95a8-da60-4c25-926d-cf60476821b0', 2, 60, 9, 16, 3, 0, 4, 10, 8, 13, 0, 0, 132, 88);
INSERT INTO public."BattingStats" ("PlayerId", "StatsType", "AtBats", "Runs", "Hits", "Doubles", "Triples", "HomeRuns", "RunsBattedIn", "BaseOnBalls", "StrikeOuts", "StolenBases", "CaughtStealing", "Power", "Speed") VALUES ('f39e1057-9003-4ea5-9360-94c12b1cec69', 1, 251, 39, 64, 13, 2, 8, 32, 27, 75, 11, 1, 113, 99);
INSERT INTO public."BattingStats" ("PlayerId", "StatsType", "AtBats", "Runs", "Hits", "Doubles", "Triples", "HomeRuns", "RunsBattedIn", "BaseOnBalls", "StrikeOuts", "StolenBases", "CaughtStealing", "Power", "Speed") VALUES ('f39e1057-9003-4ea5-9360-94c12b1cec69', 2, 14, 2, 3, 1, 0, 0, 2, 2, 4, 1, 0, 105, 95);
INSERT INTO public."BattingStats" ("PlayerId", "StatsType", "AtBats", "Runs", "Hits", "Doubles", "Triples", "HomeRuns", "RunsBattedIn", "BaseOnBalls", "StrikeOuts", "StolenBases", "CaughtStealing", "Power", "Speed") VALUES ('18fa5de6-e188-45f4-be68-f95140061639', 1, 4, 0, 1, 0, 0, 0, 0, 1, 1, 0, 0, 0, 117);
INSERT INTO public."BattingStats" ("PlayerId", "StatsType", "AtBats", "Runs", "Hits", "Doubles", "Triples", "HomeRuns", "RunsBattedIn", "BaseOnBalls", "StrikeOuts", "StolenBases", "CaughtStealing", "Power", "Speed") VALUES ('2399dd10-b652-4796-8248-80b3975a936a', 1, 106, 21, 34, 5, 0, 5, 16, 7, 24, 5, 1, 115, 124);
INSERT INTO public."BattingStats" ("PlayerId", "StatsType", "AtBats", "Runs", "Hits", "Doubles", "Triples", "HomeRuns", "RunsBattedIn", "BaseOnBalls", "StrikeOuts", "StolenBases", "CaughtStealing", "Power", "Speed") VALUES ('2399dd10-b652-4796-8248-80b3975a936a', 2, 34, 5, 9, 1, 0, 1, 4, 2, 7, 1, 0, 66, 129);
INSERT INTO public."BattingStats" ("PlayerId", "StatsType", "AtBats", "Runs", "Hits", "Doubles", "Triples", "HomeRuns", "RunsBattedIn", "BaseOnBalls", "StrikeOuts", "StolenBases", "CaughtStealing", "Power", "Speed") VALUES ('9f0384ee-02a9-43b7-88dc-4d9c7f530dda', 1, 467, 73, 110, 26, 1, 24, 66, 55, 147, 2, 2, 148, 97);
INSERT INTO public."BattingStats" ("PlayerId", "StatsType", "AtBats", "Runs", "Hits", "Doubles", "Triples", "HomeRuns", "RunsBattedIn", "BaseOnBalls", "StrikeOuts", "StolenBases", "CaughtStealing", "Power", "Speed") VALUES ('d017942e-c5f9-49bf-9fb7-dbd129dedcab', 1, 29, 4, 4, 1, 0, 1, 6, 4, 15, 3, 0, 135, 104);
INSERT INTO public."BattingStats" ("PlayerId", "StatsType", "AtBats", "Runs", "Hits", "Doubles", "Triples", "HomeRuns", "RunsBattedIn", "BaseOnBalls", "StrikeOuts", "StolenBases", "CaughtStealing", "Power", "Speed") VALUES ('d017942e-c5f9-49bf-9fb7-dbd129dedcab', 2, 40, 4, 6, 1, 0, 1, 3, 4, 15, 1, 1, 44, 108);
INSERT INTO public."BattingStats" ("PlayerId", "StatsType", "AtBats", "Runs", "Hits", "Doubles", "Triples", "HomeRuns", "RunsBattedIn", "BaseOnBalls", "StrikeOuts", "StolenBases", "CaughtStealing", "Power", "Speed") VALUES ('ed798f1a-0241-4b94-98a7-876fe949ee91', 1, 503, 84, 108, 20, 2, 37, 79, 69, 179, 6, 1, 183, 72);
INSERT INTO public."BattingStats" ("PlayerId", "StatsType", "AtBats", "Runs", "Hits", "Doubles", "Triples", "HomeRuns", "RunsBattedIn", "BaseOnBalls", "StrikeOuts", "StolenBases", "CaughtStealing", "Power", "Speed") VALUES ('ed798f1a-0241-4b94-98a7-876fe949ee91', 2, 67, 11, 16, 3, 0, 5, 10, 9, 23, 1, 0, 187, 77);
INSERT INTO public."BattingStats" ("PlayerId", "StatsType", "AtBats", "Runs", "Hits", "Doubles", "Triples", "HomeRuns", "RunsBattedIn", "BaseOnBalls", "StrikeOuts", "StolenBases", "CaughtStealing", "Power", "Speed") VALUES ('f44be3eb-2a2b-476d-ac6f-27244bc47978', 1, 233, 23, 47, 8, 0, 9, 30, 27, 57, 0, 0, 92, 66);
INSERT INTO public."BattingStats" ("PlayerId", "StatsType", "AtBats", "Runs", "Hits", "Doubles", "Triples", "HomeRuns", "RunsBattedIn", "BaseOnBalls", "StrikeOuts", "StolenBases", "CaughtStealing", "Power", "Speed") VALUES ('f44be3eb-2a2b-476d-ac6f-27244bc47978', 2, 36, 4, 9, 2, 0, 1, 5, 4, 9, 0, 0, 87, 88);


--
-- TOC entry 3352 (class 0 OID 16388)
-- Dependencies: 210
-- Data for Name: LeagueStatuses; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public."LeagueStatuses" ("PlayerId", "LeagueId", "LeagueStatus") VALUES ('0ae9f4c0-1349-481b-9bd0-a649ba6615dc', 2, 1);
INSERT INTO public."LeagueStatuses" ("PlayerId", "LeagueId", "LeagueStatus") VALUES ('a07eb266-0b30-43c6-b53c-7b0e8a2bb883', 2, 1);
INSERT INTO public."LeagueStatuses" ("PlayerId", "LeagueId", "LeagueStatus") VALUES ('341681b1-c99b-4c2b-90f7-9b1af902ddc2', 1, 1);
INSERT INTO public."LeagueStatuses" ("PlayerId", "LeagueId", "LeagueStatus") VALUES ('379e76bb-af9c-490f-b8d1-73a0f3cdb9f8', 2, 2);
INSERT INTO public."LeagueStatuses" ("PlayerId", "LeagueId", "LeagueStatus") VALUES ('379f2dec-88b0-46c4-961e-40e5df7ba20f', 1, 1);
INSERT INTO public."LeagueStatuses" ("PlayerId", "LeagueId", "LeagueStatus") VALUES ('5801e077-cc58-43e9-ad4a-f9802fee7369', 2, 1);
INSERT INTO public."LeagueStatuses" ("PlayerId", "LeagueId", "LeagueStatus") VALUES ('7b7017f3-7de6-4348-b4a9-81286367d15c', 1, 1);
INSERT INTO public."LeagueStatuses" ("PlayerId", "LeagueId", "LeagueStatus") VALUES ('d1df308b-1ea9-4419-8729-d2cac3753e6b', 2, 1);
INSERT INTO public."LeagueStatuses" ("PlayerId", "LeagueId", "LeagueStatus") VALUES ('e9137344-a90c-4d35-be6f-cd3f435542eb', 1, 1);
INSERT INTO public."LeagueStatuses" ("PlayerId", "LeagueId", "LeagueStatus") VALUES ('e9137344-a90c-4d35-be6f-cd3f435542eb', 2, 2);
INSERT INTO public."LeagueStatuses" ("PlayerId", "LeagueId", "LeagueStatus") VALUES ('e7d67172-ee82-4a30-9bb1-ff3d51285cf6', 2, 2);
INSERT INTO public."LeagueStatuses" ("PlayerId", "LeagueId", "LeagueStatus") VALUES ('379f2dec-88b0-46c4-961e-40e5df7ba20f', 2, 2);
INSERT INTO public."LeagueStatuses" ("PlayerId", "LeagueId", "LeagueStatus") VALUES ('17c04c57-e2a3-4265-b4e7-173c97bbb1cd', 1, 2);
INSERT INTO public."LeagueStatuses" ("PlayerId", "LeagueId", "LeagueStatus") VALUES ('1fe5d5b4-e833-4828-ac28-4bd253c78aa0', 1, 2);
INSERT INTO public."LeagueStatuses" ("PlayerId", "LeagueId", "LeagueStatus") VALUES ('5801e077-cc58-43e9-ad4a-f9802fee7369', 1, 2);
INSERT INTO public."LeagueStatuses" ("PlayerId", "LeagueId", "LeagueStatus") VALUES ('d1df308b-1ea9-4419-8729-d2cac3753e6b', 1, 2);
INSERT INTO public."LeagueStatuses" ("PlayerId", "LeagueId", "LeagueStatus") VALUES ('ed798f1a-0241-4b94-98a7-876fe949ee91', 1, 2);
INSERT INTO public."LeagueStatuses" ("PlayerId", "LeagueId", "LeagueStatus") VALUES ('50e93fc7-68d6-4523-875f-0bb344cb91e5', 1, 2);
INSERT INTO public."LeagueStatuses" ("PlayerId", "LeagueId", "LeagueStatus") VALUES ('9876ba8d-d95d-44de-9460-1f4f0c3b09d1', 1, 2);
INSERT INTO public."LeagueStatuses" ("PlayerId", "LeagueId", "LeagueStatus") VALUES ('c6ba6850-6017-4ab3-9090-81b83d046c5a', 1, 2);
INSERT INTO public."LeagueStatuses" ("PlayerId", "LeagueId", "LeagueStatus") VALUES ('50e93fc7-68d6-4523-875f-0bb344cb91e5', 2, 2);
INSERT INTO public."LeagueStatuses" ("PlayerId", "LeagueId", "LeagueStatus") VALUES ('17c04c57-e2a3-4265-b4e7-173c97bbb1cd', 2, 1);
INSERT INTO public."LeagueStatuses" ("PlayerId", "LeagueId", "LeagueStatus") VALUES ('341681b1-c99b-4c2b-90f7-9b1af902ddc2', 2, 2);
INSERT INTO public."LeagueStatuses" ("PlayerId", "LeagueId", "LeagueStatus") VALUES ('9876ba8d-d95d-44de-9460-1f4f0c3b09d1', 2, 2);
INSERT INTO public."LeagueStatuses" ("PlayerId", "LeagueId", "LeagueStatus") VALUES ('c6ba6850-6017-4ab3-9090-81b83d046c5a', 2, 1);
INSERT INTO public."LeagueStatuses" ("PlayerId", "LeagueId", "LeagueStatus") VALUES ('47b9f5a7-811a-4a16-9385-f575de5d4389', 2, 1);
INSERT INTO public."LeagueStatuses" ("PlayerId", "LeagueId", "LeagueStatus") VALUES ('1a2b372b-44b2-4989-8af0-6499a2659c87', 2, 2);
INSERT INTO public."LeagueStatuses" ("PlayerId", "LeagueId", "LeagueStatus") VALUES ('f2915b39-76e3-47d8-8dc3-44ce0ff4b793', 2, 1);
INSERT INTO public."LeagueStatuses" ("PlayerId", "LeagueId", "LeagueStatus") VALUES ('7b7017f3-7de6-4348-b4a9-81286367d15c', 2, 2);
INSERT INTO public."LeagueStatuses" ("PlayerId", "LeagueId", "LeagueStatus") VALUES ('bd9c9d88-4fe4-492a-b70a-f60982b8216d', 2, 1);
INSERT INTO public."LeagueStatuses" ("PlayerId", "LeagueId", "LeagueStatus") VALUES ('ed798f1a-0241-4b94-98a7-876fe949ee91', 2, 1);
INSERT INTO public."LeagueStatuses" ("PlayerId", "LeagueId", "LeagueStatus") VALUES ('c378cd4e-d49d-44fb-8b63-adb7abc1ff64', 2, 1);
INSERT INTO public."LeagueStatuses" ("PlayerId", "LeagueId", "LeagueStatus") VALUES ('a54864b7-9923-44aa-8627-3acb70462246', 2, 1);
INSERT INTO public."LeagueStatuses" ("PlayerId", "LeagueId", "LeagueStatus") VALUES ('e8774047-7ff9-43e7-b709-f7f66cb4def9', 2, 2);
INSERT INTO public."LeagueStatuses" ("PlayerId", "LeagueId", "LeagueStatus") VALUES ('f774ff89-a188-4adb-a2ab-38186a60a609', 2, 2);
INSERT INTO public."LeagueStatuses" ("PlayerId", "LeagueId", "LeagueStatus") VALUES ('9f0384ee-02a9-43b7-88dc-4d9c7f530dda', 2, 1);
INSERT INTO public."LeagueStatuses" ("PlayerId", "LeagueId", "LeagueStatus") VALUES ('23889720-3073-4c37-a7dd-63fdb633498b', 2, 2);
INSERT INTO public."LeagueStatuses" ("PlayerId", "LeagueId", "LeagueStatus") VALUES ('1e6f7190-9b05-4abe-b88d-e4624f4b555d', 2, 1);
INSERT INTO public."LeagueStatuses" ("PlayerId", "LeagueId", "LeagueStatus") VALUES ('4cc4cef2-30b0-425b-91a1-799d9a4c812f', 2, 2);
INSERT INTO public."LeagueStatuses" ("PlayerId", "LeagueId", "LeagueStatus") VALUES ('dff2cb50-a73b-40df-bdc0-f229299769de', 2, 2);
INSERT INTO public."LeagueStatuses" ("PlayerId", "LeagueId", "LeagueStatus") VALUES ('c4608bbb-dc81-4891-9775-78946407d39c', 2, 2);
INSERT INTO public."LeagueStatuses" ("PlayerId", "LeagueId", "LeagueStatus") VALUES ('8d89ac4c-28ef-48bb-b6f4-b4bd7ae55022', 2, 1);
INSERT INTO public."LeagueStatuses" ("PlayerId", "LeagueId", "LeagueStatus") VALUES ('61712e5d-41a6-4df7-8394-f4c71ba0f401', 1, 1);
INSERT INTO public."LeagueStatuses" ("PlayerId", "LeagueId", "LeagueStatus") VALUES ('48b7aa93-3463-4fc2-b9b1-0311e5c60277', 2, 2);
INSERT INTO public."LeagueStatuses" ("PlayerId", "LeagueId", "LeagueStatus") VALUES ('61712e5d-41a6-4df7-8394-f4c71ba0f401', 2, 2);
INSERT INTO public."LeagueStatuses" ("PlayerId", "LeagueId", "LeagueStatus") VALUES ('ef0b95a8-da60-4c25-926d-cf60476821b0', 2, 2);
INSERT INTO public."LeagueStatuses" ("PlayerId", "LeagueId", "LeagueStatus") VALUES ('b1f37406-2a67-4b8c-91c1-75a50a6f763d', 2, 1);
INSERT INTO public."LeagueStatuses" ("PlayerId", "LeagueId", "LeagueStatus") VALUES ('ca82ac78-e3c3-4051-a15b-a70ef623d6c3', 2, 1);
INSERT INTO public."LeagueStatuses" ("PlayerId", "LeagueId", "LeagueStatus") VALUES ('7198c9e4-12ef-4035-b539-7ee9ad8b3345', 1, 1);
INSERT INTO public."LeagueStatuses" ("PlayerId", "LeagueId", "LeagueStatus") VALUES ('b55cf6a3-77fc-4689-bae8-694d34055070', 2, 1);
INSERT INTO public."LeagueStatuses" ("PlayerId", "LeagueId", "LeagueStatus") VALUES ('17331001-9ba0-478d-ae5d-141f64d84196', 2, 2);
INSERT INTO public."LeagueStatuses" ("PlayerId", "LeagueId", "LeagueStatus") VALUES ('e2f3a018-6216-43fa-a24c-96d5f6f61685', 2, 1);
INSERT INTO public."LeagueStatuses" ("PlayerId", "LeagueId", "LeagueStatus") VALUES ('b690f262-e87a-4038-add9-6d64af2ada29', 2, 1);
INSERT INTO public."LeagueStatuses" ("PlayerId", "LeagueId", "LeagueStatus") VALUES ('8a03b582-c34a-4f16-afa5-6f3447a4b47a', 2, 2);
INSERT INTO public."LeagueStatuses" ("PlayerId", "LeagueId", "LeagueStatus") VALUES ('111adb78-e25e-45ef-ab8f-67389b691964', 1, 1);
INSERT INTO public."LeagueStatuses" ("PlayerId", "LeagueId", "LeagueStatus") VALUES ('bf019d49-25bd-4885-9d2b-55ee958fe547', 2, 2);
INSERT INTO public."LeagueStatuses" ("PlayerId", "LeagueId", "LeagueStatus") VALUES ('47b9f5a7-811a-4a16-9385-f575de5d4389', 1, 2);
INSERT INTO public."LeagueStatuses" ("PlayerId", "LeagueId", "LeagueStatus") VALUES ('e2f3a018-6216-43fa-a24c-96d5f6f61685', 1, 2);
INSERT INTO public."LeagueStatuses" ("PlayerId", "LeagueId", "LeagueStatus") VALUES ('f2915b39-76e3-47d8-8dc3-44ce0ff4b793', 1, 1);
INSERT INTO public."LeagueStatuses" ("PlayerId", "LeagueId", "LeagueStatus") VALUES ('1a2b372b-44b2-4989-8af0-6499a2659c87', 1, 1);
INSERT INTO public."LeagueStatuses" ("PlayerId", "LeagueId", "LeagueStatus") VALUES ('9f0384ee-02a9-43b7-88dc-4d9c7f530dda', 1, 2);
INSERT INTO public."LeagueStatuses" ("PlayerId", "LeagueId", "LeagueStatus") VALUES ('a54864b7-9923-44aa-8627-3acb70462246', 1, 2);
INSERT INTO public."LeagueStatuses" ("PlayerId", "LeagueId", "LeagueStatus") VALUES ('dff2cb50-a73b-40df-bdc0-f229299769de', 1, 2);
INSERT INTO public."LeagueStatuses" ("PlayerId", "LeagueId", "LeagueStatus") VALUES ('a07eb266-0b30-43c6-b53c-7b0e8a2bb883', 1, 2);
INSERT INTO public."LeagueStatuses" ("PlayerId", "LeagueId", "LeagueStatus") VALUES ('c378cd4e-d49d-44fb-8b63-adb7abc1ff64', 1, 1);
INSERT INTO public."LeagueStatuses" ("PlayerId", "LeagueId", "LeagueStatus") VALUES ('bd9c9d88-4fe4-492a-b70a-f60982b8216d', 1, 2);
INSERT INTO public."LeagueStatuses" ("PlayerId", "LeagueId", "LeagueStatus") VALUES ('e7d67172-ee82-4a30-9bb1-ff3d51285cf6', 1, 1);
INSERT INTO public."LeagueStatuses" ("PlayerId", "LeagueId", "LeagueStatus") VALUES ('379e76bb-af9c-490f-b8d1-73a0f3cdb9f8', 1, 2);
INSERT INTO public."LeagueStatuses" ("PlayerId", "LeagueId", "LeagueStatus") VALUES ('1e6f7190-9b05-4abe-b88d-e4624f4b555d', 1, 1);
INSERT INTO public."LeagueStatuses" ("PlayerId", "LeagueId", "LeagueStatus") VALUES ('faccb3da-4eca-413e-b119-930b7ae8f76e', 1, 1);
INSERT INTO public."LeagueStatuses" ("PlayerId", "LeagueId", "LeagueStatus") VALUES ('ef0b95a8-da60-4c25-926d-cf60476821b0', 1, 1);
INSERT INTO public."LeagueStatuses" ("PlayerId", "LeagueId", "LeagueStatus") VALUES ('096483e1-eaf6-4eb8-85b1-6492ff7db10d', 2, 1);
INSERT INTO public."LeagueStatuses" ("PlayerId", "LeagueId", "LeagueStatus") VALUES ('ca82ac78-e3c3-4051-a15b-a70ef623d6c3', 1, 2);
INSERT INTO public."LeagueStatuses" ("PlayerId", "LeagueId", "LeagueStatus") VALUES ('b1f37406-2a67-4b8c-91c1-75a50a6f763d', 1, 1);
INSERT INTO public."LeagueStatuses" ("PlayerId", "LeagueId", "LeagueStatus") VALUES ('ac2a670c-6da8-4252-99fd-7d952706a816', 1, 1);
INSERT INTO public."LeagueStatuses" ("PlayerId", "LeagueId", "LeagueStatus") VALUES ('29a2c849-3eca-4a32-a695-d42dfdc865cd', 1, 1);
INSERT INTO public."LeagueStatuses" ("PlayerId", "LeagueId", "LeagueStatus") VALUES ('8a03b582-c34a-4f16-afa5-6f3447a4b47a', 1, 1);
INSERT INTO public."LeagueStatuses" ("PlayerId", "LeagueId", "LeagueStatus") VALUES ('38e839cc-52b8-49e2-a677-51846d2dca95', 1, 1);
INSERT INTO public."LeagueStatuses" ("PlayerId", "LeagueId", "LeagueStatus") VALUES ('a7da4769-9b95-4317-8a35-251d4ec5fd20', 1, 1);
INSERT INTO public."LeagueStatuses" ("PlayerId", "LeagueId", "LeagueStatus") VALUES ('82a7ac73-8279-481f-b41e-49b0b9901250', 2, 2);
INSERT INTO public."LeagueStatuses" ("PlayerId", "LeagueId", "LeagueStatus") VALUES ('f774ff89-a188-4adb-a2ab-38186a60a609', 1, 1);
INSERT INTO public."LeagueStatuses" ("PlayerId", "LeagueId", "LeagueStatus") VALUES ('952984f5-7fb4-4a29-92a2-bd90a01c5cc3', 1, 2);
INSERT INTO public."LeagueStatuses" ("PlayerId", "LeagueId", "LeagueStatus") VALUES ('e0deb378-7f52-4742-a2f9-75ae12346db4', 2, 2);
INSERT INTO public."LeagueStatuses" ("PlayerId", "LeagueId", "LeagueStatus") VALUES ('2399dd10-b652-4796-8248-80b3975a936a', 1, 2);
INSERT INTO public."LeagueStatuses" ("PlayerId", "LeagueId", "LeagueStatus") VALUES ('0ae9f4c0-1349-481b-9bd0-a649ba6615dc', 1, 2);
INSERT INTO public."LeagueStatuses" ("PlayerId", "LeagueId", "LeagueStatus") VALUES ('23889720-3073-4c37-a7dd-63fdb633498b', 1, 2);
INSERT INTO public."LeagueStatuses" ("PlayerId", "LeagueId", "LeagueStatus") VALUES ('b55cf6a3-77fc-4689-bae8-694d34055070', 1, 2);
INSERT INTO public."LeagueStatuses" ("PlayerId", "LeagueId", "LeagueStatus") VALUES ('bf019d49-25bd-4885-9d2b-55ee958fe547', 1, 1);
INSERT INTO public."LeagueStatuses" ("PlayerId", "LeagueId", "LeagueStatus") VALUES ('4cc4cef2-30b0-425b-91a1-799d9a4c812f', 1, 1);
INSERT INTO public."LeagueStatuses" ("PlayerId", "LeagueId", "LeagueStatus") VALUES ('25f7a378-4ce3-41f1-86c0-5e631e47cd35', 1, 2);
INSERT INTO public."LeagueStatuses" ("PlayerId", "LeagueId", "LeagueStatus") VALUES ('643d1447-e90a-4677-898a-bd1d02bed609', 2, 2);
INSERT INTO public."LeagueStatuses" ("PlayerId", "LeagueId", "LeagueStatus") VALUES ('17331001-9ba0-478d-ae5d-141f64d84196', 1, 2);
INSERT INTO public."LeagueStatuses" ("PlayerId", "LeagueId", "LeagueStatus") VALUES ('25f7a378-4ce3-41f1-86c0-5e631e47cd35', 2, 1);
INSERT INTO public."LeagueStatuses" ("PlayerId", "LeagueId", "LeagueStatus") VALUES ('2399dd10-b652-4796-8248-80b3975a936a', 2, 1);
INSERT INTO public."LeagueStatuses" ("PlayerId", "LeagueId", "LeagueStatus") VALUES ('096483e1-eaf6-4eb8-85b1-6492ff7db10d', 1, 2);
INSERT INTO public."LeagueStatuses" ("PlayerId", "LeagueId", "LeagueStatus") VALUES ('1fe5d5b4-e833-4828-ac28-4bd253c78aa0', 2, 1);
INSERT INTO public."LeagueStatuses" ("PlayerId", "LeagueId", "LeagueStatus") VALUES ('081f3aa5-b16c-4e83-80d7-1b905c525a72', 2, 1);
INSERT INTO public."LeagueStatuses" ("PlayerId", "LeagueId", "LeagueStatus") VALUES ('23950b3c-eef2-4d71-ada6-fc67d88d53e3', 1, 2);
INSERT INTO public."LeagueStatuses" ("PlayerId", "LeagueId", "LeagueStatus") VALUES ('643d1447-e90a-4677-898a-bd1d02bed609', 1, 1);
INSERT INTO public."LeagueStatuses" ("PlayerId", "LeagueId", "LeagueStatus") VALUES ('35601382-71e5-41c5-ba1e-542441107a98', 2, 1);
INSERT INTO public."LeagueStatuses" ("PlayerId", "LeagueId", "LeagueStatus") VALUES ('35601382-71e5-41c5-ba1e-542441107a98', 1, 2);
INSERT INTO public."LeagueStatuses" ("PlayerId", "LeagueId", "LeagueStatus") VALUES ('7198c9e4-12ef-4035-b539-7ee9ad8b3345', 2, 2);
INSERT INTO public."LeagueStatuses" ("PlayerId", "LeagueId", "LeagueStatus") VALUES ('e8774047-7ff9-43e7-b709-f7f66cb4def9', 1, 1);
INSERT INTO public."LeagueStatuses" ("PlayerId", "LeagueId", "LeagueStatus") VALUES ('8d89ac4c-28ef-48bb-b6f4-b4bd7ae55022', 1, 2);
INSERT INTO public."LeagueStatuses" ("PlayerId", "LeagueId", "LeagueStatus") VALUES ('31ac324b-fed5-4aec-80ee-f14688e07919', 2, 2);


--
-- TOC entry 3353 (class 0 OID 16391)
-- Dependencies: 211
-- Data for Name: PitchingStats; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public."PitchingStats" ("PlayerId", "StatsType", "Wins", "Losses", "QualityStarts", "Saves", "BlownSaves", "Holds", "InningsPitched", "HitsAllowed", "EarnedRuns", "HomeRunsAllowed", "BaseOnBallsAllowed", "StrikeOuts", "FlyBallRate", "GroundBallRate") VALUES ('111adb78-e25e-45ef-ab8f-67389b691964', 1, 4, 3, 4, 0, 0, 0, 70.3, 47, 27, 5, 25, 76, 0.43, 0.41);
INSERT INTO public."PitchingStats" ("PlayerId", "StatsType", "Wins", "Losses", "QualityStarts", "Saves", "BlownSaves", "Holds", "InningsPitched", "HitsAllowed", "EarnedRuns", "HomeRunsAllowed", "BaseOnBallsAllowed", "StrikeOuts", "FlyBallRate", "GroundBallRate") VALUES ('38e839cc-52b8-49e2-a677-51846d2dca95', 3, 3, 3, 0, 3, 5, 22, 70.3, 67, 28, 9, 18, 72, 0.34691322901849214, 0.44345661450924606);
INSERT INTO public."PitchingStats" ("PlayerId", "StatsType", "Wins", "Losses", "QualityStarts", "Saves", "BlownSaves", "Holds", "InningsPitched", "HitsAllowed", "EarnedRuns", "HomeRunsAllowed", "BaseOnBallsAllowed", "StrikeOuts", "FlyBallRate", "GroundBallRate") VALUES ('f774ff89-a188-4adb-a2ab-38186a60a609', 3, 7, 10, 9, 0, 0, 0, 118, 106, 52, 11, 52, 159, 0.41745762711864404, 0.36254237288135593);
INSERT INTO public."PitchingStats" ("PlayerId", "StatsType", "Wins", "Losses", "QualityStarts", "Saves", "BlownSaves", "Holds", "InningsPitched", "HitsAllowed", "EarnedRuns", "HomeRunsAllowed", "BaseOnBallsAllowed", "StrikeOuts", "FlyBallRate", "GroundBallRate") VALUES ('111adb78-e25e-45ef-ab8f-67389b691964', 3, 4, 3, 4, 0, 0, 0, 79.3, 53, 30, 6, 28, 86, 0.4334047919293821, 0.4031904161412358);
INSERT INTO public."PitchingStats" ("PlayerId", "StatsType", "Wins", "Losses", "QualityStarts", "Saves", "BlownSaves", "Holds", "InningsPitched", "HitsAllowed", "EarnedRuns", "HomeRunsAllowed", "BaseOnBallsAllowed", "StrikeOuts", "FlyBallRate", "GroundBallRate") VALUES ('b55cf6a3-77fc-4689-bae8-694d34055070', 3, 11, 8, 11, 0, 0, 0, 150, 123, 61, 19, 43, 151, 0.4924, 0.32360000000000005);
INSERT INTO public."PitchingStats" ("PlayerId", "StatsType", "Wins", "Losses", "QualityStarts", "Saves", "BlownSaves", "Holds", "InningsPitched", "HitsAllowed", "EarnedRuns", "HomeRunsAllowed", "BaseOnBallsAllowed", "StrikeOuts", "FlyBallRate", "GroundBallRate") VALUES ('a07eb266-0b30-43c6-b53c-7b0e8a2bb883', 3, 15, 4, 20, 0, 0, 0, 182, 141, 57, 17, 43, 183, 0.31532967032967035, 0.47934065934065934);
INSERT INTO public."PitchingStats" ("PlayerId", "StatsType", "Wins", "Losses", "QualityStarts", "Saves", "BlownSaves", "Holds", "InningsPitched", "HitsAllowed", "EarnedRuns", "HomeRunsAllowed", "BaseOnBallsAllowed", "StrikeOuts", "FlyBallRate", "GroundBallRate") VALUES ('4cc4cef2-30b0-425b-91a1-799d9a4c812f', 3, 11, 12, 16, 0, 0, 0, 184.3, 132, 65, 26, 49, 178, 0.49, 0.31);
INSERT INTO public."PitchingStats" ("PlayerId", "StatsType", "Wins", "Losses", "QualityStarts", "Saves", "BlownSaves", "Holds", "InningsPitched", "HitsAllowed", "EarnedRuns", "HomeRunsAllowed", "BaseOnBallsAllowed", "StrikeOuts", "FlyBallRate", "GroundBallRate") VALUES ('0ae9f4c0-1349-481b-9bd0-a649ba6615dc', 1, 12, 9, 17, 0, 0, 0, 166.7, 138, 66, 26, 53, 189, 0.41, 0.4);
INSERT INTO public."PitchingStats" ("PlayerId", "StatsType", "Wins", "Losses", "QualityStarts", "Saves", "BlownSaves", "Holds", "InningsPitched", "HitsAllowed", "EarnedRuns", "HomeRunsAllowed", "BaseOnBallsAllowed", "StrikeOuts", "FlyBallRate", "GroundBallRate") VALUES ('61712e5d-41a6-4df7-8394-f4c71ba0f401', 3, 3, 3, 2, 8, 1, 6, 82.3, 68, 29, 9, 16, 81, 0.38307411907654926, 0.43692588092345075);
INSERT INTO public."PitchingStats" ("PlayerId", "StatsType", "Wins", "Losses", "QualityStarts", "Saves", "BlownSaves", "Holds", "InningsPitched", "HitsAllowed", "EarnedRuns", "HomeRunsAllowed", "BaseOnBallsAllowed", "StrikeOuts", "FlyBallRate", "GroundBallRate") VALUES ('62795f8a-bdf9-433c-86f0-ee63d2ba9fb6', 3, 3, 2, 2, 0, 0, 0, 63.7, 76, 35, 8, 25, 37, 0.2864835164835165, 0.5058712715855573);
INSERT INTO public."PitchingStats" ("PlayerId", "StatsType", "Wins", "Losses", "QualityStarts", "Saves", "BlownSaves", "Holds", "InningsPitched", "HitsAllowed", "EarnedRuns", "HomeRunsAllowed", "BaseOnBallsAllowed", "StrikeOuts", "FlyBallRate", "GroundBallRate") VALUES ('7198c9e4-12ef-4035-b539-7ee9ad8b3345', 3, 13, 9, 10, 0, 0, 0, 158.3, 134, 70, 23, 49, 163, 0.427094125078964, 0.37145293746051805);
INSERT INTO public."PitchingStats" ("PlayerId", "StatsType", "Wins", "Losses", "QualityStarts", "Saves", "BlownSaves", "Holds", "InningsPitched", "HitsAllowed", "EarnedRuns", "HomeRunsAllowed", "BaseOnBallsAllowed", "StrikeOuts", "FlyBallRate", "GroundBallRate") VALUES ('48b7aa93-3463-4fc2-b9b1-0311e5c60277', 3, 4, 12, 2, 1, 0, 1, 115.7, 111, 52, 13, 52, 142, 0.2630250648228176, 0.5721002592912706);
INSERT INTO public."PitchingStats" ("PlayerId", "StatsType", "Wins", "Losses", "QualityStarts", "Saves", "BlownSaves", "Holds", "InningsPitched", "HitsAllowed", "EarnedRuns", "HomeRunsAllowed", "BaseOnBallsAllowed", "StrikeOuts", "FlyBallRate", "GroundBallRate") VALUES ('faccb3da-4eca-413e-b119-930b7ae8f76e', 3, 3, 2, 0, 5, 4, 21, 71.3, 56, 24, 6, 20, 76, 0.34294530154277697, 0.45);
INSERT INTO public."PitchingStats" ("PlayerId", "StatsType", "Wins", "Losses", "QualityStarts", "Saves", "BlownSaves", "Holds", "InningsPitched", "HitsAllowed", "EarnedRuns", "HomeRunsAllowed", "BaseOnBallsAllowed", "StrikeOuts", "FlyBallRate", "GroundBallRate") VALUES ('e0deb378-7f52-4742-a2f9-75ae12346db4', 3, 10, 7, 13, 0, 0, 0, 155, 138, 68, 28, 56, 147, 0.44806451612903225, 0.33129032258064517);
INSERT INTO public."PitchingStats" ("PlayerId", "StatsType", "Wins", "Losses", "QualityStarts", "Saves", "BlownSaves", "Holds", "InningsPitched", "HitsAllowed", "EarnedRuns", "HomeRunsAllowed", "BaseOnBallsAllowed", "StrikeOuts", "FlyBallRate", "GroundBallRate") VALUES ('952984f5-7fb4-4a29-92a2-bd90a01c5cc3', 3, 3, 2, 0, 3, 8, 17, 60, 44, 21, 10, 17, 77, 0.4265, 0.3911666666666667);
INSERT INTO public."PitchingStats" ("PlayerId", "StatsType", "Wins", "Losses", "QualityStarts", "Saves", "BlownSaves", "Holds", "InningsPitched", "HitsAllowed", "EarnedRuns", "HomeRunsAllowed", "BaseOnBallsAllowed", "StrikeOuts", "FlyBallRate", "GroundBallRate") VALUES ('ca82ac78-e3c3-4051-a15b-a70ef623d6c3', 3, 2, 7, 0, 32, 9, 4, 63.3, 56, 29, 4, 13, 76, 0.3533649289099526, 0.42884676145339656);
INSERT INTO public."PitchingStats" ("PlayerId", "StatsType", "Wins", "Losses", "QualityStarts", "Saves", "BlownSaves", "Holds", "InningsPitched", "HitsAllowed", "EarnedRuns", "HomeRunsAllowed", "BaseOnBallsAllowed", "StrikeOuts", "FlyBallRate", "GroundBallRate") VALUES ('0ae9f4c0-1349-481b-9bd0-a649ba6615dc', 3, 12, 12, 14, 0, 0, 0, 183.7, 152, 80, 27, 66, 215, 0.4253892215568863, 0.36922155688622754);
INSERT INTO public."PitchingStats" ("PlayerId", "StatsType", "Wins", "Losses", "QualityStarts", "Saves", "BlownSaves", "Holds", "InningsPitched", "HitsAllowed", "EarnedRuns", "HomeRunsAllowed", "BaseOnBallsAllowed", "StrikeOuts", "FlyBallRate", "GroundBallRate") VALUES ('111adb78-e25e-45ef-ab8f-67389b691964', 2, 0, 0, 0, 0, 0, 0, 9, 6, 3, 1, 3, 10, 0.4600000000000001, 0.35);
INSERT INTO public."PitchingStats" ("PlayerId", "StatsType", "Wins", "Losses", "QualityStarts", "Saves", "BlownSaves", "Holds", "InningsPitched", "HitsAllowed", "EarnedRuns", "HomeRunsAllowed", "BaseOnBallsAllowed", "StrikeOuts", "FlyBallRate", "GroundBallRate") VALUES ('0ae9f4c0-1349-481b-9bd0-a649ba6615dc', 2, 2, 1, 2, 0, 0, 0, 20, 16, 8, 3, 7, 24, 0.42, 0.39);
INSERT INTO public."PitchingStats" ("PlayerId", "StatsType", "Wins", "Losses", "QualityStarts", "Saves", "BlownSaves", "Holds", "InningsPitched", "HitsAllowed", "EarnedRuns", "HomeRunsAllowed", "BaseOnBallsAllowed", "StrikeOuts", "FlyBallRate", "GroundBallRate") VALUES ('a0dcc1fb-0beb-4b1f-8f19-c6d7568b573d', 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0.31, 0.47);
INSERT INTO public."PitchingStats" ("PlayerId", "StatsType", "Wins", "Losses", "QualityStarts", "Saves", "BlownSaves", "Holds", "InningsPitched", "HitsAllowed", "EarnedRuns", "HomeRunsAllowed", "BaseOnBallsAllowed", "StrikeOuts", "FlyBallRate", "GroundBallRate") VALUES ('a0dcc1fb-0beb-4b1f-8f19-c6d7568b573d', 1, 0, 0, 0, 0, 0, 0, 2.3, 5, 6, 0, 5, 1, 0.1, 0.3);
INSERT INTO public."PitchingStats" ("PlayerId", "StatsType", "Wins", "Losses", "QualityStarts", "Saves", "BlownSaves", "Holds", "InningsPitched", "HitsAllowed", "EarnedRuns", "HomeRunsAllowed", "BaseOnBallsAllowed", "StrikeOuts", "FlyBallRate", "GroundBallRate") VALUES ('8d89ac4c-28ef-48bb-b6f4-b4bd7ae55022', 3, 2, 5, 0, 3, 2, 19, 64, 45, 21, 8, 18, 94, 0.3359375, 0.47515625);
INSERT INTO public."PitchingStats" ("PlayerId", "StatsType", "Wins", "Losses", "QualityStarts", "Saves", "BlownSaves", "Holds", "InningsPitched", "HitsAllowed", "EarnedRuns", "HomeRunsAllowed", "BaseOnBallsAllowed", "StrikeOuts", "FlyBallRate", "GroundBallRate") VALUES ('153215ee-f49a-4b7d-a910-72fa3a9d47cb', 2, 0, 0, 0, 0, 0, 1, 2, 2, 1, 0, 1, 2, 0.46, 0.37);
INSERT INTO public."PitchingStats" ("PlayerId", "StatsType", "Wins", "Losses", "QualityStarts", "Saves", "BlownSaves", "Holds", "InningsPitched", "HitsAllowed", "EarnedRuns", "HomeRunsAllowed", "BaseOnBallsAllowed", "StrikeOuts", "FlyBallRate", "GroundBallRate") VALUES ('61712e5d-41a6-4df7-8394-f4c71ba0f401', 1, 3, 2, 2, 6, 1, 4, 76.3, 63, 29, 9, 15, 80, 0.4, 0.41);
INSERT INTO public."PitchingStats" ("PlayerId", "StatsType", "Wins", "Losses", "QualityStarts", "Saves", "BlownSaves", "Holds", "InningsPitched", "HitsAllowed", "EarnedRuns", "HomeRunsAllowed", "BaseOnBallsAllowed", "StrikeOuts", "FlyBallRate", "GroundBallRate") VALUES ('341681b1-c99b-4c2b-90f7-9b1af902ddc2', 3, 10, 5, 15, 0, 0, 0, 138.7, 104, 36, 12, 26, 167, 0.5084138428262438, 0.2915861571737563);
INSERT INTO public."PitchingStats" ("PlayerId", "StatsType", "Wins", "Losses", "QualityStarts", "Saves", "BlownSaves", "Holds", "InningsPitched", "HitsAllowed", "EarnedRuns", "HomeRunsAllowed", "BaseOnBallsAllowed", "StrikeOuts", "FlyBallRate", "GroundBallRate") VALUES ('341681b1-c99b-4c2b-90f7-9b1af902ddc2', 1, 9, 4, 14, 0, 0, 0, 127.7, 95, 32, 10, 23, 153, 0.51, 0.29);
INSERT INTO public."PitchingStats" ("PlayerId", "StatsType", "Wins", "Losses", "QualityStarts", "Saves", "BlownSaves", "Holds", "InningsPitched", "HitsAllowed", "EarnedRuns", "HomeRunsAllowed", "BaseOnBallsAllowed", "StrikeOuts", "FlyBallRate", "GroundBallRate") VALUES ('48b7aa93-3463-4fc2-b9b1-0311e5c60277', 1, 2, 10, 3, 1, 0, 1, 96.3, 95, 49, 14, 43, 116, 0.27, 0.56);
INSERT INTO public."PitchingStats" ("PlayerId", "StatsType", "Wins", "Losses", "QualityStarts", "Saves", "BlownSaves", "Holds", "InningsPitched", "HitsAllowed", "EarnedRuns", "HomeRunsAllowed", "BaseOnBallsAllowed", "StrikeOuts", "FlyBallRate", "GroundBallRate") VALUES ('341681b1-c99b-4c2b-90f7-9b1af902ddc2', 2, 1, 1, 1, 0, 0, 0, 11, 9, 4, 2, 3, 14, 0.49, 0.31);
INSERT INTO public."PitchingStats" ("PlayerId", "StatsType", "Wins", "Losses", "QualityStarts", "Saves", "BlownSaves", "Holds", "InningsPitched", "HitsAllowed", "EarnedRuns", "HomeRunsAllowed", "BaseOnBallsAllowed", "StrikeOuts", "FlyBallRate", "GroundBallRate") VALUES ('35601382-71e5-41c5-ba1e-542441107a98', 2, 1, 1, 0, 4, 1, 0, 7, 6, 3, 1, 3, 6, 0.28, 0.54);
INSERT INTO public."PitchingStats" ("PlayerId", "StatsType", "Wins", "Losses", "QualityStarts", "Saves", "BlownSaves", "Holds", "InningsPitched", "HitsAllowed", "EarnedRuns", "HomeRunsAllowed", "BaseOnBallsAllowed", "StrikeOuts", "FlyBallRate", "GroundBallRate") VALUES ('36147a16-d7c4-48bb-b647-b8d59a5ec899', 2, 1, 2, 1, 0, 0, 0, 19, 18, 9, 2, 8, 14, 0.25, 0.53);
INSERT INTO public."PitchingStats" ("PlayerId", "StatsType", "Wins", "Losses", "QualityStarts", "Saves", "BlownSaves", "Holds", "InningsPitched", "HitsAllowed", "EarnedRuns", "HomeRunsAllowed", "BaseOnBallsAllowed", "StrikeOuts", "FlyBallRate", "GroundBallRate") VALUES ('38e839cc-52b8-49e2-a677-51846d2dca95', 1, 3, 2, 0, 3, 3, 16, 55.7, 51, 20, 6, 17, 56, 0.35, 0.46);
INSERT INTO public."PitchingStats" ("PlayerId", "StatsType", "Wins", "Losses", "QualityStarts", "Saves", "BlownSaves", "Holds", "InningsPitched", "HitsAllowed", "EarnedRuns", "HomeRunsAllowed", "BaseOnBallsAllowed", "StrikeOuts", "FlyBallRate", "GroundBallRate") VALUES ('38e839cc-52b8-49e2-a677-51846d2dca95', 2, 1, 0, 0, 0, 1, 3, 9, 8, 3, 1, 2, 9, 0.35, 0.45);
INSERT INTO public."PitchingStats" ("PlayerId", "StatsType", "Wins", "Losses", "QualityStarts", "Saves", "BlownSaves", "Holds", "InningsPitched", "HitsAllowed", "EarnedRuns", "HomeRunsAllowed", "BaseOnBallsAllowed", "StrikeOuts", "FlyBallRate", "GroundBallRate") VALUES ('392b9ad3-2e05-4496-965e-044013da057b', 2, 0, 0, 0, 0, 0, 0, 5, 6, 2, 1, 2, 4, 0.33, 0.48);
INSERT INTO public."PitchingStats" ("PlayerId", "StatsType", "Wins", "Losses", "QualityStarts", "Saves", "BlownSaves", "Holds", "InningsPitched", "HitsAllowed", "EarnedRuns", "HomeRunsAllowed", "BaseOnBallsAllowed", "StrikeOuts", "FlyBallRate", "GroundBallRate") VALUES ('39c2b781-d30c-4c4e-bb7a-42134a9b249a', 1, 3, 2, 0, 0, 1, 8, 56, 52, 23, 4, 13, 55, 0.29, 0.5);
INSERT INTO public."PitchingStats" ("PlayerId", "StatsType", "Wins", "Losses", "QualityStarts", "Saves", "BlownSaves", "Holds", "InningsPitched", "HitsAllowed", "EarnedRuns", "HomeRunsAllowed", "BaseOnBallsAllowed", "StrikeOuts", "FlyBallRate", "GroundBallRate") VALUES ('39c2b781-d30c-4c4e-bb7a-42134a9b249a', 2, 0, 0, 0, 0, 0, 2, 7, 6, 2, 1, 2, 7, 0.33, 0.47);
INSERT INTO public."PitchingStats" ("PlayerId", "StatsType", "Wins", "Losses", "QualityStarts", "Saves", "BlownSaves", "Holds", "InningsPitched", "HitsAllowed", "EarnedRuns", "HomeRunsAllowed", "BaseOnBallsAllowed", "StrikeOuts", "FlyBallRate", "GroundBallRate") VALUES ('d0fc0a0d-2d4d-4040-89dd-d67ed85a69e9', 1, 2, 1, 0, 0, 1, 0, 8, 8, 4, 1, 5, 13, 0.37, 0.53);
INSERT INTO public."PitchingStats" ("PlayerId", "StatsType", "Wins", "Losses", "QualityStarts", "Saves", "BlownSaves", "Holds", "InningsPitched", "HitsAllowed", "EarnedRuns", "HomeRunsAllowed", "BaseOnBallsAllowed", "StrikeOuts", "FlyBallRate", "GroundBallRate") VALUES ('48b7aa93-3463-4fc2-b9b1-0311e5c60277', 2, 1, 1, 0, 0, 0, 0, 7, 6, 3, 1, 3, 9, 0.27, 0.59);
INSERT INTO public."PitchingStats" ("PlayerId", "StatsType", "Wins", "Losses", "QualityStarts", "Saves", "BlownSaves", "Holds", "InningsPitched", "HitsAllowed", "EarnedRuns", "HomeRunsAllowed", "BaseOnBallsAllowed", "StrikeOuts", "FlyBallRate", "GroundBallRate") VALUES ('4b264e78-617a-477e-8d27-177c878fec9a', 1, 2, 1, 0, 0, 2, 2, 25, 23, 10, 2, 10, 29, 0.41, 0.27);
INSERT INTO public."PitchingStats" ("PlayerId", "StatsType", "Wins", "Losses", "QualityStarts", "Saves", "BlownSaves", "Holds", "InningsPitched", "HitsAllowed", "EarnedRuns", "HomeRunsAllowed", "BaseOnBallsAllowed", "StrikeOuts", "FlyBallRate", "GroundBallRate") VALUES ('4b264e78-617a-477e-8d27-177c878fec9a', 2, 0, 0, 0, 0, 0, 0, 3, 3, 2, 0, 1, 4, 0.37, 0.41);
INSERT INTO public."PitchingStats" ("PlayerId", "StatsType", "Wins", "Losses", "QualityStarts", "Saves", "BlownSaves", "Holds", "InningsPitched", "HitsAllowed", "EarnedRuns", "HomeRunsAllowed", "BaseOnBallsAllowed", "StrikeOuts", "FlyBallRate", "GroundBallRate") VALUES ('50e93fc7-68d6-4523-875f-0bb344cb91e5', 2, 1, 1, 2, 0, 0, 0, 21, 15, 7, 2, 6, 26, 0.35, 0.45);
INSERT INTO public."PitchingStats" ("PlayerId", "StatsType", "Wins", "Losses", "QualityStarts", "Saves", "BlownSaves", "Holds", "InningsPitched", "HitsAllowed", "EarnedRuns", "HomeRunsAllowed", "BaseOnBallsAllowed", "StrikeOuts", "FlyBallRate", "GroundBallRate") VALUES ('dff2cb50-a73b-40df-bdc0-f229299769de', 2, 1, 1, 0, 2, 0, 1, 7, 4, 2, 1, 3, 11, 0.34, 0.47);
INSERT INTO public."PitchingStats" ("PlayerId", "StatsType", "Wins", "Losses", "QualityStarts", "Saves", "BlownSaves", "Holds", "InningsPitched", "HitsAllowed", "EarnedRuns", "HomeRunsAllowed", "BaseOnBallsAllowed", "StrikeOuts", "FlyBallRate", "GroundBallRate") VALUES ('eb338553-881b-45df-b252-70b47040b42c', 1, 0, 0, 0, 0, 0, 0, 6.3, 8, 5, 1, 8, 7, 0.33, 0.33);
INSERT INTO public."PitchingStats" ("PlayerId", "StatsType", "Wins", "Losses", "QualityStarts", "Saves", "BlownSaves", "Holds", "InningsPitched", "HitsAllowed", "EarnedRuns", "HomeRunsAllowed", "BaseOnBallsAllowed", "StrikeOuts", "FlyBallRate", "GroundBallRate") VALUES ('50e93fc7-68d6-4523-875f-0bb344cb91e5', 1, 10, 6, 18, 0, 0, 0, 172, 122, 56, 20, 46, 214, 0.37, 0.44);
INSERT INTO public."PitchingStats" ("PlayerId", "StatsType", "Wins", "Losses", "QualityStarts", "Saves", "BlownSaves", "Holds", "InningsPitched", "HitsAllowed", "EarnedRuns", "HomeRunsAllowed", "BaseOnBallsAllowed", "StrikeOuts", "FlyBallRate", "GroundBallRate") VALUES ('23950b3c-eef2-4d71-ada6-fc67d88d53e3', 1, 3, 3, 0, 1, 7, 26, 52.3, 43, 17, 5, 26, 54, 0.45, 0.33);
INSERT INTO public."PitchingStats" ("PlayerId", "StatsType", "Wins", "Losses", "QualityStarts", "Saves", "BlownSaves", "Holds", "InningsPitched", "HitsAllowed", "EarnedRuns", "HomeRunsAllowed", "BaseOnBallsAllowed", "StrikeOuts", "FlyBallRate", "GroundBallRate") VALUES ('23950b3c-eef2-4d71-ada6-fc67d88d53e3', 2, 1, 1, 0, 0, 1, 2, 7, 6, 3, 1, 3, 8, 0.44, 0.36);
INSERT INTO public."PitchingStats" ("PlayerId", "StatsType", "Wins", "Losses", "QualityStarts", "Saves", "BlownSaves", "Holds", "InningsPitched", "HitsAllowed", "EarnedRuns", "HomeRunsAllowed", "BaseOnBallsAllowed", "StrikeOuts", "FlyBallRate", "GroundBallRate") VALUES ('61712e5d-41a6-4df7-8394-f4c71ba0f401', 2, 0, 0, 0, 2, 0, 2, 8, 7, 3, 1, 2, 8, 0.37, 0.43);
INSERT INTO public."PitchingStats" ("PlayerId", "StatsType", "Wins", "Losses", "QualityStarts", "Saves", "BlownSaves", "Holds", "InningsPitched", "HitsAllowed", "EarnedRuns", "HomeRunsAllowed", "BaseOnBallsAllowed", "StrikeOuts", "FlyBallRate", "GroundBallRate") VALUES ('62795f8a-bdf9-433c-86f0-ee63d2ba9fb6', 1, 2, 3, 1, 0, 0, 0, 68, 82, 40, 9, 27, 41, 0.27, 0.51);
INSERT INTO public."PitchingStats" ("PlayerId", "StatsType", "Wins", "Losses", "QualityStarts", "Saves", "BlownSaves", "Holds", "InningsPitched", "HitsAllowed", "EarnedRuns", "HomeRunsAllowed", "BaseOnBallsAllowed", "StrikeOuts", "FlyBallRate", "GroundBallRate") VALUES ('62795f8a-bdf9-433c-86f0-ee63d2ba9fb6', 2, 0, 0, 1, 0, 0, 0, 14, 14, 6, 1, 5, 11, 0.33, 0.46);
INSERT INTO public."PitchingStats" ("PlayerId", "StatsType", "Wins", "Losses", "QualityStarts", "Saves", "BlownSaves", "Holds", "InningsPitched", "HitsAllowed", "EarnedRuns", "HomeRunsAllowed", "BaseOnBallsAllowed", "StrikeOuts", "FlyBallRate", "GroundBallRate") VALUES ('36147a16-d7c4-48bb-b647-b8d59a5ec899', 1, 6, 9, 6, 0, 0, 0, 91.7, 91, 47, 8, 39, 65, 0.29, 0.48);
INSERT INTO public."PitchingStats" ("PlayerId", "StatsType", "Wins", "Losses", "QualityStarts", "Saves", "BlownSaves", "Holds", "InningsPitched", "HitsAllowed", "EarnedRuns", "HomeRunsAllowed", "BaseOnBallsAllowed", "StrikeOuts", "FlyBallRate", "GroundBallRate") VALUES ('6f353142-40d0-41df-ac78-2b437c7c2263', 2, 1, 1, 0, 0, 0, 1, 9, 8, 4, 1, 3, 8, 0.33, 0.45);
INSERT INTO public."PitchingStats" ("PlayerId", "StatsType", "Wins", "Losses", "QualityStarts", "Saves", "BlownSaves", "Holds", "InningsPitched", "HitsAllowed", "EarnedRuns", "HomeRunsAllowed", "BaseOnBallsAllowed", "StrikeOuts", "FlyBallRate", "GroundBallRate") VALUES ('64583442-204f-4f02-b223-a397cdf09d90', 1, 2, 0, 0, 0, 0, 2, 28, 25, 12, 4, 11, 27, 0.35, 0.5);
INSERT INTO public."PitchingStats" ("PlayerId", "StatsType", "Wins", "Losses", "QualityStarts", "Saves", "BlownSaves", "Holds", "InningsPitched", "HitsAllowed", "EarnedRuns", "HomeRunsAllowed", "BaseOnBallsAllowed", "StrikeOuts", "FlyBallRate", "GroundBallRate") VALUES ('64583442-204f-4f02-b223-a397cdf09d90', 2, 0, 0, 0, 0, 0, 0, 1, 1, 0, 0, 0, 1, 0.33, 0.45);
INSERT INTO public."PitchingStats" ("PlayerId", "StatsType", "Wins", "Losses", "QualityStarts", "Saves", "BlownSaves", "Holds", "InningsPitched", "HitsAllowed", "EarnedRuns", "HomeRunsAllowed", "BaseOnBallsAllowed", "StrikeOuts", "FlyBallRate", "GroundBallRate") VALUES ('0035735d-c42e-43da-8ae2-fbc476692203', 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0.35, 0.44);
INSERT INTO public."PitchingStats" ("PlayerId", "StatsType", "Wins", "Losses", "QualityStarts", "Saves", "BlownSaves", "Holds", "InningsPitched", "HitsAllowed", "EarnedRuns", "HomeRunsAllowed", "BaseOnBallsAllowed", "StrikeOuts", "FlyBallRate", "GroundBallRate") VALUES ('0035735d-c42e-43da-8ae2-fbc476692203', 1, 0, 0, 0, 0, 0, 0, 4, 7, 5, 2, 0, 3, 0.19, 0.5);
INSERT INTO public."PitchingStats" ("PlayerId", "StatsType", "Wins", "Losses", "QualityStarts", "Saves", "BlownSaves", "Holds", "InningsPitched", "HitsAllowed", "EarnedRuns", "HomeRunsAllowed", "BaseOnBallsAllowed", "StrikeOuts", "FlyBallRate", "GroundBallRate") VALUES ('153215ee-f49a-4b7d-a910-72fa3a9d47cb', 1, 2, 2, 0, 0, 3, 11, 38, 28, 17, 6, 10, 40, 0.41, 0.42);
INSERT INTO public."PitchingStats" ("PlayerId", "StatsType", "Wins", "Losses", "QualityStarts", "Saves", "BlownSaves", "Holds", "InningsPitched", "HitsAllowed", "EarnedRuns", "HomeRunsAllowed", "BaseOnBallsAllowed", "StrikeOuts", "FlyBallRate", "GroundBallRate") VALUES ('952984f5-7fb4-4a29-92a2-bd90a01c5cc3', 1, 2, 2, 0, 3, 7, 15, 53, 38, 19, 9, 15, 69, 0.43, 0.39);
INSERT INTO public."PitchingStats" ("PlayerId", "StatsType", "Wins", "Losses", "QualityStarts", "Saves", "BlownSaves", "Holds", "InningsPitched", "HitsAllowed", "EarnedRuns", "HomeRunsAllowed", "BaseOnBallsAllowed", "StrikeOuts", "FlyBallRate", "GroundBallRate") VALUES ('faccb3da-4eca-413e-b119-930b7ae8f76e', 2, 1, 1, 0, 2, 1, 1, 9, 8, 4, 1, 3, 9, 0.35, 0.45);
INSERT INTO public."PitchingStats" ("PlayerId", "StatsType", "Wins", "Losses", "QualityStarts", "Saves", "BlownSaves", "Holds", "InningsPitched", "HitsAllowed", "EarnedRuns", "HomeRunsAllowed", "BaseOnBallsAllowed", "StrikeOuts", "FlyBallRate", "GroundBallRate") VALUES ('25f7a378-4ce3-41f1-86c0-5e631e47cd35', 1, 4, 3, 0, 19, 7, 3, 56.7, 36, 15, 6, 28, 75, 0.42, 0.45);
INSERT INTO public."PitchingStats" ("PlayerId", "StatsType", "Wins", "Losses", "QualityStarts", "Saves", "BlownSaves", "Holds", "InningsPitched", "HitsAllowed", "EarnedRuns", "HomeRunsAllowed", "BaseOnBallsAllowed", "StrikeOuts", "FlyBallRate", "GroundBallRate") VALUES ('952984f5-7fb4-4a29-92a2-bd90a01c5cc3', 2, 1, 0, 0, 0, 1, 2, 7, 6, 2, 1, 2, 8, 0.4, 0.4);
INSERT INTO public."PitchingStats" ("PlayerId", "StatsType", "Wins", "Losses", "QualityStarts", "Saves", "BlownSaves", "Holds", "InningsPitched", "HitsAllowed", "EarnedRuns", "HomeRunsAllowed", "BaseOnBallsAllowed", "StrikeOuts", "FlyBallRate", "GroundBallRate") VALUES ('392b9ad3-2e05-4496-965e-044013da057b', 1, 1, 0, 0, 0, 0, 1, 15.7, 16, 6, 2, 2, 6, 0.16, 0.71);
INSERT INTO public."PitchingStats" ("PlayerId", "StatsType", "Wins", "Losses", "QualityStarts", "Saves", "BlownSaves", "Holds", "InningsPitched", "HitsAllowed", "EarnedRuns", "HomeRunsAllowed", "BaseOnBallsAllowed", "StrikeOuts", "FlyBallRate", "GroundBallRate") VALUES ('6f353142-40d0-41df-ac78-2b437c7c2263', 1, 5, 3, 0, 0, 0, 1, 58, 53, 26, 8, 20, 47, 0.36, 0.45);
INSERT INTO public."PitchingStats" ("PlayerId", "StatsType", "Wins", "Losses", "QualityStarts", "Saves", "BlownSaves", "Holds", "InningsPitched", "HitsAllowed", "EarnedRuns", "HomeRunsAllowed", "BaseOnBallsAllowed", "StrikeOuts", "FlyBallRate", "GroundBallRate") VALUES ('7198c9e4-12ef-4035-b539-7ee9ad8b3345', 1, 12, 8, 8, 0, 0, 0, 140.3, 122, 63, 22, 42, 143, 0.44, 0.37);
INSERT INTO public."PitchingStats" ("PlayerId", "StatsType", "Wins", "Losses", "QualityStarts", "Saves", "BlownSaves", "Holds", "InningsPitched", "HitsAllowed", "EarnedRuns", "HomeRunsAllowed", "BaseOnBallsAllowed", "StrikeOuts", "FlyBallRate", "GroundBallRate") VALUES ('9876ba8d-d95d-44de-9460-1f4f0c3b09d1', 2, 2, 1, 2, 0, 0, 0, 21, 18, 7, 2, 6, 24, 0.4, 0.39);
INSERT INTO public."PitchingStats" ("PlayerId", "StatsType", "Wins", "Losses", "QualityStarts", "Saves", "BlownSaves", "Holds", "InningsPitched", "HitsAllowed", "EarnedRuns", "HomeRunsAllowed", "BaseOnBallsAllowed", "StrikeOuts", "FlyBallRate", "GroundBallRate") VALUES ('b78b26fa-88c7-4f12-addb-585140bacde7', 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0.34, 0.41);
INSERT INTO public."PitchingStats" ("PlayerId", "StatsType", "Wins", "Losses", "QualityStarts", "Saves", "BlownSaves", "Holds", "InningsPitched", "HitsAllowed", "EarnedRuns", "HomeRunsAllowed", "BaseOnBallsAllowed", "StrikeOuts", "FlyBallRate", "GroundBallRate") VALUES ('a07eb266-0b30-43c6-b53c-7b0e8a2bb883', 1, 9, 7, 19, 0, 0, 0, 159, 139, 58, 21, 34, 157, 0.36, 0.45);
INSERT INTO public."PitchingStats" ("PlayerId", "StatsType", "Wins", "Losses", "QualityStarts", "Saves", "BlownSaves", "Holds", "InningsPitched", "HitsAllowed", "EarnedRuns", "HomeRunsAllowed", "BaseOnBallsAllowed", "StrikeOuts", "FlyBallRate", "GroundBallRate") VALUES ('a07eb266-0b30-43c6-b53c-7b0e8a2bb883', 2, 1, 1, 2, 0, 0, 0, 21, 18, 9, 2, 5, 22, 0.35, 0.45);
INSERT INTO public."PitchingStats" ("PlayerId", "StatsType", "Wins", "Losses", "QualityStarts", "Saves", "BlownSaves", "Holds", "InningsPitched", "HitsAllowed", "EarnedRuns", "HomeRunsAllowed", "BaseOnBallsAllowed", "StrikeOuts", "FlyBallRate", "GroundBallRate") VALUES ('7198c9e4-12ef-4035-b539-7ee9ad8b3345', 2, 1, 1, 1, 0, 0, 0, 15, 14, 6, 2, 5, 16, 0.42, 0.38);
INSERT INTO public."PitchingStats" ("PlayerId", "StatsType", "Wins", "Losses", "QualityStarts", "Saves", "BlownSaves", "Holds", "InningsPitched", "HitsAllowed", "EarnedRuns", "HomeRunsAllowed", "BaseOnBallsAllowed", "StrikeOuts", "FlyBallRate", "GroundBallRate") VALUES ('8d89ac4c-28ef-48bb-b6f4-b4bd7ae55022', 1, 2, 5, 0, 3, 3, 21, 57.7, 39, 17, 5, 15, 88, 0.33, 0.52);
INSERT INTO public."PitchingStats" ("PlayerId", "StatsType", "Wins", "Losses", "QualityStarts", "Saves", "BlownSaves", "Holds", "InningsPitched", "HitsAllowed", "EarnedRuns", "HomeRunsAllowed", "BaseOnBallsAllowed", "StrikeOuts", "FlyBallRate", "GroundBallRate") VALUES ('8d89ac4c-28ef-48bb-b6f4-b4bd7ae55022', 2, 0, 1, 0, 1, 0, 2, 8, 6, 3, 1, 3, 10, 0.34, 0.46);
INSERT INTO public."PitchingStats" ("PlayerId", "StatsType", "Wins", "Losses", "QualityStarts", "Saves", "BlownSaves", "Holds", "InningsPitched", "HitsAllowed", "EarnedRuns", "HomeRunsAllowed", "BaseOnBallsAllowed", "StrikeOuts", "FlyBallRate", "GroundBallRate") VALUES ('91ed9cb9-e41a-4214-85be-dc6f6cef224b', 1, 1, 0, 0, 0, 1, 2, 21, 22, 14, 7, 8, 21, 0.47, 0.33);
INSERT INTO public."PitchingStats" ("PlayerId", "StatsType", "Wins", "Losses", "QualityStarts", "Saves", "BlownSaves", "Holds", "InningsPitched", "HitsAllowed", "EarnedRuns", "HomeRunsAllowed", "BaseOnBallsAllowed", "StrikeOuts", "FlyBallRate", "GroundBallRate") VALUES ('91ed9cb9-e41a-4214-85be-dc6f6cef224b', 2, 0, 0, 0, 0, 0, 0, 5, 5, 2, 0, 2, 4, 0.38, 0.42);
INSERT INTO public."PitchingStats" ("PlayerId", "StatsType", "Wins", "Losses", "QualityStarts", "Saves", "BlownSaves", "Holds", "InningsPitched", "HitsAllowed", "EarnedRuns", "HomeRunsAllowed", "BaseOnBallsAllowed", "StrikeOuts", "FlyBallRate", "GroundBallRate") VALUES ('9876ba8d-d95d-44de-9460-1f4f0c3b09d1', 1, 10, 4, 11, 0, 0, 0, 127.3, 106, 48, 15, 37, 152, 0.44, 0.36);
INSERT INTO public."PitchingStats" ("PlayerId", "StatsType", "Wins", "Losses", "QualityStarts", "Saves", "BlownSaves", "Holds", "InningsPitched", "HitsAllowed", "EarnedRuns", "HomeRunsAllowed", "BaseOnBallsAllowed", "StrikeOuts", "FlyBallRate", "GroundBallRate") VALUES ('b78b26fa-88c7-4f12-addb-585140bacde7', 1, 1, 1, 0, 0, 0, 2, 13.3, 12, 6, 3, 8, 9, 0.27, 0.59);
INSERT INTO public."PitchingStats" ("PlayerId", "StatsType", "Wins", "Losses", "QualityStarts", "Saves", "BlownSaves", "Holds", "InningsPitched", "HitsAllowed", "EarnedRuns", "HomeRunsAllowed", "BaseOnBallsAllowed", "StrikeOuts", "FlyBallRate", "GroundBallRate") VALUES ('b55cf6a3-77fc-4689-bae8-694d34055070', 1, 10, 8, 8, 0, 0, 0, 122.3, 103, 55, 20, 39, 124, 0.54, 0.27);
INSERT INTO public."PitchingStats" ("PlayerId", "StatsType", "Wins", "Losses", "QualityStarts", "Saves", "BlownSaves", "Holds", "InningsPitched", "HitsAllowed", "EarnedRuns", "HomeRunsAllowed", "BaseOnBallsAllowed", "StrikeOuts", "FlyBallRate", "GroundBallRate") VALUES ('b55cf6a3-77fc-4689-bae8-694d34055070', 2, 1, 1, 1, 0, 0, 0, 20, 17, 9, 3, 5, 21, 0.49, 0.31);
INSERT INTO public."PitchingStats" ("PlayerId", "StatsType", "Wins", "Losses", "QualityStarts", "Saves", "BlownSaves", "Holds", "InningsPitched", "HitsAllowed", "EarnedRuns", "HomeRunsAllowed", "BaseOnBallsAllowed", "StrikeOuts", "FlyBallRate", "GroundBallRate") VALUES ('bd9c9d88-4fe4-492a-b70a-f60982b8216d', 1, 2, 4, 0, 33, 3, 0, 59.7, 34, 9, 2, 10, 61, 0.2, 0.65);
INSERT INTO public."PitchingStats" ("PlayerId", "StatsType", "Wins", "Losses", "QualityStarts", "Saves", "BlownSaves", "Holds", "InningsPitched", "HitsAllowed", "EarnedRuns", "HomeRunsAllowed", "BaseOnBallsAllowed", "StrikeOuts", "FlyBallRate", "GroundBallRate") VALUES ('bd9c9d88-4fe4-492a-b70a-f60982b8216d', 2, 1, 1, 0, 3, 1, 1, 8, 6, 2, 0, 1, 8, 0.19, 0.66);
INSERT INTO public."PitchingStats" ("PlayerId", "StatsType", "Wins", "Losses", "QualityStarts", "Saves", "BlownSaves", "Holds", "InningsPitched", "HitsAllowed", "EarnedRuns", "HomeRunsAllowed", "BaseOnBallsAllowed", "StrikeOuts", "FlyBallRate", "GroundBallRate") VALUES ('c378cd4e-d49d-44fb-8b63-adb7abc1ff64', 1, 3, 1, 0, 29, 3, 4, 54, 31, 9, 3, 17, 102, 0.32, 0.49);
INSERT INTO public."PitchingStats" ("PlayerId", "StatsType", "Wins", "Losses", "QualityStarts", "Saves", "BlownSaves", "Holds", "InningsPitched", "HitsAllowed", "EarnedRuns", "HomeRunsAllowed", "BaseOnBallsAllowed", "StrikeOuts", "FlyBallRate", "GroundBallRate") VALUES ('c378cd4e-d49d-44fb-8b63-adb7abc1ff64', 2, 1, 0, 0, 4, 1, 0, 8, 5, 2, 1, 3, 13, 0.38, 0.43);
INSERT INTO public."PitchingStats" ("PlayerId", "StatsType", "Wins", "Losses", "QualityStarts", "Saves", "BlownSaves", "Holds", "InningsPitched", "HitsAllowed", "EarnedRuns", "HomeRunsAllowed", "BaseOnBallsAllowed", "StrikeOuts", "FlyBallRate", "GroundBallRate") VALUES ('c6ba6850-6017-4ab3-9090-81b83d046c5a', 1, 10, 8, 21, 0, 0, 0, 173.3, 148, 56, 15, 35, 178, 0.32, 0.47);
INSERT INTO public."PitchingStats" ("PlayerId", "StatsType", "Wins", "Losses", "QualityStarts", "Saves", "BlownSaves", "Holds", "InningsPitched", "HitsAllowed", "EarnedRuns", "HomeRunsAllowed", "BaseOnBallsAllowed", "StrikeOuts", "FlyBallRate", "GroundBallRate") VALUES ('ca82ac78-e3c3-4051-a15b-a70ef623d6c3', 1, 3, 7, 0, 31, 8, 4, 57.7, 50, 29, 5, 13, 75, 0.36, 0.43);
INSERT INTO public."PitchingStats" ("PlayerId", "StatsType", "Wins", "Losses", "QualityStarts", "Saves", "BlownSaves", "Holds", "InningsPitched", "HitsAllowed", "EarnedRuns", "HomeRunsAllowed", "BaseOnBallsAllowed", "StrikeOuts", "FlyBallRate", "GroundBallRate") VALUES ('ca82ac78-e3c3-4051-a15b-a70ef623d6c3', 2, 1, 1, 0, 2, 1, 2, 7, 6, 2, 1, 2, 9, 0.33, 0.46);
INSERT INTO public."PitchingStats" ("PlayerId", "StatsType", "Wins", "Losses", "QualityStarts", "Saves", "BlownSaves", "Holds", "InningsPitched", "HitsAllowed", "EarnedRuns", "HomeRunsAllowed", "BaseOnBallsAllowed", "StrikeOuts", "FlyBallRate", "GroundBallRate") VALUES ('d0fc0a0d-2d4d-4040-89dd-d67ed85a69e9', 2, 0, 0, 0, 0, 0, 0, 1, 1, 0, 0, 0, 1, 0.38, 0.46);
INSERT INTO public."PitchingStats" ("PlayerId", "StatsType", "Wins", "Losses", "QualityStarts", "Saves", "BlownSaves", "Holds", "InningsPitched", "HitsAllowed", "EarnedRuns", "HomeRunsAllowed", "BaseOnBallsAllowed", "StrikeOuts", "FlyBallRate", "GroundBallRate") VALUES ('25f7a378-4ce3-41f1-86c0-5e631e47cd35', 2, 1, 1, 0, 2, 1, 1, 7, 5, 2, 1, 3, 9, 0.39, 0.46);
INSERT INTO public."PitchingStats" ("PlayerId", "StatsType", "Wins", "Losses", "QualityStarts", "Saves", "BlownSaves", "Holds", "InningsPitched", "HitsAllowed", "EarnedRuns", "HomeRunsAllowed", "BaseOnBallsAllowed", "StrikeOuts", "FlyBallRate", "GroundBallRate") VALUES ('9a4be7e0-e5a0-4281-99ff-4b498401d124', 2, 0, 0, 0, 0, 0, 0, 5, 4, 2, 1, 3, 7, 0.34, 0.43);
INSERT INTO public."PitchingStats" ("PlayerId", "StatsType", "Wins", "Losses", "QualityStarts", "Saves", "BlownSaves", "Holds", "InningsPitched", "HitsAllowed", "EarnedRuns", "HomeRunsAllowed", "BaseOnBallsAllowed", "StrikeOuts", "FlyBallRate", "GroundBallRate") VALUES ('c6ba6850-6017-4ab3-9090-81b83d046c5a', 2, 1, 1, 2, 0, 0, 0, 21, 18, 7, 2, 5, 23, 0.32, 0.47);
INSERT INTO public."PitchingStats" ("PlayerId", "StatsType", "Wins", "Losses", "QualityStarts", "Saves", "BlownSaves", "Holds", "InningsPitched", "HitsAllowed", "EarnedRuns", "HomeRunsAllowed", "BaseOnBallsAllowed", "StrikeOuts", "FlyBallRate", "GroundBallRate") VALUES ('e0deb378-7f52-4742-a2f9-75ae12346db4', 2, 0, 0, 1, 0, 0, 0, 10, 9, 5, 1, 4, 9, 0.42000000000000004, 0.35);
INSERT INTO public."PitchingStats" ("PlayerId", "StatsType", "Wins", "Losses", "QualityStarts", "Saves", "BlownSaves", "Holds", "InningsPitched", "HitsAllowed", "EarnedRuns", "HomeRunsAllowed", "BaseOnBallsAllowed", "StrikeOuts", "FlyBallRate", "GroundBallRate") VALUES ('dff2cb50-a73b-40df-bdc0-f229299769de', 1, 6, 3, 0, 12, 1, 25, 54.3, 28, 11, 2, 25, 82, 0.3, 0.49);
INSERT INTO public."PitchingStats" ("PlayerId", "StatsType", "Wins", "Losses", "QualityStarts", "Saves", "BlownSaves", "Holds", "InningsPitched", "HitsAllowed", "EarnedRuns", "HomeRunsAllowed", "BaseOnBallsAllowed", "StrikeOuts", "FlyBallRate", "GroundBallRate") VALUES ('e0deb378-7f52-4742-a2f9-75ae12346db4', 1, 10, 7, 12, 0, 0, 0, 145, 129, 63, 27, 52, 138, 0.45, 0.33);
INSERT INTO public."PitchingStats" ("PlayerId", "StatsType", "Wins", "Losses", "QualityStarts", "Saves", "BlownSaves", "Holds", "InningsPitched", "HitsAllowed", "EarnedRuns", "HomeRunsAllowed", "BaseOnBallsAllowed", "StrikeOuts", "FlyBallRate", "GroundBallRate") VALUES ('e7d67172-ee82-4a30-9bb1-ff3d51285cf6', 1, 5, 3, 0, 32, 4, 1, 54.3, 37, 12, 4, 17, 63, 0.39, 0.44);
INSERT INTO public."PitchingStats" ("PlayerId", "StatsType", "Wins", "Losses", "QualityStarts", "Saves", "BlownSaves", "Holds", "InningsPitched", "HitsAllowed", "EarnedRuns", "HomeRunsAllowed", "BaseOnBallsAllowed", "StrikeOuts", "FlyBallRate", "GroundBallRate") VALUES ('e7d67172-ee82-4a30-9bb1-ff3d51285cf6', 2, 1, 1, 0, 4, 0, 0, 9, 6, 3, 1, 3, 10, 0.4, 0.44);
INSERT INTO public."PitchingStats" ("PlayerId", "StatsType", "Wins", "Losses", "QualityStarts", "Saves", "BlownSaves", "Holds", "InningsPitched", "HitsAllowed", "EarnedRuns", "HomeRunsAllowed", "BaseOnBallsAllowed", "StrikeOuts", "FlyBallRate", "GroundBallRate") VALUES ('4cc4cef2-30b0-425b-91a1-799d9a4c812f', 2, 1, 1, 1, 0, 0, 0, 19, 14, 9, 3, 6, 19, 0.49000000000000005, 0.31);
INSERT INTO public."PitchingStats" ("PlayerId", "StatsType", "Wins", "Losses", "QualityStarts", "Saves", "BlownSaves", "Holds", "InningsPitched", "HitsAllowed", "EarnedRuns", "HomeRunsAllowed", "BaseOnBallsAllowed", "StrikeOuts", "FlyBallRate", "GroundBallRate") VALUES ('35601382-71e5-41c5-ba1e-542441107a98', 1, 4, 7, 0, 23, 6, 1, 62.7, 47, 16, 3, 26, 65, 0.26, 0.59);
INSERT INTO public."PitchingStats" ("PlayerId", "StatsType", "Wins", "Losses", "QualityStarts", "Saves", "BlownSaves", "Holds", "InningsPitched", "HitsAllowed", "EarnedRuns", "HomeRunsAllowed", "BaseOnBallsAllowed", "StrikeOuts", "FlyBallRate", "GroundBallRate") VALUES ('4cc4cef2-30b0-425b-91a1-799d9a4c812f', 1, 10, 11, 15, 0, 0, 0, 165.3, 118, 56, 23, 43, 159, 0.49, 0.31);
INSERT INTO public."PitchingStats" ("PlayerId", "StatsType", "Wins", "Losses", "QualityStarts", "Saves", "BlownSaves", "Holds", "InningsPitched", "HitsAllowed", "EarnedRuns", "HomeRunsAllowed", "BaseOnBallsAllowed", "StrikeOuts", "FlyBallRate", "GroundBallRate") VALUES ('eb338553-881b-45df-b252-70b47040b42c', 2, 0, 0, 0, 0, 0, 0, 3, 3, 1, 0, 2, 3, 0.36, 0.44);
INSERT INTO public."PitchingStats" ("PlayerId", "StatsType", "Wins", "Losses", "QualityStarts", "Saves", "BlownSaves", "Holds", "InningsPitched", "HitsAllowed", "EarnedRuns", "HomeRunsAllowed", "BaseOnBallsAllowed", "StrikeOuts", "FlyBallRate", "GroundBallRate") VALUES ('faccb3da-4eca-413e-b119-930b7ae8f76e', 1, 3, 2, 0, 4, 5, 17, 56.3, 45, 20, 5, 19, 65, 0.34, 0.44);
INSERT INTO public."PitchingStats" ("PlayerId", "StatsType", "Wins", "Losses", "QualityStarts", "Saves", "BlownSaves", "Holds", "InningsPitched", "HitsAllowed", "EarnedRuns", "HomeRunsAllowed", "BaseOnBallsAllowed", "StrikeOuts", "FlyBallRate", "GroundBallRate") VALUES ('f2915b39-76e3-47d8-8dc3-44ce0ff4b793', 1, 9, 11, 16, 0, 0, 0, 179.3, 150, 66, 17, 24, 202, 0.37, 0.43);
INSERT INTO public."PitchingStats" ("PlayerId", "StatsType", "Wins", "Losses", "QualityStarts", "Saves", "BlownSaves", "Holds", "InningsPitched", "HitsAllowed", "EarnedRuns", "HomeRunsAllowed", "BaseOnBallsAllowed", "StrikeOuts", "FlyBallRate", "GroundBallRate") VALUES ('f2915b39-76e3-47d8-8dc3-44ce0ff4b793', 2, 1, 1, 2, 0, 0, 0, 21, 18, 8, 2, 4, 24, 0.37, 0.43);
INSERT INTO public."PitchingStats" ("PlayerId", "StatsType", "Wins", "Losses", "QualityStarts", "Saves", "BlownSaves", "Holds", "InningsPitched", "HitsAllowed", "EarnedRuns", "HomeRunsAllowed", "BaseOnBallsAllowed", "StrikeOuts", "FlyBallRate", "GroundBallRate") VALUES ('f774ff89-a188-4adb-a2ab-38186a60a609', 1, 6, 9, 8, 0, 0, 0, 103, 93, 46, 9, 45, 139, 0.42, 0.36);
INSERT INTO public."PitchingStats" ("PlayerId", "StatsType", "Wins", "Losses", "QualityStarts", "Saves", "BlownSaves", "Holds", "InningsPitched", "HitsAllowed", "EarnedRuns", "HomeRunsAllowed", "BaseOnBallsAllowed", "StrikeOuts", "FlyBallRate", "GroundBallRate") VALUES ('f774ff89-a188-4adb-a2ab-38186a60a609', 2, 1, 1, 1, 0, 0, 0, 15, 13, 6, 2, 7, 20, 0.4, 0.38);


--
-- TOC entry 3354 (class 0 OID 16394)
-- Dependencies: 212
-- Data for Name: PlayerPositionEntity; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public."PlayerPositionEntity" ("PlayerId", "PositionCode") VALUES ('081f3aa5-b16c-4e83-80d7-1b905c525a72', '2B');
INSERT INTO public."PlayerPositionEntity" ("PlayerId", "PositionCode") VALUES ('081f3aa5-b16c-4e83-80d7-1b905c525a72', '3B');
INSERT INTO public."PlayerPositionEntity" ("PlayerId", "PositionCode") VALUES ('096483e1-eaf6-4eb8-85b1-6492ff7db10d', '2B');
INSERT INTO public."PlayerPositionEntity" ("PlayerId", "PositionCode") VALUES ('096483e1-eaf6-4eb8-85b1-6492ff7db10d', 'SS');
INSERT INTO public."PlayerPositionEntity" ("PlayerId", "PositionCode") VALUES ('0aa22cce-8c66-4b09-9b5d-7ac2db34bbe3', '1B');
INSERT INTO public."PlayerPositionEntity" ("PlayerId", "PositionCode") VALUES ('0aa22cce-8c66-4b09-9b5d-7ac2db34bbe3', '2B');
INSERT INTO public."PlayerPositionEntity" ("PlayerId", "PositionCode") VALUES ('0aa22cce-8c66-4b09-9b5d-7ac2db34bbe3', '3B');
INSERT INTO public."PlayerPositionEntity" ("PlayerId", "PositionCode") VALUES ('0ae9f4c0-1349-481b-9bd0-a649ba6615dc', 'SP');
INSERT INTO public."PlayerPositionEntity" ("PlayerId", "PositionCode") VALUES ('111adb78-e25e-45ef-ab8f-67389b691964', 'SP');
INSERT INTO public."PlayerPositionEntity" ("PlayerId", "PositionCode") VALUES ('17331001-9ba0-478d-ae5d-141f64d84196', '1B');
INSERT INTO public."PlayerPositionEntity" ("PlayerId", "PositionCode") VALUES ('17c04c57-e2a3-4265-b4e7-173c97bbb1cd', 'OF');
INSERT INTO public."PlayerPositionEntity" ("PlayerId", "PositionCode") VALUES ('19abc855-4ce0-40f7-8e58-8808a15f0462', 'C');
INSERT INTO public."PlayerPositionEntity" ("PlayerId", "PositionCode") VALUES ('1a2b372b-44b2-4989-8af0-6499a2659c87', 'OF');
INSERT INTO public."PlayerPositionEntity" ("PlayerId", "PositionCode") VALUES ('1b43560c-6ac5-4e77-9368-631a24e16e6f', 'OF');
INSERT INTO public."PlayerPositionEntity" ("PlayerId", "PositionCode") VALUES ('1e6f7190-9b05-4abe-b88d-e4624f4b555d', 'C');
INSERT INTO public."PlayerPositionEntity" ("PlayerId", "PositionCode") VALUES ('1e6f7190-9b05-4abe-b88d-e4624f4b555d', 'OF');
INSERT INTO public."PlayerPositionEntity" ("PlayerId", "PositionCode") VALUES ('1fe5d5b4-e833-4828-ac28-4bd253c78aa0', 'OF');
INSERT INTO public."PlayerPositionEntity" ("PlayerId", "PositionCode") VALUES ('23889720-3073-4c37-a7dd-63fdb633498b', 'OF');
INSERT INTO public."PlayerPositionEntity" ("PlayerId", "PositionCode") VALUES ('23950b3c-eef2-4d71-ada6-fc67d88d53e3', 'RP');
INSERT INTO public."PlayerPositionEntity" ("PlayerId", "PositionCode") VALUES ('25f7a378-4ce3-41f1-86c0-5e631e47cd35', 'RP');
INSERT INTO public."PlayerPositionEntity" ("PlayerId", "PositionCode") VALUES ('29a2c849-3eca-4a32-a695-d42dfdc865cd', '2B');
INSERT INTO public."PlayerPositionEntity" ("PlayerId", "PositionCode") VALUES ('29a2c849-3eca-4a32-a695-d42dfdc865cd', '3B');
INSERT INTO public."PlayerPositionEntity" ("PlayerId", "PositionCode") VALUES ('29a2c849-3eca-4a32-a695-d42dfdc865cd', 'SS');
INSERT INTO public."PlayerPositionEntity" ("PlayerId", "PositionCode") VALUES ('31ac324b-fed5-4aec-80ee-f14688e07919', 'OF');
INSERT INTO public."PlayerPositionEntity" ("PlayerId", "PositionCode") VALUES ('341681b1-c99b-4c2b-90f7-9b1af902ddc2', 'SP');
INSERT INTO public."PlayerPositionEntity" ("PlayerId", "PositionCode") VALUES ('36147a16-d7c4-48bb-b647-b8d59a5ec899', 'SP');
INSERT INTO public."PlayerPositionEntity" ("PlayerId", "PositionCode") VALUES ('379e76bb-af9c-490f-b8d1-73a0f3cdb9f8', 'SS');
INSERT INTO public."PlayerPositionEntity" ("PlayerId", "PositionCode") VALUES ('379f2dec-88b0-46c4-961e-40e5df7ba20f', 'OF');
INSERT INTO public."PlayerPositionEntity" ("PlayerId", "PositionCode") VALUES ('38e839cc-52b8-49e2-a677-51846d2dca95', 'RP');
INSERT INTO public."PlayerPositionEntity" ("PlayerId", "PositionCode") VALUES ('39c2b781-d30c-4c4e-bb7a-42134a9b249a', 'RP');
INSERT INTO public."PlayerPositionEntity" ("PlayerId", "PositionCode") VALUES ('3d71e823-f1e8-49e5-aad1-97f39ca448ef', 'C');
INSERT INTO public."PlayerPositionEntity" ("PlayerId", "PositionCode") VALUES ('43ee2b05-10b6-4894-a6cd-5c47a2f45160', '3B');
INSERT INTO public."PlayerPositionEntity" ("PlayerId", "PositionCode") VALUES ('47b9f5a7-811a-4a16-9385-f575de5d4389', 'OF');
INSERT INTO public."PlayerPositionEntity" ("PlayerId", "PositionCode") VALUES ('48b7aa93-3463-4fc2-b9b1-0311e5c60277', 'RP');
INSERT INTO public."PlayerPositionEntity" ("PlayerId", "PositionCode") VALUES ('48b7aa93-3463-4fc2-b9b1-0311e5c60277', 'SP');
INSERT INTO public."PlayerPositionEntity" ("PlayerId", "PositionCode") VALUES ('4cc4cef2-30b0-425b-91a1-799d9a4c812f', 'SP');
INSERT INTO public."PlayerPositionEntity" ("PlayerId", "PositionCode") VALUES ('50e93fc7-68d6-4523-875f-0bb344cb91e5', 'SP');
INSERT INTO public."PlayerPositionEntity" ("PlayerId", "PositionCode") VALUES ('5801e077-cc58-43e9-ad4a-f9802fee7369', '2B');
INSERT INTO public."PlayerPositionEntity" ("PlayerId", "PositionCode") VALUES ('5801e077-cc58-43e9-ad4a-f9802fee7369', 'SS');
INSERT INTO public."PlayerPositionEntity" ("PlayerId", "PositionCode") VALUES ('61712e5d-41a6-4df7-8394-f4c71ba0f401', 'RP');
INSERT INTO public."PlayerPositionEntity" ("PlayerId", "PositionCode") VALUES ('643d1447-e90a-4677-898a-bd1d02bed609', 'C');
INSERT INTO public."PlayerPositionEntity" ("PlayerId", "PositionCode") VALUES ('6d69e269-8028-4703-b0f2-62a2dcdb15dc', 'P');
INSERT INTO public."PlayerPositionEntity" ("PlayerId", "PositionCode") VALUES ('6f353142-40d0-41df-ac78-2b437c7c2263', 'RP');
INSERT INTO public."PlayerPositionEntity" ("PlayerId", "PositionCode") VALUES ('7198c9e4-12ef-4035-b539-7ee9ad8b3345', 'SP');
INSERT INTO public."PlayerPositionEntity" ("PlayerId", "PositionCode") VALUES ('7b7017f3-7de6-4348-b4a9-81286367d15c', 'SS');
INSERT INTO public."PlayerPositionEntity" ("PlayerId", "PositionCode") VALUES ('82a7ac73-8279-481f-b41e-49b0b9901250', 'OF');
INSERT INTO public."PlayerPositionEntity" ("PlayerId", "PositionCode") VALUES ('8a03b582-c34a-4f16-afa5-6f3447a4b47a', 'OF');
INSERT INTO public."PlayerPositionEntity" ("PlayerId", "PositionCode") VALUES ('9876ba8d-d95d-44de-9460-1f4f0c3b09d1', 'SP');
INSERT INTO public."PlayerPositionEntity" ("PlayerId", "PositionCode") VALUES ('9a4be7e0-e5a0-4281-99ff-4b498401d124', 'RP');
INSERT INTO public."PlayerPositionEntity" ("PlayerId", "PositionCode") VALUES ('9eadde7d-b72e-4a6e-9ac3-77075ae359b0', 'RP');
INSERT INTO public."PlayerPositionEntity" ("PlayerId", "PositionCode") VALUES ('9f0384ee-02a9-43b7-88dc-4d9c7f530dda', '3B');
INSERT INTO public."PlayerPositionEntity" ("PlayerId", "PositionCode") VALUES ('a07eb266-0b30-43c6-b53c-7b0e8a2bb883', 'SP');
INSERT INTO public."PlayerPositionEntity" ("PlayerId", "PositionCode") VALUES ('a0dcc1fb-0beb-4b1f-8f19-c6d7568b573d', 'RP');
INSERT INTO public."PlayerPositionEntity" ("PlayerId", "PositionCode") VALUES ('a0dcc1fb-0beb-4b1f-8f19-c6d7568b573d', 'SP');
INSERT INTO public."PlayerPositionEntity" ("PlayerId", "PositionCode") VALUES ('a54864b7-9923-44aa-8627-3acb70462246', '1B');
INSERT INTO public."PlayerPositionEntity" ("PlayerId", "PositionCode") VALUES ('a7da4769-9b95-4317-8a35-251d4ec5fd20', '2B');
INSERT INTO public."PlayerPositionEntity" ("PlayerId", "PositionCode") VALUES ('a7da4769-9b95-4317-8a35-251d4ec5fd20', 'OF');
INSERT INTO public."PlayerPositionEntity" ("PlayerId", "PositionCode") VALUES ('a7da4769-9b95-4317-8a35-251d4ec5fd20', 'SS');
INSERT INTO public."PlayerPositionEntity" ("PlayerId", "PositionCode") VALUES ('a920a779-1a2a-40ce-ba10-69f9b022e458', 'RP');
INSERT INTO public."PlayerPositionEntity" ("PlayerId", "PositionCode") VALUES ('ac2a670c-6da8-4252-99fd-7d952706a816', '1B');
INSERT INTO public."PlayerPositionEntity" ("PlayerId", "PositionCode") VALUES ('b1f37406-2a67-4b8c-91c1-75a50a6f763d', 'OF');
INSERT INTO public."PlayerPositionEntity" ("PlayerId", "PositionCode") VALUES ('b55cf6a3-77fc-4689-bae8-694d34055070', 'SP');
INSERT INTO public."PlayerPositionEntity" ("PlayerId", "PositionCode") VALUES ('b690f262-e87a-4038-add9-6d64af2ada29', '3B');
INSERT INTO public."PlayerPositionEntity" ("PlayerId", "PositionCode") VALUES ('bd9c9d88-4fe4-492a-b70a-f60982b8216d', 'RP');
INSERT INTO public."PlayerPositionEntity" ("PlayerId", "PositionCode") VALUES ('bf019d49-25bd-4885-9d2b-55ee958fe547', '2B');
INSERT INTO public."PlayerPositionEntity" ("PlayerId", "PositionCode") VALUES ('bf019d49-25bd-4885-9d2b-55ee958fe547', '3B');
INSERT INTO public."PlayerPositionEntity" ("PlayerId", "PositionCode") VALUES ('bf019d49-25bd-4885-9d2b-55ee958fe547', 'SS');
INSERT INTO public."PlayerPositionEntity" ("PlayerId", "PositionCode") VALUES ('c378cd4e-d49d-44fb-8b63-adb7abc1ff64', 'RP');
INSERT INTO public."PlayerPositionEntity" ("PlayerId", "PositionCode") VALUES ('c4608bbb-dc81-4891-9775-78946407d39c', '2B');
INSERT INTO public."PlayerPositionEntity" ("PlayerId", "PositionCode") VALUES ('c6ba6850-6017-4ab3-9090-81b83d046c5a', 'SP');
INSERT INTO public."PlayerPositionEntity" ("PlayerId", "PositionCode") VALUES ('ca82ac78-e3c3-4051-a15b-a70ef623d6c3', 'RP');
INSERT INTO public."PlayerPositionEntity" ("PlayerId", "PositionCode") VALUES ('d0fc0a0d-2d4d-4040-89dd-d67ed85a69e9', 'RP');
INSERT INTO public."PlayerPositionEntity" ("PlayerId", "PositionCode") VALUES ('d1df308b-1ea9-4419-8729-d2cac3753e6b', '2B');
INSERT INTO public."PlayerPositionEntity" ("PlayerId", "PositionCode") VALUES ('dff2cb50-a73b-40df-bdc0-f229299769de', 'RP');
INSERT INTO public."PlayerPositionEntity" ("PlayerId", "PositionCode") VALUES ('e0deb378-7f52-4742-a2f9-75ae12346db4', 'SP');
INSERT INTO public."PlayerPositionEntity" ("PlayerId", "PositionCode") VALUES ('e2f3a018-6216-43fa-a24c-96d5f6f61685', 'OF');
INSERT INTO public."PlayerPositionEntity" ("PlayerId", "PositionCode") VALUES ('e7d67172-ee82-4a30-9bb1-ff3d51285cf6', 'RP');
INSERT INTO public."PlayerPositionEntity" ("PlayerId", "PositionCode") VALUES ('e8774047-7ff9-43e7-b709-f7f66cb4def9', 'SS');
INSERT INTO public."PlayerPositionEntity" ("PlayerId", "PositionCode") VALUES ('e9137344-a90c-4d35-be6f-cd3f435542eb', '3B');
INSERT INTO public."PlayerPositionEntity" ("PlayerId", "PositionCode") VALUES ('e9137344-a90c-4d35-be6f-cd3f435542eb', 'SS');
INSERT INTO public."PlayerPositionEntity" ("PlayerId", "PositionCode") VALUES ('eb338553-881b-45df-b252-70b47040b42c', 'SP');
INSERT INTO public."PlayerPositionEntity" ("PlayerId", "PositionCode") VALUES ('ebe41b0a-d144-4f3d-8c57-3b4f5300b44f', 'SS');
INSERT INTO public."PlayerPositionEntity" ("PlayerId", "PositionCode") VALUES ('ed798f1a-0241-4b94-98a7-876fe949ee91', '1B');
INSERT INTO public."PlayerPositionEntity" ("PlayerId", "PositionCode") VALUES ('ed798f1a-0241-4b94-98a7-876fe949ee91', 'OF');
INSERT INTO public."PlayerPositionEntity" ("PlayerId", "PositionCode") VALUES ('ef0b95a8-da60-4c25-926d-cf60476821b0', '1B');
INSERT INTO public."PlayerPositionEntity" ("PlayerId", "PositionCode") VALUES ('f2915b39-76e3-47d8-8dc3-44ce0ff4b793', 'SP');
INSERT INTO public."PlayerPositionEntity" ("PlayerId", "PositionCode") VALUES ('f39e1057-9003-4ea5-9360-94c12b1cec69', '1B');
INSERT INTO public."PlayerPositionEntity" ("PlayerId", "PositionCode") VALUES ('f39e1057-9003-4ea5-9360-94c12b1cec69', '2B');
INSERT INTO public."PlayerPositionEntity" ("PlayerId", "PositionCode") VALUES ('f39e1057-9003-4ea5-9360-94c12b1cec69', '3B');
INSERT INTO public."PlayerPositionEntity" ("PlayerId", "PositionCode") VALUES ('f39e1057-9003-4ea5-9360-94c12b1cec69', 'OF');
INSERT INTO public."PlayerPositionEntity" ("PlayerId", "PositionCode") VALUES ('f44be3eb-2a2b-476d-ac6f-27244bc47978', 'C');
INSERT INTO public."PlayerPositionEntity" ("PlayerId", "PositionCode") VALUES ('f774ff89-a188-4adb-a2ab-38186a60a609', 'SP');
INSERT INTO public."PlayerPositionEntity" ("PlayerId", "PositionCode") VALUES ('faccb3da-4eca-413e-b119-930b7ae8f76e', 'RP');
INSERT INTO public."PlayerPositionEntity" ("PlayerId", "PositionCode") VALUES ('b78b26fa-88c7-4f12-addb-585140bacde7', 'RP');
INSERT INTO public."PlayerPositionEntity" ("PlayerId", "PositionCode") VALUES ('8d89ac4c-28ef-48bb-b6f4-b4bd7ae55022', 'RP');
INSERT INTO public."PlayerPositionEntity" ("PlayerId", "PositionCode") VALUES ('35601382-71e5-41c5-ba1e-542441107a98', 'SP');
INSERT INTO public."PlayerPositionEntity" ("PlayerId", "PositionCode") VALUES ('35601382-71e5-41c5-ba1e-542441107a98', 'RP');
INSERT INTO public."PlayerPositionEntity" ("PlayerId", "PositionCode") VALUES ('952984f5-7fb4-4a29-92a2-bd90a01c5cc3', 'RP');
INSERT INTO public."PlayerPositionEntity" ("PlayerId", "PositionCode") VALUES ('18fa5de6-e188-45f4-be68-f95140061639', 'C');
INSERT INTO public."PlayerPositionEntity" ("PlayerId", "PositionCode") VALUES ('e21028aa-5084-42b6-aa62-10cbcde98ce2', 'C');
INSERT INTO public."PlayerPositionEntity" ("PlayerId", "PositionCode") VALUES ('64583442-204f-4f02-b223-a397cdf09d90', 'RP');
INSERT INTO public."PlayerPositionEntity" ("PlayerId", "PositionCode") VALUES ('153215ee-f49a-4b7d-a910-72fa3a9d47cb', 'RP');
INSERT INTO public."PlayerPositionEntity" ("PlayerId", "PositionCode") VALUES ('61712e5d-41a6-4df7-8394-f4c71ba0f401', 'SP');
INSERT INTO public."PlayerPositionEntity" ("PlayerId", "PositionCode") VALUES ('91ed9cb9-e41a-4214-85be-dc6f6cef224b', 'RP');
INSERT INTO public."PlayerPositionEntity" ("PlayerId", "PositionCode") VALUES ('b690f262-e87a-4038-add9-6d64af2ada29', '2B');
INSERT INTO public."PlayerPositionEntity" ("PlayerId", "PositionCode") VALUES ('1b6f447e-affe-4509-845a-09aadeba3b4c', '2B');
INSERT INTO public."PlayerPositionEntity" ("PlayerId", "PositionCode") VALUES ('392b9ad3-2e05-4496-965e-044013da057b', 'SP');
INSERT INTO public."PlayerPositionEntity" ("PlayerId", "PositionCode") VALUES ('392b9ad3-2e05-4496-965e-044013da057b', 'RP');
INSERT INTO public."PlayerPositionEntity" ("PlayerId", "PositionCode") VALUES ('62795f8a-bdf9-433c-86f0-ee63d2ba9fb6', 'SP');
INSERT INTO public."PlayerPositionEntity" ("PlayerId", "PositionCode") VALUES ('0035735d-c42e-43da-8ae2-fbc476692203', 'RP');
INSERT INTO public."PlayerPositionEntity" ("PlayerId", "PositionCode") VALUES ('4b264e78-617a-477e-8d27-177c878fec9a', 'RP');
INSERT INTO public."PlayerPositionEntity" ("PlayerId", "PositionCode") VALUES ('643d1447-e90a-4677-898a-bd1d02bed609', 'OF');
INSERT INTO public."PlayerPositionEntity" ("PlayerId", "PositionCode") VALUES ('952984f5-7fb4-4a29-92a2-bd90a01c5cc3', 'SP');
INSERT INTO public."PlayerPositionEntity" ("PlayerId", "PositionCode") VALUES ('ac2a670c-6da8-4252-99fd-7d952706a816', '2B');
INSERT INTO public."PlayerPositionEntity" ("PlayerId", "PositionCode") VALUES ('081f3aa5-b16c-4e83-80d7-1b905c525a72', '1B');
INSERT INTO public."PlayerPositionEntity" ("PlayerId", "PositionCode") VALUES ('010ae0a2-84ee-48cf-9cf7-8a2ec508cc33', 'OF');
INSERT INTO public."PlayerPositionEntity" ("PlayerId", "PositionCode") VALUES ('1b6f447e-affe-4509-845a-09aadeba3b4c', 'OF');
INSERT INTO public."PlayerPositionEntity" ("PlayerId", "PositionCode") VALUES ('0354b4bf-2ef4-47be-bf08-ecaa1704873c', 'C');
INSERT INTO public."PlayerPositionEntity" ("PlayerId", "PositionCode") VALUES ('2399dd10-b652-4796-8248-80b3975a936a', 'SS');
INSERT INTO public."PlayerPositionEntity" ("PlayerId", "PositionCode") VALUES ('2399dd10-b652-4796-8248-80b3975a936a', '2B');
INSERT INTO public."PlayerPositionEntity" ("PlayerId", "PositionCode") VALUES ('62795f8a-bdf9-433c-86f0-ee63d2ba9fb6', 'RP');
INSERT INTO public."PlayerPositionEntity" ("PlayerId", "PositionCode") VALUES ('d017942e-c5f9-49bf-9fb7-dbd129dedcab', 'OF');


--
-- TOC entry 3355 (class 0 OID 16397)
-- Dependencies: 213
-- Data for Name: Players; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public."Players" ("Id", "BhqId", "Type", "FirstName", "LastName", "Age", "Team", "Status", "AverageDraftPickMin", "AverageDraftPick", "MlbAmId", "Reliability", "MayberryMethod", "AverageDraftPickMax") VALUES ('2399dd10-b652-4796-8248-80b3975a936a', 7096, 1, 'Vaughn', 'Grissom', 21, 'ATL', 0, 9999, 9999, 9999, 0.4666666666666666, 13, 0);
INSERT INTO public."Players" ("Id", "BhqId", "Type", "FirstName", "LastName", "Age", "Team", "Status", "AverageDraftPickMin", "AverageDraftPick", "MlbAmId", "Reliability", "MayberryMethod", "AverageDraftPickMax") VALUES ('6f353142-40d0-41df-ac78-2b437c7c2263', 5358, 2, 'Brent', 'Suter', 32, 'MIL', 0, 408, 9999, 9999, 0.3333333333333333, 0, 0);
INSERT INTO public."Players" ("Id", "BhqId", "Type", "FirstName", "LastName", "Age", "Team", "Status", "AverageDraftPickMin", "AverageDraftPick", "MlbAmId", "Reliability", "MayberryMethod", "AverageDraftPickMax") VALUES ('7198c9e4-12ef-4035-b539-7ee9ad8b3345', 6538, 2, 'Luis', 'Garcia', 25, 'HOU', 0, 156, 9999, 9999, 0.8000000000000002, 30, 0);
INSERT INTO public."Players" ("Id", "BhqId", "Type", "FirstName", "LastName", "Age", "Team", "Status", "AverageDraftPickMin", "AverageDraftPick", "MlbAmId", "Reliability", "MayberryMethod", "AverageDraftPickMax") VALUES ('5801e077-cc58-43e9-ad4a-f9802fee7369', 6209, 1, 'Jazz', 'Chisholm Jr.', 24, 'MIA', 1, 65, 9999, 9999, 0.7333333333333334, 15, 0);
INSERT INTO public."Players" ("Id", "BhqId", "Type", "FirstName", "LastName", "Age", "Team", "Status", "AverageDraftPickMin", "AverageDraftPick", "MlbAmId", "Reliability", "MayberryMethod", "AverageDraftPickMax") VALUES ('0aa22cce-8c66-4b09-9b5d-7ac2db34bbe3', 6179, 1, 'Mike', 'Brosseau', 28, 'MIL', 0, 9999, 9999, 9999, 0.6, 7, 0);
INSERT INTO public."Players" ("Id", "BhqId", "Type", "FirstName", "LastName", "Age", "Team", "Status", "AverageDraftPickMin", "AverageDraftPick", "MlbAmId", "Reliability", "MayberryMethod", "AverageDraftPickMax") VALUES ('0ae9f4c0-1349-481b-9bd0-a649ba6615dc', 4614, 2, 'Robbie', 'Ray', 30, 'SEA', 0, 50, 9999, 9999, 0.5333333333333333, 85, 0);
INSERT INTO public."Players" ("Id", "BhqId", "Type", "FirstName", "LastName", "Age", "Team", "Status", "AverageDraftPickMin", "AverageDraftPick", "MlbAmId", "Reliability", "MayberryMethod", "AverageDraftPickMax") VALUES ('111adb78-e25e-45ef-ab8f-67389b691964', 5879, 2, 'Freddy', 'Peralta', 26, 'MIL', 1, 51, 9999, 9999, 0.8000000000000002, 11, 0);
INSERT INTO public."Players" ("Id", "BhqId", "Type", "FirstName", "LastName", "Age", "Team", "Status", "AverageDraftPickMin", "AverageDraftPick", "MlbAmId", "Reliability", "MayberryMethod", "AverageDraftPickMax") VALUES ('17331001-9ba0-478d-ae5d-141f64d84196', 5199, 1, 'Rowdy', 'Tellez', 27, 'MIL', 0, 316, 9999, 9999, 0.6666666666666666, 65, 0);
INSERT INTO public."Players" ("Id", "BhqId", "Type", "FirstName", "LastName", "Age", "Team", "Status", "AverageDraftPickMin", "AverageDraftPick", "MlbAmId", "Reliability", "MayberryMethod", "AverageDraftPickMax") VALUES ('19abc855-4ce0-40f7-8e58-8808a15f0462', 5472, 1, 'Alex', 'Jackson', 26, 'MIL', 0, 9999, 9999, 9999, 0.5333333333333333, 0, 0);
INSERT INTO public."Players" ("Id", "BhqId", "Type", "FirstName", "LastName", "Age", "Team", "Status", "AverageDraftPickMin", "AverageDraftPick", "MlbAmId", "Reliability", "MayberryMethod", "AverageDraftPickMax") VALUES ('1b43560c-6ac5-4e77-9368-631a24e16e6f', 5333, 1, 'David', 'Dahl', 28, 'MIL', 0, 9999, 9999, 9999, 0, 0, 0);
INSERT INTO public."Players" ("Id", "BhqId", "Type", "FirstName", "LastName", "Age", "Team", "Status", "AverageDraftPickMin", "AverageDraftPick", "MlbAmId", "Reliability", "MayberryMethod", "AverageDraftPickMax") VALUES ('61712e5d-41a6-4df7-8394-f4c71ba0f401', 6633, 2, 'Garrett', 'Whitlock', 26, 'BOS', 0, 272, 9999, 9999, 0.5333333333333333, 26, 0);
INSERT INTO public."Players" ("Id", "BhqId", "Type", "FirstName", "LastName", "Age", "Team", "Status", "AverageDraftPickMin", "AverageDraftPick", "MlbAmId", "Reliability", "MayberryMethod", "AverageDraftPickMax") VALUES ('82a7ac73-8279-481f-b41e-49b0b9901250', 2567, 1, 'Andrew', 'McCutchen', 35, 'MIL', 0, 291, 9999, 9999, 0.7999999999999999, 50, 0);
INSERT INTO public."Players" ("Id", "BhqId", "Type", "FirstName", "LastName", "Age", "Team", "Status", "AverageDraftPickMin", "AverageDraftPick", "MlbAmId", "Reliability", "MayberryMethod", "AverageDraftPickMax") VALUES ('23889720-3073-4c37-a7dd-63fdb633498b', 5083, 1, 'Hunter', 'Renfroe', 30, 'MIL', 0, 150, 9999, 9999, 0.7999999999999999, 65, 0);
INSERT INTO public."Players" ("Id", "BhqId", "Type", "FirstName", "LastName", "Age", "Team", "Status", "AverageDraftPickMin", "AverageDraftPick", "MlbAmId", "Reliability", "MayberryMethod", "AverageDraftPickMax") VALUES ('23950b3c-eef2-4d71-ada6-fc67d88d53e3', 3976, 2, 'Brad', 'Boxberger', 34, 'MIL', 0, 416, 9999, 9999, 0.6000000000000001, 6, 0);
INSERT INTO public."Players" ("Id", "BhqId", "Type", "FirstName", "LastName", "Age", "Team", "Status", "AverageDraftPickMin", "AverageDraftPick", "MlbAmId", "Reliability", "MayberryMethod", "AverageDraftPickMax") VALUES ('17c04c57-e2a3-4265-b4e7-173c97bbb1cd', 3941, 1, 'Bryce', 'Harper', 29, 'PHI', 0, 9, 9999, 9999, 0.7999999999999999, 45, 0);
INSERT INTO public."Players" ("Id", "BhqId", "Type", "FirstName", "LastName", "Age", "Team", "Status", "AverageDraftPickMin", "AverageDraftPick", "MlbAmId", "Reliability", "MayberryMethod", "AverageDraftPickMax") VALUES ('1e6f7190-9b05-4abe-b88d-e4624f4b555d', 6373, 1, 'Daulton', 'Varsho', 26, 'ARZ', 0, 168, 9999, 9999, 0.7333333333333334, 65, 0);
INSERT INTO public."Players" ("Id", "BhqId", "Type", "FirstName", "LastName", "Age", "Team", "Status", "AverageDraftPickMin", "AverageDraftPick", "MlbAmId", "Reliability", "MayberryMethod", "AverageDraftPickMax") VALUES ('1fe5d5b4-e833-4828-ac28-4bd253c78aa0', 5048, 1, 'Aaron', 'Judge', 30, 'NYY', 0, 33, 9999, 9999, 0.8000000000000002, 80, 0);
INSERT INTO public."Players" ("Id", "BhqId", "Type", "FirstName", "LastName", "Age", "Team", "Status", "AverageDraftPickMin", "AverageDraftPick", "MlbAmId", "Reliability", "MayberryMethod", "AverageDraftPickMax") VALUES ('25f7a378-4ce3-41f1-86c0-5e631e47cd35', 2972, 2, 'David', 'Robertson', 37, 'PHI', 0, 9999, 9999, 9999, 0.20000000000000004, 30, 0);
INSERT INTO public."Players" ("Id", "BhqId", "Type", "FirstName", "LastName", "Age", "Team", "Status", "AverageDraftPickMin", "AverageDraftPick", "MlbAmId", "Reliability", "MayberryMethod", "AverageDraftPickMax") VALUES ('39c2b781-d30c-4c4e-bb7a-42134a9b249a', 5627, 2, 'Hoby', 'Milner', 31, 'MIL', 0, 9999, 9999, 9999, 0.4666666666666666, 0, 0);
INSERT INTO public."Players" ("Id", "BhqId", "Type", "FirstName", "LastName", "Age", "Team", "Status", "AverageDraftPickMin", "AverageDraftPick", "MlbAmId", "Reliability", "MayberryMethod", "AverageDraftPickMax") VALUES ('29a2c849-3eca-4a32-a695-d42dfdc865cd', 6596, 1, 'Ha-Seong', 'Kim', 26, 'SD', 0, 9999, 9999, 9999, 0.9333333333333332, 65, 0);
INSERT INTO public."Players" ("Id", "BhqId", "Type", "FirstName", "LastName", "Age", "Team", "Status", "AverageDraftPickMin", "AverageDraftPick", "MlbAmId", "Reliability", "MayberryMethod", "AverageDraftPickMax") VALUES ('43ee2b05-10b6-4894-a6cd-5c47a2f45160', 5981, 1, 'Pablo', 'Reyes', 28, 'MIL', 0, 9999, 9999, 9999, 0.4666666666666666, 0, 0);
INSERT INTO public."Players" ("Id", "BhqId", "Type", "FirstName", "LastName", "Age", "Team", "Status", "AverageDraftPickMin", "AverageDraftPick", "MlbAmId", "Reliability", "MayberryMethod", "AverageDraftPickMax") VALUES ('4cc4cef2-30b0-425b-91a1-799d9a4c812f', 5601, 2, 'Triston', 'McKenzie', 24, 'CLE', 0, 195, 9999, 9999, 0.7333333333333334, 60, 0);
INSERT INTO public."Players" ("Id", "BhqId", "Type", "FirstName", "LastName", "Age", "Team", "Status", "AverageDraftPickMin", "AverageDraftPick", "MlbAmId", "Reliability", "MayberryMethod", "AverageDraftPickMax") VALUES ('096483e1-eaf6-4eb8-85b1-6492ff7db10d', 6002, 1, 'Andres', 'Gimenez', 23, 'CLE', 0, 342, 9999, 9999, 0.8666666666666667, 85, 0);
INSERT INTO public."Players" ("Id", "BhqId", "Type", "FirstName", "LastName", "Age", "Team", "Status", "AverageDraftPickMin", "AverageDraftPick", "MlbAmId", "Reliability", "MayberryMethod", "AverageDraftPickMax") VALUES ('341681b1-c99b-4c2b-90f7-9b1af902ddc2', 2841, 2, 'Max', 'Scherzer', 37, 'NYM', 1, 13, 9999, 9999, 0.7333333333333334, 48, 0);
INSERT INTO public."Players" ("Id", "BhqId", "Type", "FirstName", "LastName", "Age", "Team", "Status", "AverageDraftPickMin", "AverageDraftPick", "MlbAmId", "Reliability", "MayberryMethod", "AverageDraftPickMax") VALUES ('31ac324b-fed5-4aec-80ee-f14688e07919', 4886, 1, 'Tyrone', 'Taylor', 28, 'MIL', 0, 9999, 9999, 9999, 0.7333333333333334, 36, 0);
INSERT INTO public."Players" ("Id", "BhqId", "Type", "FirstName", "LastName", "Age", "Team", "Status", "AverageDraftPickMin", "AverageDraftPick", "MlbAmId", "Reliability", "MayberryMethod", "AverageDraftPickMax") VALUES ('36147a16-d7c4-48bb-b647-b8d59a5ec899', 5085, 2, 'Adrian', 'Houser', 29, 'MIL', 0, 487, 9999, 9999, 0.8666666666666667, 3, 0);
INSERT INTO public."Players" ("Id", "BhqId", "Type", "FirstName", "LastName", "Age", "Team", "Status", "AverageDraftPickMin", "AverageDraftPick", "MlbAmId", "Reliability", "MayberryMethod", "AverageDraftPickMax") VALUES ('379e76bb-af9c-490f-b8d1-73a0f3cdb9f8', 5053, 1, 'Willy', 'Adames', 26, 'MIL', 0, 134, 9999, 9999, 1, 70, 0);
INSERT INTO public."Players" ("Id", "BhqId", "Type", "FirstName", "LastName", "Age", "Team", "Status", "AverageDraftPickMin", "AverageDraftPick", "MlbAmId", "Reliability", "MayberryMethod", "AverageDraftPickMax") VALUES ('379f2dec-88b0-46c4-961e-40e5df7ba20f', 5736, 1, 'Kyle', 'Tucker', 25, 'HOU', 0, 8, 9999, 9999, 0.8666666666666667, 80, 0);
INSERT INTO public."Players" ("Id", "BhqId", "Type", "FirstName", "LastName", "Age", "Team", "Status", "AverageDraftPickMin", "AverageDraftPick", "MlbAmId", "Reliability", "MayberryMethod", "AverageDraftPickMax") VALUES ('38e839cc-52b8-49e2-a677-51846d2dca95', 5098, 2, 'Seth', 'Lugo', 32, 'NYM', 0, 493, 9999, 9999, 0.6, 10, 0);
INSERT INTO public."Players" ("Id", "BhqId", "Type", "FirstName", "LastName", "Age", "Team", "Status", "AverageDraftPickMin", "AverageDraftPick", "MlbAmId", "Reliability", "MayberryMethod", "AverageDraftPickMax") VALUES ('643d1447-e90a-4677-898a-bd1d02bed609', 6806, 1, 'MJ', 'Melendez', 23, 'KC', 0, 9999, 9999, 9999, 0.6666666666666666, 55, 0);
INSERT INTO public."Players" ("Id", "BhqId", "Type", "FirstName", "LastName", "Age", "Team", "Status", "AverageDraftPickMin", "AverageDraftPick", "MlbAmId", "Reliability", "MayberryMethod", "AverageDraftPickMax") VALUES ('8a03b582-c34a-4f16-afa5-6f3447a4b47a', 6881, 1, 'Riley', 'Greene', 21, 'DET', 0, 301, 9999, 9999, 0.6666666666666666, 21, 0);
INSERT INTO public."Players" ("Id", "BhqId", "Type", "FirstName", "LastName", "Age", "Team", "Status", "AverageDraftPickMin", "AverageDraftPick", "MlbAmId", "Reliability", "MayberryMethod", "AverageDraftPickMax") VALUES ('3d71e823-f1e8-49e5-aad1-97f39ca448ef', 5316, 1, 'Omar', 'Narvaez', 30, 'MIL', 0, 320, 9999, 9999, 0.7999999999999999, 15, 0);
INSERT INTO public."Players" ("Id", "BhqId", "Type", "FirstName", "LastName", "Age", "Team", "Status", "AverageDraftPickMin", "AverageDraftPick", "MlbAmId", "Reliability", "MayberryMethod", "AverageDraftPickMax") VALUES ('7b7017f3-7de6-4348-b4a9-81286367d15c', 4528, 1, 'Francisco', 'Lindor', 28, 'NYM', 0, 37, 9999, 9999, 0.8666666666666667, 75, 0);
INSERT INTO public."Players" ("Id", "BhqId", "Type", "FirstName", "LastName", "Age", "Team", "Status", "AverageDraftPickMin", "AverageDraftPick", "MlbAmId", "Reliability", "MayberryMethod", "AverageDraftPickMax") VALUES ('47b9f5a7-811a-4a16-9385-f575de5d4389', 4363, 1, 'George', 'Springer', 32, 'TOR', 0, 49, 9999, 9999, 0.6666666666666666, 85, 0);
INSERT INTO public."Players" ("Id", "BhqId", "Type", "FirstName", "LastName", "Age", "Team", "Status", "AverageDraftPickMin", "AverageDraftPick", "MlbAmId", "Reliability", "MayberryMethod", "AverageDraftPickMax") VALUES ('48b7aa93-3463-4fc2-b9b1-0311e5c60277', 6580, 2, 'Aaron', 'Ashby', 24, 'MIL', 0, 297, 9999, 9999, 0.4666666666666666, 30, 0);
INSERT INTO public."Players" ("Id", "BhqId", "Type", "FirstName", "LastName", "Age", "Team", "Status", "AverageDraftPickMin", "AverageDraftPick", "MlbAmId", "Reliability", "MayberryMethod", "AverageDraftPickMax") VALUES ('081f3aa5-b16c-4e83-80d7-1b905c525a72', 6053, 1, 'Isaac', 'Paredes', 23, 'TB', 0, 9999, 9999, 9999, 0.6666666666666666, 30, 0);
INSERT INTO public."Players" ("Id", "BhqId", "Type", "FirstName", "LastName", "Age", "Team", "Status", "AverageDraftPickMin", "AverageDraftPick", "MlbAmId", "Reliability", "MayberryMethod", "AverageDraftPickMax") VALUES ('50e93fc7-68d6-4523-875f-0bb344cb91e5', 5924, 2, 'Corbin', 'Burnes', 27, 'MIL', 0, 7, 9999, 9999, 0.6, 100, 0);
INSERT INTO public."Players" ("Id", "BhqId", "Type", "FirstName", "LastName", "Age", "Team", "Status", "AverageDraftPickMin", "AverageDraftPick", "MlbAmId", "Reliability", "MayberryMethod", "AverageDraftPickMax") VALUES ('1a2b372b-44b2-4989-8af0-6499a2659c87', 4335, 1, 'Christian', 'Yelich', 30, 'MIL', 0, 89, 9999, 9999, 0.6, 75, 0);
INSERT INTO public."Players" ("Id", "BhqId", "Type", "FirstName", "LastName", "Age", "Team", "Status", "AverageDraftPickMin", "AverageDraftPick", "MlbAmId", "Reliability", "MayberryMethod", "AverageDraftPickMax") VALUES ('6d69e269-8028-4703-b0f2-62a2dcdb15dc', 6675, 2, 'Alec', 'Bettinger', 26, 'MIL', 0, 9999, 9999, 9999, 0, 0, 0);
INSERT INTO public."Players" ("Id", "BhqId", "Type", "FirstName", "LastName", "Age", "Team", "Status", "AverageDraftPickMin", "AverageDraftPick", "MlbAmId", "Reliability", "MayberryMethod", "AverageDraftPickMax") VALUES ('9876ba8d-d95d-44de-9460-1f4f0c3b09d1', 5427, 2, 'Brandon', 'Woodruff', 29, 'MIL', 0, 17, 9999, 9999, 0.9333333333333332, 48, 0);
INSERT INTO public."Players" ("Id", "BhqId", "Type", "FirstName", "LastName", "Age", "Team", "Status", "AverageDraftPickMin", "AverageDraftPick", "MlbAmId", "Reliability", "MayberryMethod", "AverageDraftPickMax") VALUES ('9a4be7e0-e5a0-4281-99ff-4b498401d124', 3677, 2, 'Rex', 'Brothers', 34, 'MIL', 0, 9999, 9999, 9999, 0, 0, 0);
INSERT INTO public."Players" ("Id", "BhqId", "Type", "FirstName", "LastName", "Age", "Team", "Status", "AverageDraftPickMin", "AverageDraftPick", "MlbAmId", "Reliability", "MayberryMethod", "AverageDraftPickMax") VALUES ('9eadde7d-b72e-4a6e-9ac3-77075ae359b0', 5955, 2, 'Chad', 'Sobotka', 28, 'MIL', 0, 9999, 9999, 9999, 0, 0, 0);
INSERT INTO public."Players" ("Id", "BhqId", "Type", "FirstName", "LastName", "Age", "Team", "Status", "AverageDraftPickMin", "AverageDraftPick", "MlbAmId", "Reliability", "MayberryMethod", "AverageDraftPickMax") VALUES ('9f0384ee-02a9-43b7-88dc-4d9c7f530dda', 5407, 1, 'Matt', 'Chapman', 29, 'TOR', 0, 141, 9999, 9999, 0.8666666666666667, 60, 0);
INSERT INTO public."Players" ("Id", "BhqId", "Type", "FirstName", "LastName", "Age", "Team", "Status", "AverageDraftPickMin", "AverageDraftPick", "MlbAmId", "Reliability", "MayberryMethod", "AverageDraftPickMax") VALUES ('a07eb266-0b30-43c6-b53c-7b0e8a2bb883', 5237, 2, 'Joe', 'Musgrove', 29, 'SD', 0, 57, 9999, 9999, 0.7333333333333334, 80, 0);
INSERT INTO public."Players" ("Id", "BhqId", "Type", "FirstName", "LastName", "Age", "Team", "Status", "AverageDraftPickMin", "AverageDraftPick", "MlbAmId", "Reliability", "MayberryMethod", "AverageDraftPickMax") VALUES ('a0dcc1fb-0beb-4b1f-8f19-c6d7568b573d', 6694, 2, 'J.C.', 'Mejia', 25, 'MIL', 0, 9999, 9999, 9999, 0.4666666666666666, 0, 0);
INSERT INTO public."Players" ("Id", "BhqId", "Type", "FirstName", "LastName", "Age", "Team", "Status", "AverageDraftPickMin", "AverageDraftPick", "MlbAmId", "Reliability", "MayberryMethod", "AverageDraftPickMax") VALUES ('a54864b7-9923-44aa-8627-3acb70462246', 5391, 1, 'Rhys', 'Hoskins', 29, 'PHI', 0, 106, 9999, 9999, 0.8666666666666667, 75, 0);
INSERT INTO public."Players" ("Id", "BhqId", "Type", "FirstName", "LastName", "Age", "Team", "Status", "AverageDraftPickMin", "AverageDraftPick", "MlbAmId", "Reliability", "MayberryMethod", "AverageDraftPickMax") VALUES ('a920a779-1a2a-40ce-ba10-69f9b022e458', 3659, 2, 'Blaine', 'Hardy', 35, 'MIL', 0, 9999, 9999, 9999, 0, 0, 0);
INSERT INTO public."Players" ("Id", "BhqId", "Type", "FirstName", "LastName", "Age", "Team", "Status", "AverageDraftPickMin", "AverageDraftPick", "MlbAmId", "Reliability", "MayberryMethod", "AverageDraftPickMax") VALUES ('ac2a670c-6da8-4252-99fd-7d952706a816', 6009, 1, 'Keston', 'Hiura', 25, 'MIL', 0, 9999, 9999, 9999, 0.7333333333333334, 36, 0);
INSERT INTO public."Players" ("Id", "BhqId", "Type", "FirstName", "LastName", "Age", "Team", "Status", "AverageDraftPickMin", "AverageDraftPick", "MlbAmId", "Reliability", "MayberryMethod", "AverageDraftPickMax") VALUES ('a7da4769-9b95-4317-8a35-251d4ec5fd20', 5611, 1, 'Nick', 'Gordon', 26, 'MIN', 0, 9999, 9999, 9999, 0.7333333333333334, 36, 0);
INSERT INTO public."Players" ("Id", "BhqId", "Type", "FirstName", "LastName", "Age", "Team", "Status", "AverageDraftPickMin", "AverageDraftPick", "MlbAmId", "Reliability", "MayberryMethod", "AverageDraftPickMax") VALUES ('b1f37406-2a67-4b8c-91c1-75a50a6f763d', 6216, 1, 'Jake', 'Fraley', 27, 'CIN', 0, 378, 9999, 9999, 0.4666666666666666, 11, 0);
INSERT INTO public."Players" ("Id", "BhqId", "Type", "FirstName", "LastName", "Age", "Team", "Status", "AverageDraftPickMin", "AverageDraftPick", "MlbAmId", "Reliability", "MayberryMethod", "AverageDraftPickMax") VALUES ('b55cf6a3-77fc-4689-bae8-694d34055070', 6719, 2, 'Joe', 'Ryan', 26, 'MIN', 0, 217, 9999, 9999, 0.4666666666666666, 30, 0);
INSERT INTO public."Players" ("Id", "BhqId", "Type", "FirstName", "LastName", "Age", "Team", "Status", "AverageDraftPickMin", "AverageDraftPick", "MlbAmId", "Reliability", "MayberryMethod", "AverageDraftPickMax") VALUES ('b78b26fa-88c7-4f12-addb-585140bacde7', 6729, 2, 'Miguel', 'Sanchez', 28, 'MIL', 0, 9999, 9999, 9999, 0.4666666666666666, 0, 0);
INSERT INTO public."Players" ("Id", "BhqId", "Type", "FirstName", "LastName", "Age", "Team", "Status", "AverageDraftPickMin", "AverageDraftPick", "MlbAmId", "Reliability", "MayberryMethod", "AverageDraftPickMax") VALUES ('b690f262-e87a-4038-add9-6d64af2ada29', 6885, 1, 'Nolan', 'Gorman', 22, 'STL', 0, 9999, 9999, 9999, 0.6666666666666666, 33, 0);
INSERT INTO public."Players" ("Id", "BhqId", "Type", "FirstName", "LastName", "Age", "Team", "Status", "AverageDraftPickMin", "AverageDraftPick", "MlbAmId", "Reliability", "MayberryMethod", "AverageDraftPickMax") VALUES ('0354b4bf-2ef4-47be-bf08-ecaa1704873c', 6444, 1, 'Jakson', 'Reetz', 26, 'MIL', 0, 9999, 9999, 9999, 0, 0, 0);
INSERT INTO public."Players" ("Id", "BhqId", "Type", "FirstName", "LastName", "Age", "Team", "Status", "AverageDraftPickMin", "AverageDraftPick", "MlbAmId", "Reliability", "MayberryMethod", "AverageDraftPickMax") VALUES ('bd9c9d88-4fe4-492a-b70a-f60982b8216d', 6122, 2, 'Emmanuel', 'Clase', 24, 'CLE', 0, 94, 9999, 9999, 0.7333333333333334, 48, 0);
INSERT INTO public."Players" ("Id", "BhqId", "Type", "FirstName", "LastName", "Age", "Team", "Status", "AverageDraftPickMin", "AverageDraftPick", "MlbAmId", "Reliability", "MayberryMethod", "AverageDraftPickMax") VALUES ('bf019d49-25bd-4885-9d2b-55ee958fe547', 5741, 1, 'Luis', 'Urias', 25, 'MIL', 0, 219, 9999, 9999, 0.8666666666666667, 50, 0);
INSERT INTO public."Players" ("Id", "BhqId", "Type", "FirstName", "LastName", "Age", "Team", "Status", "AverageDraftPickMin", "AverageDraftPick", "MlbAmId", "Reliability", "MayberryMethod", "AverageDraftPickMax") VALUES ('c6ba6850-6017-4ab3-9090-81b83d046c5a', 5890, 2, 'Shane', 'Bieber', 27, 'CLE', 0, 24, 9999, 9999, 0.6666666666666666, 90, 0);
INSERT INTO public."Players" ("Id", "BhqId", "Type", "FirstName", "LastName", "Age", "Team", "Status", "AverageDraftPickMin", "AverageDraftPick", "MlbAmId", "Reliability", "MayberryMethod", "AverageDraftPickMax") VALUES ('ca82ac78-e3c3-4051-a15b-a70ef623d6c3', 5255, 2, 'Taylor', 'Rogers', 31, 'MIL', 0, 209, 9999, 9999, 0.6000000000000001, 54, 0);
INSERT INTO public."Players" ("Id", "BhqId", "Type", "FirstName", "LastName", "Age", "Team", "Status", "AverageDraftPickMin", "AverageDraftPick", "MlbAmId", "Reliability", "MayberryMethod", "AverageDraftPickMax") VALUES ('952984f5-7fb4-4a29-92a2-bd90a01c5cc3', 3955, 2, 'Matt', 'Bush', 36, 'MIL', 0, 9999, 9999, 9999, 0.20000000000000004, 16, 0);
INSERT INTO public."Players" ("Id", "BhqId", "Type", "FirstName", "LastName", "Age", "Team", "Status", "AverageDraftPickMin", "AverageDraftPick", "MlbAmId", "Reliability", "MayberryMethod", "AverageDraftPickMax") VALUES ('d0fc0a0d-2d4d-4040-89dd-d67ed85a69e9', 6724, 2, 'Jake', 'Cousins', 27, 'MIL', 0, 9999, 9999, 9999, 0.39999999999999997, 0, 0);
INSERT INTO public."Players" ("Id", "BhqId", "Type", "FirstName", "LastName", "Age", "Team", "Status", "AverageDraftPickMin", "AverageDraftPick", "MlbAmId", "Reliability", "MayberryMethod", "AverageDraftPickMax") VALUES ('d1df308b-1ea9-4419-8729-d2cac3753e6b', 6637, 1, 'Jonathan', 'India', 25, 'CIN', 0, 79, 9999, 9999, 1, 24, 0);
INSERT INTO public."Players" ("Id", "BhqId", "Type", "FirstName", "LastName", "Age", "Team", "Status", "AverageDraftPickMin", "AverageDraftPick", "MlbAmId", "Reliability", "MayberryMethod", "AverageDraftPickMax") VALUES ('c378cd4e-d49d-44fb-8b63-adb7abc1ff64', 5187, 2, 'Edwin', 'Diaz', 28, 'NYM', 0, 103, 9999, 9999, 0.8666666666666667, 54, 0);
INSERT INTO public."Players" ("Id", "BhqId", "Type", "FirstName", "LastName", "Age", "Team", "Status", "AverageDraftPickMin", "AverageDraftPick", "MlbAmId", "Reliability", "MayberryMethod", "AverageDraftPickMax") VALUES ('c4608bbb-dc81-4891-9775-78946407d39c', 4217, 1, 'Kolten', 'Wong', 31, 'MIL', 0, 188, 9999, 9999, 0.8000000000000002, 80, 0);
INSERT INTO public."Players" ("Id", "BhqId", "Type", "FirstName", "LastName", "Age", "Team", "Status", "AverageDraftPickMin", "AverageDraftPick", "MlbAmId", "Reliability", "MayberryMethod", "AverageDraftPickMax") VALUES ('dff2cb50-a73b-40df-bdc0-f229299769de', 6226, 2, 'Devin', 'Williams', 27, 'MIL', 0, 249, 9999, 9999, 0.5333333333333333, 34, 0);
INSERT INTO public."Players" ("Id", "BhqId", "Type", "FirstName", "LastName", "Age", "Team", "Status", "AverageDraftPickMin", "AverageDraftPick", "MlbAmId", "Reliability", "MayberryMethod", "AverageDraftPickMax") VALUES ('e0deb378-7f52-4742-a2f9-75ae12346db4', 5864, 2, 'Eric', 'Lauer', 27, 'MIL', 0, 322, 9999, 9999, 0.5333333333333333, 27, 0);
INSERT INTO public."Players" ("Id", "BhqId", "Type", "FirstName", "LastName", "Age", "Team", "Status", "AverageDraftPickMin", "AverageDraftPick", "MlbAmId", "Reliability", "MayberryMethod", "AverageDraftPickMax") VALUES ('e2f3a018-6216-43fa-a24c-96d5f6f61685', 6883, 1, 'Julio', 'Rodriguez', 21, 'SEA', 0, 356, 9999, 9999, 0.4666666666666666, 85, 0);
INSERT INTO public."Players" ("Id", "BhqId", "Type", "FirstName", "LastName", "Age", "Team", "Status", "AverageDraftPickMin", "AverageDraftPick", "MlbAmId", "Reliability", "MayberryMethod", "AverageDraftPickMax") VALUES ('eb338553-881b-45df-b252-70b47040b42c', 6578, 2, 'Ethan', 'Small', 25, 'MIL', 0, 9999, 9999, 9999, 0.4666666666666666, 0, 0);
INSERT INTO public."Players" ("Id", "BhqId", "Type", "FirstName", "LastName", "Age", "Team", "Status", "AverageDraftPickMin", "AverageDraftPick", "MlbAmId", "Reliability", "MayberryMethod", "AverageDraftPickMax") VALUES ('d017942e-c5f9-49bf-9fb7-dbd129dedcab', 6774, 1, 'Garrett', 'Mitchell', 23, 'MIL', 0, 9999, 9999, 9999, 0.4666666666666666, 0, 0);
INSERT INTO public."Players" ("Id", "BhqId", "Type", "FirstName", "LastName", "Age", "Team", "Status", "AverageDraftPickMin", "AverageDraftPick", "MlbAmId", "Reliability", "MayberryMethod", "AverageDraftPickMax") VALUES ('ebe41b0a-d144-4f3d-8c57-3b4f5300b44f', 6582, 1, 'Brice', 'Turang', 22, 'MIL', 0, 9999, 9999, 9999, 0, 0, 0);
INSERT INTO public."Players" ("Id", "BhqId", "Type", "FirstName", "LastName", "Age", "Team", "Status", "AverageDraftPickMin", "AverageDraftPick", "MlbAmId", "Reliability", "MayberryMethod", "AverageDraftPickMax") VALUES ('18fa5de6-e188-45f4-be68-f95140061639', 6581, 1, 'Mario', 'Feliciano', 23, 'MIL', 0, 9999, 9999, 9999, 0.4666666666666666, 0, 0);
INSERT INTO public."Players" ("Id", "BhqId", "Type", "FirstName", "LastName", "Age", "Team", "Status", "AverageDraftPickMin", "AverageDraftPick", "MlbAmId", "Reliability", "MayberryMethod", "AverageDraftPickMax") VALUES ('8d89ac4c-28ef-48bb-b6f4-b4bd7ae55022', 6142, 2, 'Andres', 'Munoz', 23, 'SEA', 0, 9999, 9999, 9999, 0.20000000000000004, 16, 0);
INSERT INTO public."Players" ("Id", "BhqId", "Type", "FirstName", "LastName", "Age", "Team", "Status", "AverageDraftPickMin", "AverageDraftPick", "MlbAmId", "Reliability", "MayberryMethod", "AverageDraftPickMax") VALUES ('e21028aa-5084-42b6-aa62-10cbcde98ce2', 6945, 1, 'Brett', 'Sullivan', 28, 'MIL', 0, 9999, 9999, 9999, 0, 0, 0);
INSERT INTO public."Players" ("Id", "BhqId", "Type", "FirstName", "LastName", "Age", "Team", "Status", "AverageDraftPickMin", "AverageDraftPick", "MlbAmId", "Reliability", "MayberryMethod", "AverageDraftPickMax") VALUES ('e9137344-a90c-4d35-be6f-cd3f435542eb', 6589, 1, 'Wander', 'Franco', 21, 'TB', 0, 44, 9999, 9999, 0.5333333333333333, 42, 0);
INSERT INTO public."Players" ("Id", "BhqId", "Type", "FirstName", "LastName", "Age", "Team", "Status", "AverageDraftPickMin", "AverageDraftPick", "MlbAmId", "Reliability", "MayberryMethod", "AverageDraftPickMax") VALUES ('e7d67172-ee82-4a30-9bb1-ff3d51285cf6', 6099, 2, 'Jordan', 'Romano', 29, 'TOR', 0, 140, 9999, 9999, 0.4666666666666666, 51, 0);
INSERT INTO public."Players" ("Id", "BhqId", "Type", "FirstName", "LastName", "Age", "Team", "Status", "AverageDraftPickMin", "AverageDraftPick", "MlbAmId", "Reliability", "MayberryMethod", "AverageDraftPickMax") VALUES ('e8774047-7ff9-43e7-b709-f7f66cb4def9', 5129, 1, 'Dansby', 'Swanson', 28, 'ATL', 0, 110, 9999, 9999, 0.9333333333333332, 60, 0);
INSERT INTO public."Players" ("Id", "BhqId", "Type", "FirstName", "LastName", "Age", "Team", "Status", "AverageDraftPickMin", "AverageDraftPick", "MlbAmId", "Reliability", "MayberryMethod", "AverageDraftPickMax") VALUES ('153215ee-f49a-4b7d-a910-72fa3a9d47cb', 4951, 2, 'Trevor', 'Gott', 29, 'MIL', 0, 9999, 9999, 9999, 0.3333333333333333, 0, 0);
INSERT INTO public."Players" ("Id", "BhqId", "Type", "FirstName", "LastName", "Age", "Team", "Status", "AverageDraftPickMin", "AverageDraftPick", "MlbAmId", "Reliability", "MayberryMethod", "AverageDraftPickMax") VALUES ('64583442-204f-4f02-b223-a397cdf09d90', 5351, 2, 'Jandel', 'Gustave', 29, 'MIL', 0, 9999, 9999, 9999, 0.4666666666666666, 0, 0);
INSERT INTO public."Players" ("Id", "BhqId", "Type", "FirstName", "LastName", "Age", "Team", "Status", "AverageDraftPickMin", "AverageDraftPick", "MlbAmId", "Reliability", "MayberryMethod", "AverageDraftPickMax") VALUES ('35601382-71e5-41c5-ba1e-542441107a98', 5072, 2, 'Jorge', 'Lopez', 29, 'MIN', 0, 9999, 9999, 9999, 0.8666666666666667, 42, 0);
INSERT INTO public."Players" ("Id", "BhqId", "Type", "FirstName", "LastName", "Age", "Team", "Status", "AverageDraftPickMin", "AverageDraftPick", "MlbAmId", "Reliability", "MayberryMethod", "AverageDraftPickMax") VALUES ('ed798f1a-0241-4b94-98a7-876fe949ee91', 4800, 1, 'Kyle', 'Schwarber', 29, 'PHI', 0, 90, 9999, 9999, 0.7333333333333334, 70, 0);
INSERT INTO public."Players" ("Id", "BhqId", "Type", "FirstName", "LastName", "Age", "Team", "Status", "AverageDraftPickMin", "AverageDraftPick", "MlbAmId", "Reliability", "MayberryMethod", "AverageDraftPickMax") VALUES ('ef0b95a8-da60-4c25-926d-cf60476821b0', 4775, 1, 'Christian', 'Walker', 31, 'ARZ', 0, 363, 9999, 9999, 0.8666666666666667, 65, 0);
INSERT INTO public."Players" ("Id", "BhqId", "Type", "FirstName", "LastName", "Age", "Team", "Status", "AverageDraftPickMin", "AverageDraftPick", "MlbAmId", "Reliability", "MayberryMethod", "AverageDraftPickMax") VALUES ('f2915b39-76e3-47d8-8dc3-44ce0ff4b793', 4784, 2, 'Aaron', 'Nola', 29, 'PHI', 0, 36, 9999, 9999, 0.8666666666666667, 95, 0);
INSERT INTO public."Players" ("Id", "BhqId", "Type", "FirstName", "LastName", "Age", "Team", "Status", "AverageDraftPickMin", "AverageDraftPick", "MlbAmId", "Reliability", "MayberryMethod", "AverageDraftPickMax") VALUES ('91ed9cb9-e41a-4214-85be-dc6f6cef224b', 6187, 2, 'Trevor', 'Kelley', 28, 'MIL', 0, 9999, 9999, 9999, 0.4666666666666666, 0, 0);
INSERT INTO public."Players" ("Id", "BhqId", "Type", "FirstName", "LastName", "Age", "Team", "Status", "AverageDraftPickMin", "AverageDraftPick", "MlbAmId", "Reliability", "MayberryMethod", "AverageDraftPickMax") VALUES ('f39e1057-9003-4ea5-9360-94c12b1cec69', 4611, 1, 'Jace', 'Peterson', 32, 'MIL', 0, 9999, 9999, 9999, 0.7999999999999999, 36, 0);
INSERT INTO public."Players" ("Id", "BhqId", "Type", "FirstName", "LastName", "Age", "Team", "Status", "AverageDraftPickMin", "AverageDraftPick", "MlbAmId", "Reliability", "MayberryMethod", "AverageDraftPickMax") VALUES ('1b6f447e-affe-4509-845a-09aadeba3b4c', 7015, 1, 'Esteury', 'Ruiz', 23, 'MIL', 0, 9999, 9999, 9999, 0.4666666666666666, 0, 0);
INSERT INTO public."Players" ("Id", "BhqId", "Type", "FirstName", "LastName", "Age", "Team", "Status", "AverageDraftPickMin", "AverageDraftPick", "MlbAmId", "Reliability", "MayberryMethod", "AverageDraftPickMax") VALUES ('392b9ad3-2e05-4496-965e-044013da057b', 5138, 2, 'Luis', 'Perdomo', 29, 'MIL', 0, 9999, 9999, 9999, 0.4666666666666666, 0, 0);
INSERT INTO public."Players" ("Id", "BhqId", "Type", "FirstName", "LastName", "Age", "Team", "Status", "AverageDraftPickMin", "AverageDraftPick", "MlbAmId", "Reliability", "MayberryMethod", "AverageDraftPickMax") VALUES ('4b264e78-617a-477e-8d27-177c878fec9a', 7024, 2, 'Peter', 'Strzelecki', 27, 'MIL', 0, 9999, 9999, 9999, 0.4666666666666666, 0, 0);
INSERT INTO public."Players" ("Id", "BhqId", "Type", "FirstName", "LastName", "Age", "Team", "Status", "AverageDraftPickMin", "AverageDraftPick", "MlbAmId", "Reliability", "MayberryMethod", "AverageDraftPickMax") VALUES ('f44be3eb-2a2b-476d-ac6f-27244bc47978', 5508, 1, 'Victor', 'Caratini', 28, 'MIL', 0, 9999, 9999, 9999, 0.8666666666666667, 21, 0);
INSERT INTO public."Players" ("Id", "BhqId", "Type", "FirstName", "LastName", "Age", "Team", "Status", "AverageDraftPickMin", "AverageDraftPick", "MlbAmId", "Reliability", "MayberryMethod", "AverageDraftPickMax") VALUES ('f774ff89-a188-4adb-a2ab-38186a60a609', 5006, 2, 'Blake', 'Snell', 29, 'SD', 0, 132, 9999, 9999, 0.7333333333333334, 14, 0);
INSERT INTO public."Players" ("Id", "BhqId", "Type", "FirstName", "LastName", "Age", "Team", "Status", "AverageDraftPickMin", "AverageDraftPick", "MlbAmId", "Reliability", "MayberryMethod", "AverageDraftPickMax") VALUES ('0035735d-c42e-43da-8ae2-fbc476692203', 7020, 2, 'Luke', 'Barker', 30, 'MIL', 0, 9999, 9999, 9999, 0.4666666666666666, 0, 0);
INSERT INTO public."Players" ("Id", "BhqId", "Type", "FirstName", "LastName", "Age", "Team", "Status", "AverageDraftPickMin", "AverageDraftPick", "MlbAmId", "Reliability", "MayberryMethod", "AverageDraftPickMax") VALUES ('010ae0a2-84ee-48cf-9cf7-8a2ec508cc33', 5988, 1, 'Jonathan', 'Davis', 30, 'MIL', 0, 9999, 9999, 9999, 0.4666666666666666, 0, 0);
INSERT INTO public."Players" ("Id", "BhqId", "Type", "FirstName", "LastName", "Age", "Team", "Status", "AverageDraftPickMin", "AverageDraftPick", "MlbAmId", "Reliability", "MayberryMethod", "AverageDraftPickMax") VALUES ('62795f8a-bdf9-433c-86f0-ee63d2ba9fb6', 7023, 2, 'Jason', 'Alexander', 29, 'MIL', 0, 9999, 9999, 9999, 0.4666666666666666, 3, 0);
INSERT INTO public."Players" ("Id", "BhqId", "Type", "FirstName", "LastName", "Age", "Team", "Status", "AverageDraftPickMin", "AverageDraftPick", "MlbAmId", "Reliability", "MayberryMethod", "AverageDraftPickMax") VALUES ('faccb3da-4eca-413e-b119-930b7ae8f76e', 5831, 2, 'A.J.', 'Puk', 27, 'OAK', 0, 9999, 9999, 9999, 0.20000000000000004, 13, 0);


--
-- TOC entry 3356 (class 0 OID 16400)
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
-- TOC entry 3357 (class 0 OID 16403)
-- Dependencies: 215
-- Data for Name: __EFMigrationsHistory; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public."__EFMigrationsHistory" ("MigrationId", "ProductVersion") VALUES ('20200513041941_InitialCreate', '3.1.3');
INSERT INTO public."__EFMigrationsHistory" ("MigrationId", "ProductVersion") VALUES ('20221101060806_RemovePosition', '6.0.5');
INSERT INTO public."__EFMigrationsHistory" ("MigrationId", "ProductVersion") VALUES ('20221114075540_RenameTeams', '6.0.5');
INSERT INTO public."__EFMigrationsHistory" ("MigrationId", "ProductVersion") VALUES ('20221213065028_increase-pos-size', '8.0.2');
INSERT INTO public."__EFMigrationsHistory" ("MigrationId", "ProductVersion") VALUES ('20240222173322_team-alt-codes', '8.0.2');
INSERT INTO public."__EFMigrationsHistory" ("MigrationId", "ProductVersion") VALUES ('20240404202243_NewBhqFields', '8.0.2');


--
-- TOC entry 3191 (class 2606 OID 16407)
-- Name: BattingStats BattingStats_PK; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."BattingStats"
    ADD CONSTRAINT "BattingStats_PK" PRIMARY KEY ("PlayerId", "StatsType");


--
-- TOC entry 3193 (class 2606 OID 16409)
-- Name: LeagueStatuses LeagueStatus_PK; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."LeagueStatuses"
    ADD CONSTRAINT "LeagueStatus_PK" PRIMARY KEY ("PlayerId", "LeagueId");


--
-- TOC entry 3197 (class 2606 OID 16449)
-- Name: PlayerPositionEntity PK_PlayerPositionEntity; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."PlayerPositionEntity"
    ADD CONSTRAINT "PK_PlayerPositionEntity" PRIMARY KEY ("PlayerId", "PositionCode");


--
-- TOC entry 3206 (class 2606 OID 16413)
-- Name: __EFMigrationsHistory PK___EFMigrationsHistory; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."__EFMigrationsHistory"
    ADD CONSTRAINT "PK___EFMigrationsHistory" PRIMARY KEY ("MigrationId");


--
-- TOC entry 3195 (class 2606 OID 16415)
-- Name: PitchingStats PitchingStats_PK; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."PitchingStats"
    ADD CONSTRAINT "PitchingStats_PK" PRIMARY KEY ("PlayerId", "StatsType");


--
-- TOC entry 3200 (class 2606 OID 16417)
-- Name: Players Player_Bhq_AK; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Players"
    ADD CONSTRAINT "Player_Bhq_AK" UNIQUE ("BhqId", "Type");


--
-- TOC entry 3202 (class 2606 OID 16419)
-- Name: Players Player_PK; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Players"
    ADD CONSTRAINT "Player_PK" PRIMARY KEY ("Id");


--
-- TOC entry 3204 (class 2606 OID 16421)
-- Name: Teams Team_PK; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Teams"
    ADD CONSTRAINT "Team_PK" PRIMARY KEY ("Code");


--
-- TOC entry 3198 (class 1259 OID 16422)
-- Name: IX_Players_Team; Type: INDEX; Schema: public; Owner: postgres
--

CREATE INDEX "IX_Players_Team" ON public."Players" USING btree ("Team");


--
-- TOC entry 3207 (class 2606 OID 16423)
-- Name: BattingStats BattingStats_Player_FK; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."BattingStats"
    ADD CONSTRAINT "BattingStats_Player_FK" FOREIGN KEY ("PlayerId") REFERENCES public."Players"("Id") ON DELETE CASCADE;


--
-- TOC entry 3208 (class 2606 OID 16428)
-- Name: LeagueStatuses LeagueStatus_Player_FK; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."LeagueStatuses"
    ADD CONSTRAINT "LeagueStatus_Player_FK" FOREIGN KEY ("PlayerId") REFERENCES public."Players"("Id") ON DELETE CASCADE;


--
-- TOC entry 3209 (class 2606 OID 16433)
-- Name: PitchingStats PitchingStats_Player_FK; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."PitchingStats"
    ADD CONSTRAINT "PitchingStats_Player_FK" FOREIGN KEY ("PlayerId") REFERENCES public."Players"("Id") ON DELETE CASCADE;


--
-- TOC entry 3210 (class 2606 OID 16438)
-- Name: PlayerPositionEntity PlayerPosition_Player_FK; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."PlayerPositionEntity"
    ADD CONSTRAINT "PlayerPosition_Player_FK" FOREIGN KEY ("PlayerId") REFERENCES public."Players"("Id") ON DELETE CASCADE;


--
-- TOC entry 3211 (class 2606 OID 16443)
-- Name: Players Player_Team_FK; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Players"
    ADD CONSTRAINT "Player_Team_FK" FOREIGN KEY ("Team") REFERENCES public."Teams"("Code");


-- Completed on 2024-04-04 21:43:37 UTC

--
-- PostgreSQL database dump complete
--

