Public Class MyConversionTool
    Friend Shared Function DateToYMDHMSDash(ByVal sDate As DateTime) As String
        Try
            Dim xDate As String = ""
            xDate = DateAndTime.Year(sDate).ToString & "-" & DateAndTime.Month(sDate).ToString.PadLeft(2, CChar("0")) & "-" & DateAndTime.Day(sDate).ToString.PadLeft(2, CChar("0"))
            xDate = xDate & " " & DateAndTime.Hour(sDate).ToString.PadLeft(2, CChar("0")) & ":" & DateAndTime.Minute(sDate).ToString.PadLeft(2, CChar("0")) & ":" & DateAndTime.Second(sDate).ToString.PadLeft(2, CChar("0"))
            Return xDate
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Friend Shared Function DateToYMDDash(ByVal sDate As DateTime) As String
        Try
            Dim xDate As String = ""
            xDate = DateAndTime.Year(sDate).ToString & "-" & DateAndTime.Month(sDate).ToString.PadLeft(2, CChar("0")) & "-" & DateAndTime.Day(sDate).ToString.PadLeft(2, CChar("0"))
            Return xDate
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Friend Shared Function TimeHHmmSS(ByVal sDate As DateTime) As String
        Try
            Dim xDate As String = ""
            xDate = DateAndTime.Hour(sDate).ToString.PadLeft(2, CChar("0")) & ":" & DateAndTime.Minute(sDate).ToString.PadLeft(2, CChar("0")) & ":" & DateAndTime.Second(sDate).ToString.PadLeft(2, CChar("0"))
            Return xDate
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Friend Shared Function FormatDecimalCurrency2DP(ByVal value As Double) As String
        Return Strings.FormatNumber(value, 2, TriState.True, TriState.False, TriState.True)
    End Function

    Friend Shared Function FormatDecimalCurrency2DP(ByVal value As String) As String
        Dim sValue As Decimal = CDec(value)
        Return Strings.FormatNumber(sValue, 2, TriState.True, TriState.False, TriState.True)
    End Function
End Class
