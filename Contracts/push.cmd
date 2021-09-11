
xcopy "EDMX\BillingData\ORSCF-BillingData.Schema.json" "..\BillingData\" /d /r /y /s
copy "EDMX\BillingData\ORSCF-BillingData.md" "..\BillingData\BdrModels.md" /Y
copy "Libs\BillingData.Model\v1\BdrServices.md" "..\BillingData\BdrServices.md" /Y

xcopy "EDMX\IdentityManagement\ORSCF-IdentityManagement.Schema.json" "..\IdentityManagement\" /d /r /y /s
copy "EDMX\IdentityManagement\ORSCF-IdentityManagement.md" "..\IdentityManagement\ImsModels.md" /Y
copy "Libs\IdentityManagement.Model\v1\ImsServices.md" "..\IdentityManagement\ImsServices.md" /Y

xcopy "EDMX\StudyManagement\ORSCF-StudyManagement.Schema.json" "..\StudyManagement\" /d /r /y /s
copy "EDMX\StudyManagement\ORSCF-StudyManagement.md" "..\StudyManagement\SmsModels.md" /Y
copy "Libs\StudyManagement.Model\v1\SmsServices.md" "..\StudyManagement\SmsServices.md" /Y

xcopy "EDMX\StudyWorkflowDefinition\ORSCF-StudyWorkflowDefinition.Schema.json" "..\StudyWorkflowDefinition\" /d /r /y /s
copy "EDMX\StudyWorkflowDefinition\ORSCF-StudyWorkflowDefinition.md" "..\StudyWorkflowDefinition\WdrModels.md" /Y
copy "Libs\StudyWorkflowDefinition.Model\v1\WdrServices.md" "..\StudyWorkflowDefinition\WdrServices.md" /Y

xcopy "EDMX\VisitData\ORSCF-VisitData.Schema.json" "..\VisitData\" /d /r /y /s
copy "EDMX\VisitData\ORSCF-VisitData.md" "..\VisitData\VdrModels.md" /Y
copy "Libs\VisitData.Model\v1\VdrServices.md" "..\VisitData\VdrServices.md" /Y
