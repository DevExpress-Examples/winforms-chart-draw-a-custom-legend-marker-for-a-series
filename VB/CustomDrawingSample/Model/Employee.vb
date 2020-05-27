Imports System.ComponentModel.DataAnnotations.Schema
Imports System.ComponentModel.DataAnnotations
Imports System.Collections.Generic
Imports System

Namespace CustomDrawingSample.Model

	Partial Public Class Employee
		<Key>
		<Column("EmployeeID")>
		Public Property EmployeeId() As Integer

		<Required>
		<StringLength(20)>
		Public Property LastName() As String

		<Required>
		<StringLength(10)>
		Public Property FirstName() As String

		<Column(TypeName := "image")>
		Public Property Photo() As Byte()

		Public Overridable Property Orders() As ICollection(Of Order)

		Public ReadOnly Property FullName() As String
			Get
				Return String.Format("{0} {1}", FirstName, LastName)
			End Get
		End Property
	End Class
End Namespace
