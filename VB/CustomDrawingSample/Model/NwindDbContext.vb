Imports System.Data.Entity

Namespace CustomDrawingSample.Model

    Partial Public Class NwindDbContext
        Inherits DbContext

        Public Sub New()
            MyBase.New("name=NwindDbContext")
        End Sub

        Public Overridable Property Employees() As DbSet(Of Employee)
        Public Overridable Property Orders() As DbSet(Of Order)

        Protected Overrides Sub OnModelCreating(ByVal modelBuilder As DbModelBuilder)
        End Sub
    End Class
End Namespace
