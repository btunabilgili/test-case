# Risk Analysis Application

### Migration Commands
To run migrations, use the following command:

```bash
dotnet ef database update --project RiskAnalysis.Persistance --startup-project RiskAnalysis.WebUI
```

### Test User for UI Application

- **Username:** `test_user`
- **Password:** `1234`

Alternatively, a user can be created from the registration section.

### Workflow Overview

1. **Adding Partner Companies:**
   Partner companies can be added via the relevant screen. Once added, a web API user can be created for the respective partner through the icon in the grid.

2. **Creating Agreements:**
   For each partner, agreements can be created through the designated screen. The risk level and keywords related to the agreement should be defined.

3. **Using the Web API for Risk Assessment:**
   The partner companies can send job subjects through the web API to retrieve the risk amount for the given agreement.

### API Workflow

1. **Obtain Token:**
   Before sending requests to the API, obtain a token by calling the `/api/token` endpoint using the partner’s username and password.

2. **Send Job Subjects:**
   Job subjects can be sent using the `/api/v1/job-subject` endpoint by providing the `AgreementId` and job subject content.

#### Sample Request:
```json
{
  "agreementId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
  "jobSubjectDetails": "string"
}
```

### Table Diagram
<img src="https://raw.githubusercontent.com/btunabilgili/test-case/master/sql_diagram.png" alt="Alt text" width="400"/>

