# Description
Take the attached log file and find where in the logs items will appear.


# Ask
Find instances of the below in the log file
- Login
- How many license are being used
- Logout
- Disposition of transaction, or where the idFinal was set to

# Solution

- Login:

tech_jwrenn logged in 4 times: the following line appeared 4 times

`Event: Eventname: "AgentLoggedInEvent" agentId: "100000039" login: "tech_jwrenn" eCausaCambioEstado: "10"   [AgenteStateManager::OnAgenteLoggedIn]`

- How many license are being used

The line: `GetDetailedAgentLicenses -> == TOTALES == Basicas: 1, Telefonia: 1, Marcador: 0, Grabacion: 1, Email: 0` appears 271 times

- Logout:
tech_jwrenn logged out 
tech_jwrenn@Coord[32c4]> [40::0x1E5F] Forzando chequeo de la caché debido al logout del agente tech_jwrenn.

- Disposition of transaction, or where the idFinal was set to

idFinal was set to 9 in the last appeareance in the logs.