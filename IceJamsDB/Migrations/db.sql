CREATE SCHEMA IF NOT EXISTS icejam;
CREATE TABLE IF NOT EXISTS icejam."_EFMigrationsHistory" (
    "MigrationId" character varying(150) NOT NULL,
    "ProductVersion" character varying(32) NOT NULL,
    CONSTRAINT "PK__EFMigrationsHistory" PRIMARY KEY ("MigrationId")
);

CREATE SCHEMA IF NOT EXISTS icejam;

CREATE EXTENSION IF NOT EXISTS postgis;

CREATE TABLE icejam."Agencies" (
    "ID" serial NOT NULL,
    "Name" text NOT NULL,
    "Description" text NOT NULL,
    "Abbreviation" character varying(6) NOT NULL,
    "LastModified" timestamp without time zone NOT NULL,
    CONSTRAINT "PK_Agencies" PRIMARY KEY ("ID")
);

CREATE TABLE icejam."DamageTypes" (
    "ID" serial NOT NULL,
    "Name" text NOT NULL,
    "Description" text NOT NULL,
    "ExampleImageURL" text NULL,
    CONSTRAINT "PK_DamageTypes" PRIMARY KEY ("ID")
);

CREATE TABLE icejam."FileTypes" (
    "ID" serial NOT NULL,
    "Name" text NOT NULL,
    "Description" text NOT NULL,
    CONSTRAINT "PK_FileTypes" PRIMARY KEY ("ID")
);

CREATE TABLE icejam."IceConditionTypes" (
    "ID" serial NOT NULL,
    "Name" text NOT NULL,
    "Description" text NOT NULL,
    CONSTRAINT "PK_IceConditionTypes" PRIMARY KEY ("ID")
);

CREATE TABLE icejam."JamTypes" (
    "ID" serial NOT NULL,
    "Name" text NOT NULL,
    "Description" text NOT NULL,
    "ExampleImageURL" text NULL,
    CONSTRAINT "PK_JamTypes" PRIMARY KEY ("ID")
);

CREATE TABLE icejam."RiverConditionTypes" (
    "ID" serial NOT NULL,
    "Name" text NOT NULL,
    "Description" text NOT NULL,
    CONSTRAINT "PK_RiverConditionTypes" PRIMARY KEY ("ID")
);

CREATE TABLE icejam."Roles" (
    "ID" serial NOT NULL,
    "Name" text NOT NULL,
    "Description" text NOT NULL,
    "LastModified" timestamp without time zone NOT NULL,
    CONSTRAINT "PK_Roles" PRIMARY KEY ("ID")
);

CREATE TABLE icejam."RoughnessTypes" (
    "ID" serial NOT NULL,
    "Name" text NOT NULL,
    "Description" text NOT NULL,
    CONSTRAINT "PK_RoughnessTypes" PRIMARY KEY ("ID")
);

CREATE TABLE icejam."Sites" (
    "ID" serial NOT NULL,
    "Name" text NOT NULL,
    "Location" geometry NOT NULL,
    "State" text NOT NULL,
    "County" text NOT NULL,
    "RiverName" text NOT NULL,
    "HUC" text NULL,
    "USGSID" text NULL,
    "AHPSID" text NULL,
    "Comments" text NULL,
    "Landmarks" text NULL,
    "LastModified" timestamp without time zone NOT NULL,
    CONSTRAINT "PK_Sites" PRIMARY KEY ("ID")
);

CREATE TABLE icejam."StageTypes" (
    "ID" serial NOT NULL,
    "Name" text NOT NULL,
    "Description" text NOT NULL,
    CONSTRAINT "PK_StageTypes" PRIMARY KEY ("ID")
);

CREATE TABLE icejam."WeatherConditionTypes" (
    "ID" serial NOT NULL,
    "Name" text NOT NULL,
    "Description" text NOT NULL,
    CONSTRAINT "PK_WeatherConditionTypes" PRIMARY KEY ("ID")
);

CREATE TABLE icejam."Observers" (
    "ID" serial NOT NULL,
    "FirstName" text NOT NULL,
    "LastName" text NOT NULL,
    "Username" text NOT NULL,
    "Email" text NOT NULL,
    "PrimaryPhone" text NULL,
    "SecondaryPhone" text NULL,
    "AgencyID" integer NULL,
    "RoleID" integer NOT NULL,
    "OtherInfo" text NULL,
    "Password" text NOT NULL,
    "Salt" text NOT NULL,
    "LastModified" timestamp without time zone NOT NULL,
    CONSTRAINT "PK_Observers" PRIMARY KEY ("ID"),
    CONSTRAINT "FK_Observers_Agencies_AgencyID" FOREIGN KEY ("AgencyID") REFERENCES icejam."Agencies" ("ID") ON DELETE RESTRICT,
    CONSTRAINT "FK_Observers_Roles_RoleID" FOREIGN KEY ("RoleID") REFERENCES icejam."Roles" ("ID") ON DELETE RESTRICT
);

CREATE TABLE icejam."IceJams" (
    "ID" serial NOT NULL,
    "ObservationDateTime" timestamp without time zone NOT NULL,
    "JamTypeID" integer NOT NULL,
    "SiteID" integer NOT NULL,
    "ObserverID" integer NOT NULL,
    "Description" text NOT NULL,
    "Comments" text NULL,
    "LastModified" timestamp without time zone NOT NULL,
    CONSTRAINT "PK_IceJams" PRIMARY KEY ("ID"),
    CONSTRAINT "FK_IceJams_JamTypes_JamTypeID" FOREIGN KEY ("JamTypeID") REFERENCES icejam."JamTypes" ("ID") ON DELETE RESTRICT,
    CONSTRAINT "FK_IceJams_Observers_ObserverID" FOREIGN KEY ("ObserverID") REFERENCES icejam."Observers" ("ID") ON DELETE RESTRICT,
    CONSTRAINT "FK_IceJams_Sites_SiteID" FOREIGN KEY ("SiteID") REFERENCES icejam."Sites" ("ID") ON DELETE RESTRICT
);

CREATE TABLE icejam."Damages" (
    "ID" serial NOT NULL,
    "IceJamID" integer NOT NULL,
    "DamageTypeID" integer NOT NULL,
    "DateTimeReported" timestamp without time zone NOT NULL,
    "Description" text NOT NULL,
    "LastModified" timestamp without time zone NOT NULL,
    CONSTRAINT "PK_Damages" PRIMARY KEY ("ID"),
    CONSTRAINT "FK_Damages_DamageTypes_DamageTypeID" FOREIGN KEY ("DamageTypeID") REFERENCES icejam."DamageTypes" ("ID") ON DELETE RESTRICT,
    CONSTRAINT "FK_Damages_IceJams_IceJamID" FOREIGN KEY ("IceJamID") REFERENCES icejam."IceJams" ("ID") ON DELETE CASCADE
);

CREATE TABLE icejam."IceConditions" (
    "ID" serial NOT NULL,
    "IceJamID" integer NOT NULL,
    "DateTime" timestamp without time zone NOT NULL,
    "IceConditionTypeID" integer NOT NULL,
    "Measurement" double precision NOT NULL,
    "IsEstimated" boolean NULL,
    "IsChanging" boolean NULL,
    "Comments" text NULL,
    "UpstreamEndLocation" geometry NULL,
    "DownstreamEndLocation" geometry NULL,
    "RoughnessTypeID" integer NULL,
    "LastModified" timestamp without time zone NOT NULL,
    CONSTRAINT "PK_IceConditions" PRIMARY KEY ("ID"),
    CONSTRAINT "FK_IceConditions_IceConditionTypes_IceConditionTypeID" FOREIGN KEY ("IceConditionTypeID") REFERENCES icejam."IceConditionTypes" ("ID") ON DELETE RESTRICT,
    CONSTRAINT "FK_IceConditions_IceJams_IceJamID" FOREIGN KEY ("IceJamID") REFERENCES icejam."IceJams" ("ID") ON DELETE CASCADE,
    CONSTRAINT "FK_IceConditions_RoughnessTypes_RoughnessTypeID" FOREIGN KEY ("RoughnessTypeID") REFERENCES icejam."RoughnessTypes" ("ID") ON DELETE RESTRICT
);

CREATE TABLE icejam."RiverConditions" (
    "ID" serial NOT NULL,
    "IceJamID" integer NOT NULL,
    "DateTime" timestamp without time zone NOT NULL,
    "RiverConditionTypeID" integer NOT NULL,
    "IsFlooding" boolean NULL,
    "StageTypeID" integer NULL,
    "Measurement" double precision NULL,
    "IsChanging" boolean NULL,
    "Comments" text NULL,
    "LastModified" timestamp without time zone NOT NULL,
    CONSTRAINT "PK_RiverConditions" PRIMARY KEY ("ID"),
    CONSTRAINT "FK_RiverConditions_IceJams_IceJamID" FOREIGN KEY ("IceJamID") REFERENCES icejam."IceJams" ("ID") ON DELETE CASCADE,
    CONSTRAINT "FK_RiverConditions_RiverConditionTypes_RiverConditionTypeID" FOREIGN KEY ("RiverConditionTypeID") REFERENCES icejam."RiverConditionTypes" ("ID") ON DELETE RESTRICT,
    CONSTRAINT "FK_RiverConditions_StageTypes_StageTypeID" FOREIGN KEY ("StageTypeID") REFERENCES icejam."StageTypes" ("ID") ON DELETE RESTRICT
);

CREATE TABLE icejam."WeatherConditions" (
    "ID" serial NOT NULL,
    "IceJamID" integer NOT NULL,
    "DateTime" timestamp without time zone NOT NULL,
    "WeatherConditionTypeID" integer NOT NULL,
    "Measurement" double precision NOT NULL,
    "IsEstimated" boolean NULL,
    "IsChanging" boolean NULL,
    "Comments" text NULL,
    "LastModified" timestamp without time zone NOT NULL,
    CONSTRAINT "PK_WeatherConditions" PRIMARY KEY ("ID"),
    CONSTRAINT "FK_WeatherConditions_IceJams_IceJamID" FOREIGN KEY ("IceJamID") REFERENCES icejam."IceJams" ("ID") ON DELETE CASCADE,
    CONSTRAINT "FK_WeatherConditions_WeatherConditionTypes_WeatherConditionTyp~" FOREIGN KEY ("WeatherConditionTypeID") REFERENCES icejam."WeatherConditionTypes" ("ID") ON DELETE RESTRICT
);

CREATE TABLE icejam."Files" (
    "ID" serial NOT NULL,
    "FileTypeID" integer NOT NULL,
    "URL" text NOT NULL,
    "Description" text NOT NULL,
    "IceJamID" integer NOT NULL,
    "DamageID" integer NULL,
    "LastModified" timestamp without time zone NOT NULL,
    CONSTRAINT "PK_Files" PRIMARY KEY ("ID"),
    CONSTRAINT "FK_Files_Damages_DamageID" FOREIGN KEY ("DamageID") REFERENCES icejam."Damages" ("ID") ON DELETE RESTRICT,
    CONSTRAINT "FK_Files_FileTypes_FileTypeID" FOREIGN KEY ("FileTypeID") REFERENCES icejam."FileTypes" ("ID") ON DELETE RESTRICT,
    CONSTRAINT "FK_Files_IceJams_IceJamID" FOREIGN KEY ("IceJamID") REFERENCES icejam."IceJams" ("ID") ON DELETE CASCADE
);

CREATE INDEX "IX_Damages_DamageTypeID" ON icejam."Damages" ("DamageTypeID");

CREATE INDEX "IX_Damages_IceJamID" ON icejam."Damages" ("IceJamID");

CREATE UNIQUE INDEX "IX_DamageTypes_Name" ON icejam."DamageTypes" ("Name");

CREATE INDEX "IX_Files_DamageID" ON icejam."Files" ("DamageID");

CREATE INDEX "IX_Files_FileTypeID" ON icejam."Files" ("FileTypeID");

CREATE INDEX "IX_Files_IceJamID" ON icejam."Files" ("IceJamID");

CREATE UNIQUE INDEX "IX_FileTypes_Name" ON icejam."FileTypes" ("Name");

CREATE INDEX "IX_IceConditions_IceConditionTypeID" ON icejam."IceConditions" ("IceConditionTypeID");

CREATE INDEX "IX_IceConditions_IceJamID" ON icejam."IceConditions" ("IceJamID");

CREATE INDEX "IX_IceConditions_RoughnessTypeID" ON icejam."IceConditions" ("RoughnessTypeID");

CREATE UNIQUE INDEX "IX_IceConditionTypes_Name" ON icejam."IceConditionTypes" ("Name");

CREATE INDEX "IX_IceJams_JamTypeID" ON icejam."IceJams" ("JamTypeID");

CREATE INDEX "IX_IceJams_ObserverID" ON icejam."IceJams" ("ObserverID");

CREATE INDEX "IX_IceJams_SiteID" ON icejam."IceJams" ("SiteID");

CREATE UNIQUE INDEX "IX_JamTypes_Name" ON icejam."JamTypes" ("Name");

CREATE INDEX "IX_Observers_AgencyID" ON icejam."Observers" ("AgencyID");

CREATE INDEX "IX_Observers_RoleID" ON icejam."Observers" ("RoleID");

CREATE UNIQUE INDEX "IX_Observers_Username" ON icejam."Observers" ("Username");

CREATE INDEX "IX_RiverConditions_IceJamID" ON icejam."RiverConditions" ("IceJamID");

CREATE INDEX "IX_RiverConditions_RiverConditionTypeID" ON icejam."RiverConditions" ("RiverConditionTypeID");

CREATE INDEX "IX_RiverConditions_StageTypeID" ON icejam."RiverConditions" ("StageTypeID");

CREATE UNIQUE INDEX "IX_RiverConditionTypes_Name" ON icejam."RiverConditionTypes" ("Name");

CREATE UNIQUE INDEX "IX_RoughnessTypes_Name" ON icejam."RoughnessTypes" ("Name");

CREATE UNIQUE INDEX "IX_StageTypes_Name" ON icejam."StageTypes" ("Name");

CREATE INDEX "IX_WeatherConditions_IceJamID" ON icejam."WeatherConditions" ("IceJamID");

CREATE INDEX "IX_WeatherConditions_WeatherConditionTypeID" ON icejam."WeatherConditions" ("WeatherConditionTypeID");


                CREATE OR REPLACE FUNCTION "icejam"."trigger_set_lastmodified"()
                    RETURNS TRIGGER AS $$
                    BEGIN
                      NEW."LastModified" = NOW();
                      RETURN NEW;
                    END;
                    $$ LANGUAGE plpgsql;
                


                CREATE TRIGGER lastupdate BEFORE INSERT OR UPDATE ON "Files"  FOR EACH ROW EXECUTE PROCEDURE "icejam"."trigger_set_lastmodified"();
                CREATE TRIGGER lastupdate BEFORE INSERT OR UPDATE ON "IceConditions"  FOR EACH ROW EXECUTE PROCEDURE "icejam"."trigger_set_lastmodified"();
                CREATE TRIGGER lastupdate BEFORE INSERT OR UPDATE ON  "RiverConditions" FOR EACH ROW EXECUTE PROCEDURE  "icejam"."trigger_set_lastmodified"();
                CREATE TRIGGER lastupdate BEFORE INSERT OR UPDATE ON "WeatherConditions"  FOR EACH ROW EXECUTE PROCEDURE "icejam"."trigger_set_lastmodified"();
                CREATE TRIGGER lastupdate BEFORE INSERT OR UPDATE ON  "Damages" FOR EACH ROW EXECUTE PROCEDURE  "icejam"."trigger_set_lastmodified"();
                CREATE TRIGGER lastupdate BEFORE INSERT OR UPDATE ON "IceJams"  FOR EACH ROW EXECUTE PROCEDURE "icejam"."trigger_set_lastmodified"();
                CREATE TRIGGER lastupdate BEFORE INSERT OR UPDATE ON  "Observers" FOR EACH ROW EXECUTE PROCEDURE  "icejam"."trigger_set_lastmodified"();
                CREATE TRIGGER lastupdate BEFORE INSERT OR UPDATE ON  "Sites" FOR EACH ROW EXECUTE PROCEDURE  "icejam"."trigger_set_lastmodified"();
                CREATE TRIGGER lastupdate BEFORE INSERT OR UPDATE ON "Agencies" FOR  EACH ROW EXECUTE PROCEDURE "icejam"."trigger_set_lastmodified"();
                CREATE TRIGGER lastupdate BEFORE INSERT OR UPDATE ON "Roles"  FOR EACH ROW EXECUTE PROCEDURE "icejam"."trigger_set_lastmodified"();
                

INSERT INTO icejam."_EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20181213165158_init', '2.2.0-rtm-35687');

