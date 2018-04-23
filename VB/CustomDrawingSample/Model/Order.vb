Imports System
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema

Namespace CustomDrawingSample.Model
    Partial Public Class Order
        <Key> _
        Public Property OrderID() As Integer

        <Column("EmployeeID"), ForeignKey("Employee")> _
        Public Property EmployeeId() As Integer?

        <Column("Freight", TypeName := "smallmoney")> _
        Public Property Freight() As Decimal

        <Column("OrderDate", TypeName := "datetime")> _
        Public Property OrderDate() As Date

        Public Overridable Property Employee() As Employee
    End Class
End Namespace
