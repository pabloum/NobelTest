CREATE PROCEDURE GetTransactionTotals
    @p_idCampaign INT = NULL,
    @p_userId INT = NULL,
    @p_idFinal INT = NULL
AS
BEGIN
    SELECT 
          CAMPANYA.NOMBRE AS CampaignName
        , CAMPANYA.IDCAMPANYA AS CampaignID
        , USUARIO.NAME AS AgentName
        , USUARIO.IDUSUARIO AS AgentName
        , USUARIO.LOGIN AS AgentLogin
        , COUNT(TRANSACCION.IDTRANSACCION) AS TotalTransactions
        , SUM(
            CASE 
                WHEN (TRANSACCION.tFinal - TRANSACCION.tInicio) >= CAMPANYA.TINICIAL 
                AND (TRANSACCION.tFinal - TRANSACCION.tInicio) <= CAMPANYA.TFINAL 
                THEN 1 
                ELSE 0 
            END
        ) AS 'Total Transactions Between tInicio and tFinal'
    FROM TRANSACCION 
    INNER JOIN USUARIO ON USUARIO.IDUSUARIO = TRANSACCION.idAgente 
    INNER JOIN CAMPANYA ON CAMPANYA.IDCAMPANYA = TRANSACCION.idCampanya 
    WHERE   (@p_idCampaign IS NULL OR CAMPANYA.IDCAMPANYA = @p_idCampaign)
        AND (@p_userId IS NULL OR USUARIO.IDUSUARIO = @p_userId)
        AND (@p_idFinal IS NULL OR TRANSACCION.idFinal = @p_idFinal)
    GROUP BY 
        CAMPANYA.NOMBRE,
        CAMPANYA.IDCAMPANYA,
        USUARIO.NAME,
        USUARIO.IDUSUARIO,
        USUARIO.LOGIN;
END