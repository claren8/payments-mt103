# Payments MT103 API

Minimal API built with .NET for ingesting and validating SWIFT MT103 messages.

## Features
- Receives MT103 as plain text
- Functional validation of mandatory fields
- Maps MT103 to internal Payment domain model
- Returns clear validation errors

## Endpoint
POST /payments/mt103  
Content-Type: text/plain

## Example MT103

:20:REF123456
:23B:CRED
:32A:250105USD1000,
:50K:/12345678
JUAN PEREZ
:59:/87654321
MARIA GOMEZ
:70:Invoice 2025-01

