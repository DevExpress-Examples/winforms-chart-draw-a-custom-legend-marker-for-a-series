Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema

Namespace CustomDrawingSample.Model

    Public Partial Class Employee

        <Key>
        <Column("EmployeeID")>
        Public Property EmployeeId As Integer

        <Required>
        <StringLength(20)>
        Public Property LastName As String

        <Required>
        <StringLength(10)>
        Public Property FirstName As String

        <Column(TypeName:="image")>
        Public Property Photo As Byte()

        Overridable Public Property Orders As ICollection(Of Order)

        Public ReadOnly Property FullName As String
            Get
                Return String.Format("{0} {1}", FirstName, LastName)
            End Get
        End Property
    End Class
End Namespace
