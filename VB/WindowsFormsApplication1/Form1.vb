Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Linq
Imports System.Text
Imports System.Windows.Forms
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.Grid.ViewInfo

Namespace WindowsFormsApplication1
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
			Dim list As New BindingList(Of MyObject)()
			Dim random As New Random()
			For i As Integer = 0 To 99
				list.Add(New MyObject(random.Next(1000), i.ToString()))
			Next i
			gridControl1.DataSource = list
			gridControl1.ForceInitialize()
			gridView1.PreviewFieldName = "Description"
			gridView1.OptionsView.ShowPreview = True
			Dim condition As New StyleFormatCondition(FormatConditionEnum.Greater, gridView1.Columns("Number"), Nothing, 300, Nothing, True)
			condition.Appearance.BackColor = Color.Green
			gridView1.FormatConditions.Add(condition)
			AddHandler gridView1.CustomDrawRowPreview, AddressOf gridView1_CustomDrawRowPreview
		End Sub

		Private Sub gridView1_CustomDrawRowPreview(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Base.RowObjectCustomDrawEventArgs)
			e.Appearance.Assign((TryCast(e.Info, GridDataRowInfo)).Appearance)
		End Sub
	End Class

    Public Class MyObject
        Public Sub New()

        End Sub

        ''' <summary>
        ''' Initializes a new instance of the MyClass class.
        ''' </summary>
        ''' <param name="number"></param>
        ''' <param name="description"></param>
        Public Sub New(ByVal number As Integer, ByVal description As String)
            _Number = number
            _Description = description
        End Sub


        Private _Number As Integer
        Public Property Number() As Integer
            Get
                Return _Number
            End Get
            Set(ByVal value As Integer)
                _Number = value
            End Set
        End Property

        Private _Description As String
        Public Property Description() As String
            Get
                Return _Description
            End Get
            Set(ByVal value As String)
                _Description = value
            End Set
        End Property

    End Class
End Namespace
