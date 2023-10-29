﻿using System.Linq;
using System.Collections.Generic;

namespace Kusto.Language
{
    using Syntax;

    public static partial class KustoFacts
    {
        /// <summary>
        /// Known identifier-like keywords from all sources (query and all control commands) 
        /// that are not specifically enabled to be identifiers everywhere.
        /// </summary>
        private static readonly HashSet<string> s_engineCommandKeywordsThatNeedBrackets = new HashSet<string>()
        {
            "__unique",
            "accumulate",
            "and",
            "application",
            "as",
            "asc",
            "between",
            "blockedprincipals",
            "boolean",
            "by",
            "byte",
            "bytes",
            "cachingpolicy",
            "callout",
            "callstacks",
            "cancel",
            "char",
            "concurrency",
            "configuration",
            "consume",
            "container",
            "containers",
            "contains",
            "count",
            "dataexport",
            "datasize",
            "datastats",
            "datatable",
            "date",
            "datetime",
            "datetime_pattern",
            "days",
            "decimal",
            "desc",
            "dimensions",
            "disabled",
            "distinct",
            "double",
            "dryrun",
            "dynamic",
            "earliest",
            "empty",
            "enabled",
            "encodingpolicy",
            "entity_group",
            "exclude",
            "expired_tables_cleanup",
            "extend",
            "extent_tags_retention",
            "extentsize",
            "external_data",
            "externaldata",
            "filter",
            "find",
            "first",
            "flags",
            "float",
            "follower",
            "for",
            "format_datetime",
            "GB",
            "getschema",
            "harddelete",
            "hardretention",
            "has",
            "has_all",
            "has_any",
            "hot_window",
            "identity",
            "in",
            "include",
            "int",
            "int16",
            "int32",
            "int64",
            "int8",
            "invoke",
            "journal",
            "kind",
            "last",
            "latest",
            "limit",
            "long",
            "materialize",
            "MB",
            "mdm",
            "missing",
            "mvapply",
            "mvexpand",
            "network",
            "of",
            "or",
            "order",
            "others",
            "parse",
            "pathformat",
            "print",
            "project",
            "queries",
            "query_results",
            "real",
            "recoverability",
            "restricted_view_access",
            "row_level_security",
            "rowstore",
            "rowstore_references",
            "rowstore_sealinfo",
            "rowstorepolicy",
            "rowstores",
            "sample",
            "scan",
            "seal",
            "seals",
            "search",
            "serialize",
            "set",
            "shards",
            "softdelete",
            "softretention",
            "sort",
            "sql",
            "startofday",
            "startofmonth",
            "startofweek",
            "startofyear",
            "statistics",
            "stored_query_result",
            "stored_query_results",
            "storedqueryresultcontainers",
            "string",
            "summarize",
            "tablepurge",
            "take",
            "time",
            "timespan",
            "title",
            "to",
            "top",
            "toscalar",
            "totable",
            "transactions",
            "trim",
            "uint",
            "uint16",
            "uint32",
            "uint64",
            "uint8",
            "ulong",
            "union",
            "uniqueid",
            "unrestrictedviewers",
            "until",
            "unused",
            "utilization",
            "verbose",
            "viewers",
            "views",
            "violations",
            "where",
            "writeaheadlog"
        };

        private static readonly HashSet<string> s_dataManagerCommandKeywordsThatNeedBrackets = new HashSet<string>()
        {
            "accounts",
            "add",
            "admin",
            "admins",
            "aggregator",
            "all",
            "allrecords",
            "alter",
            "aria",
            "Aria",
            "as",
            "bridge",
            "cache",
            "cancel",
            "clear",
            "cloudsettings",
            "cluster",
            "common",
            "completion",
            "connections",
            "containers",
            "cors",
            "cosmosdb",
            "CosmosDb",
            "create",
            "credstore",
            "critical",
            "data",
            "database",
            "deadletter",
            "delete",
            "details",
            "diagnostics",
            "disable",
            "dnshostname",
            "drop",
            "dryRun",
            "echo",
            "enable",
            "encrypted",
            "error",
            "eventgrid",
            "EventGrid",
            "eventhub",
            "EventHub",
            "export",
            "fabric",
            "featureflags",
            "force",
            "from",
            "gds",
            "geneva",
            "Geneva",
            "get",
            "gracefully",
            "hash",
            "health",
            "identity",
            "immediately",
            "in",
            "info",
            "ingestion",
            "ingestionbatchingpolicy",
            "ingestions",
            "ingestors",
            "json",
            "keys",
            "kusto",
            "lagging",
            "legacy",
            "lengths",
            "load",
            "lock",
            "maintenance",
            "management",
            "mdsaccounts",
            "MdsAccounts",
            "migrate",
            "mode",
            "monitoring",
            "obtainer",
            "obtainers",
            "ops",
            "pause",
            "policy",
            "principal",
            "principals",
            "process",
            "properties",
            "purge",
            "purges",
            "query",
            "queue",
            "queues",
            "records",
            "recreate",
            "refresh",
            "regions",
            "remotestorage",
            "replace",
            "resources",
            "resume",
            "retention",
            "retry",
            "roles",
            "scale",
            "schema",
            "secondary",
            "secrets",
            "service",
            "services",
            "set",
            "settings",
            "show",
            "source",
            "sources",
            "staging",
            "state",
            "status",
            "statusreporter",
            "StatusReporter",
            "stop",
            "storage",
            "suspend",
            "table",
            "tables",
            "tempstorage",
            "to",
            "token",
            "trace",
            "types",
            "uri",
            "users",
            "verbose",
            "version",
            "versions",
            "virtualdm",
            "virtualdms",
            "warning",
            "with",
            "withsas"
        };

        private static readonly HashSet<string> s_clusterManagerCommandKeywordsThatNeedBrackets = new HashSet<string>()
        {
            "aad",
            "accessLevel",
            "account",
            "accounts",
            "add",
            "AdditionalEncryptionCertificatesThumbprints",
            "AdditionalSubscriptions",
            "admin",
            "admins",
            "all",
            "allChanges",
            "alldatabasesadmins",
            "alldatabasesmonitors",
            "alldatabasesviewers",
            "allexecutions",
            "allocate",
            "allrecords",
            "alter",
            "ame",
            "applynow",
            "arm",
            "armaccess",
            "artifactId",
            "as",
            "assign",
            "assistantsettings",
            "async",
            "AttachedDatabasesSettings",
            "audit",
            "auto",
            "AutomaticallyDetachCorruptDatabases",
            "AutomaticOSUpgradePolicy",
            "AutoscaleSetting",
            "availability",
            "azure",
            "balancer",
            "billing",
            "BillingSettings",
            "Bridge",
            "buildout",
            "by",
            "cancel",
            "capacity",
            "capacityId",
            "cdbCommands",
            "certificate",
            "changes",
            "check",
            "checkPrettyName",
            "client",
            "clientactivityid",
            "cloud",
            "cloudsettings",
            "cluster",
            "clusteridmap",
            "ClusterManagement",
            "clustermanagementsettings",
            "clusters",
            "cm",
            "command",
            "common",
            "completed",
            "ComputeSubscriptionId",
            "configuration",
            "configurations",
            "configure",
            "connection",
            "connections",
            "consent",
            "contact",
            "contacts",
            "container",
            "copy",
            "corp",
            "corrupted",
            "cosmosdb",
            "create",
            "critical",
            "CurrentEncryptionCertificateThumbprint",
            "CustomerType",
            "dashboard",
            "DashboardSettings",
            "data",
            "database",
            "databases",
            "DatabaseScriptSettings",
            "DataManagement",
            "deadletter",
            "dedicated",
            "default",
            "definitions",
            "delete",
            "deploy",
            "deployment",
            "DeploymentFreezeEnabled",
            "DeploymentFreezeExpiresOn",
            "DeploymentKind",
            "DeploymentRing",
            "deployments",
            "detach",
            "details",
            "diagnose",
            "diagnostic",
            "diagnostics",
            "directly",
            "disk",
            "DiskCacheFreeBufferPermille",
            "DiskCacheShardsPercentage",
            "DiskColdAllocationPercentage",
            "division",
            "DlockStorageAccountsCurrentKeyInUse",
            "dm",
            "dns",
            "DoNotCreateIcmIncidents",
            "DoNotDeploy",
            "DoNotDeployRunners",
            "DoNotRegisterDnsMapping",
            "drop",
            "dsc",
            "echo",
            "emergency",
            "EnableDiskEncryption",
            "EnableOsEphemeralDisk",
            "EnableStreamingIngest",
            "encrypted",
            "encryption",
            "endpoint",
            "Engine",
            "Environment",
            "ephemeral",
            "error",
            "Error",
            "eventgrid",
            "eventhub",
            "except",
            "excludeVirtualClusters",
            "execute",
            "expirationTimeInMinutes",
            "export",
            "extents",
            "external",
            "fabric",
            "fabriclocks",
            "failed",
            "false",
            "Fatal",
            "FaultDomainCount",
            "feature",
            "FeatureFlags",
            "flags",
            "Flighting",
            "FlightingSettings",
            "followed",
            "follower",
            "followers",
            "following",
            "for",
            "forceApply",
            "forcerefresh",
            "from",
            "Gaia",
            "GaiaSettings",
            "generate",
            "geneva",
            "get",
            "grant",
            "group",
            "hash",
            "HealthSuite",
            "HealthSuiteSettings",
            "history",
            "hoster",
            "hosters",
            "id",
            "ids",
            "ifNotExists",
            "ImageSku",
            "in",
            "inbound",
            "info",
            "Info",
            "information",
            "ingest",
            "ingestion",
            "ingestors",
            "install",
            "InstalledEncryptionCertificatesThumbprints",
            "InstancesCount",
            "into",
            "invitation",
            "IsDevSku",
            "IsInPreview",
            "jitmanagers",
            "job",
            "jobGroup",
            "json",
            "key",
            "keys",
            "keyvault",
            "KeyVaultName",
            "kustopool",
            "kustopools",
            "LanguageExtensions",
            "leader",
            "leftover",
            "level",
            "limits",
            "list",
            "load",
            "local",
            "log",
            "logs",
            "maintenance",
            "MaintenanceWindows",
            "ManagedDisksProperties",
            "managedPrivateEndpoint",
            "manifest",
            "MemoryColdAllocationPercentage",
            "metadata",
            "metrics",
            "migrate",
            "migration",
            "mock",
            "model",
            "monitor",
            "monitoring",
            "MonitoringAccount",
            "monitors",
            "move",
            "MsiIdentitySettings",
            "name",
            "names",
            "node",
            "none",
            "nonregistered",
            "noop",
            "notification",
            "notify",
            "NumberOfDatabaseStorageAccounts",
            "NumberOfDbStorageAccounts",
            "objects",
            "obtainer",
            "on",
            "operation",
            "operations",
            "ops",
            "orchestration",
            "outbound",
            "outboundnetworkdependencies",
            "ownerId",
            "package",
            "packages",
            "path",
            "perfviewlogs",
            "physical",
            "PipelineSpecifications",
            "pods",
            "policy",
            "pool",
            "prepare",
            "pretty",
            "PreviewFeatures",
            "primary",
            "principal",
            "principals",
            "private",
            "probe",
            "process",
            "processmemorysummary",
            "ProductVersion",
            "PublicUrl",
            "publish",
            "pubsub",
            "put",
            "queue",
            "queues",
            "rbac",
            "reallocate",
            "rebuild",
            "record",
            "records",
            "recreate",
            "recycle",
            "regenerate",
            "region",
            "regions",
            "register",
            "registry",
            "reimage",
            "reinstall",
            "remove",
            "rename",
            "replace",
            "RequiredCustomerActions",
            "resolve",
            "resource",
            "resourceId",
            "ResourceProvider",
            "ResourceProviderSettings",
            "resources",
            "restart",
            "results",
            "resume",
            "retry",
            "revoke",
            "roles",
            "rotate",
            "routetable",
            "running",
            "SaasResourceProviderSettings",
            "sandbox",
            "SandboxKinds",
            "scale",
            "ScaleAutomationSettings",
            "ScaleChangesRequireCustomerConsent",
            "sch",
            "schema",
            "script",
            "scripts",
            "secondary",
            "securityrules",
            "service",
            "services",
            "set",
            "sets",
            "settings",
            "sharedidentity",
            "show",
            "SketchCacheSize",
            "sku",
            "skus",
            "source",
            "sources",
            "status",
            "stop",
            "storage",
            "storageaccounts",
            "StorageAccounts",
            "StorageSoftDeleteProperties",
            "subnet",
            "subscription",
            "SubscriptionId",
            "subscriptions",
            "summary",
            "suspend",
            "synapse",
            "sync",
            "synthetics",
            "SyntheticsSettings",
            "system",
            "table",
            "TableFreshnessTestSettings",
            "tempstorage",
            "tenant",
            "tenantId",
            "TenantName",
            "tenants",
            "terminate",
            "throttling",
            "to",
            "trace",
            "trident",
            "tridentadmins",
            "trigger",
            "true",
            "unallocated",
            "uncommitted",
            "undelete",
            "uninstall",
            "unpublish",
            "unregister",
            "unrestrictedviewers",
            "update",
            "useglobalfeaturename",
            "UseOsVersion",
            "UsePseudoRandomKeyVaultName",
            "users",
            "v2",
            "v3",
            "validate",
            "verbose",
            "Verbose",
            "version",
            "versions",
            "viewers",
            "virtual",
            "virtualnetwork",
            "VirtualNetworkSettings",
            "visibility",
            "VmSize",
            "vmss",
            "warning",
            "Warning",
            "whatif",
            "with",
            "workspace",
            "zonal"
        };
    }
}
