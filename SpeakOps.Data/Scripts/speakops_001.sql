SET statement_timeout = 0;
SET lock_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SET check_function_bodies = false;
SET client_min_messages = warning;
SET row_security = off;

CREATE SCHEMA speakops;
ALTER SCHEMA speakops OWNER TO postgres;

SET search_path = speakops, pg_catalog;
SET default_tablespace = '';
SET default_with_oids = false;

CREATE TABLE meetups (
    id serial NOT NULL,
    location point NOT NULL,
    city character varying(58) NOT NULL,
    country character varying(36) NOT NULL,
    name character varying(100) NOT NULL,
    email character varying(254),
    twitter character varying(35),
    website character varying(2000),
    speakerpack character varying(2000),
    travelandexpenses boolean NOT NULL,
    callforproposals character varying(2000)
);

ALTER TABLE meetups OWNER TO postgres;

CREATE TABLE organisers (
    id serial NOT NULL,
    name character varying(100) NOT NULL,
    twitter character varying(35)
);

ALTER TABLE organisers OWNER TO postgres;

CREATE TABLE organisers_meetups (
    id serial NOT NULL,
    organiserid integer NOT NULL,
    meetupid integer NOT NULL
);

ALTER TABLE organisers_meetups OWNER TO postgres;

CREATE TABLE topics (
    id serial NOT NULL,
    name character varying(100) NOT NULL
);

ALTER TABLE topics OWNER TO postgres;

CREATE TABLE topics_meetups (
    id serial NOT NULL,
    topicid integer NOT NULL,
    meetupid integer NOT NULL
);

ALTER TABLE topics_meetups OWNER TO postgres;

ALTER TABLE ONLY meetups
    ADD CONSTRAINT meetups_pkey PRIMARY KEY (id);

ALTER TABLE ONLY organisers_meetups
    ADD CONSTRAINT organisers_meetups_pkey PRIMARY KEY (id);

ALTER TABLE ONLY organisers
    ADD CONSTRAINT organisers_pkey PRIMARY KEY (id);

ALTER TABLE ONLY topics_meetups
    ADD CONSTRAINT topics_meetups_pkey PRIMARY KEY (id);

ALTER TABLE ONLY topics
    ADD CONSTRAINT topics_pkey PRIMARY KEY (id);