# Healthcare Claims Processor API
### Overview
This project is a small API for validating healthcare claims and
generating summary reports.
### Requirements
- .NET 9 SDK or higher
- NUnit for tests
### How to Run
```bash
dotnet build
dotnet run --project LyricHealthExercise.Api
API will be available at http://localhost:5000/claims/validate
```
### How to Test
```bash
dotnet test
```
### Example Request
curl -X POST http://localhost:5000/claims/validate \
-H "Content-Type: application/json" \
 -d '[
    {
      "Id": 1,
      "Provider": "Clinic A",
      "Amount": 100.5,
      "DiagnosisCode": "A01",
      "Status": "Approved"
    }
  ]'
### Example Response
{
    "totalClaims": 1,
    "validClaims": 1,
    "invalidClaims": 0,
    "totalApprovedAmount": 100.5
}
