Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema

Namespace CustomDrawingSample.Model

    Public Partial Class Order

        <Key>
        Public Property OrderID As Integer

        <Column("EmployeeID")>
        <ForeignKey("Employee")>
        Public Property EmployeeId As Integer?

        <Column("Freight", TypeName:="smallmoney")>
        Public Property Freight As Decimal

        <Column("OrderDate", TypeName:="datetime")>
        Public Property OrderDate As Date

        Public Overridable Property Employee As Employee
    End Class
End Namespace
