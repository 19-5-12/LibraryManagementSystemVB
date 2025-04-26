Public Class CFReport

    Private CategoryStats As New Dictionary(Of String, CategoryStat)
    Private Sub CFReport_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        For Each btn In New Button() {BtnThisMonth, BtnLastMonth, BtnYearToDate, BtnThisQuarter, BtnCustomRange}
            EnableResponsiveCornerRadius(btn)
        Next

        For Each pnl In New Panel() {PnlBorrowingStatistics, PnlPopularCategories}
            Dim currentPanel = pnl

            AddHandler currentPanel.Paint, Sub(s, pe)
                                               StyleShadowPanel(DirectCast(s, Panel), pe)
                                           End Sub

            AddHandler currentPanel.Resize, Sub(s, args)
                                                currentPanel.Invalidate()
                                            End Sub
        Next

        Dim totalBorrowed As Integer = 186
        Dim booksReturned As Integer = 154

        LblNumberOfTotalBooks.Text = totalBorrowed.ToString()
        LblNumberOfBooksReturned.Text = booksReturned.ToString()

        SetReturnRateBar(PnlBarBack, PnlBarFill, booksReturned, totalBorrowed, LblReturnRatePercent)

        AddShadowBetweenRows(TLPBorrowingStatistics, 0, 1)
        AddShadowBetweenRows(TLPPopularCategories, 0, 1)

        CategoryStats.Add("Classic Literature", New CategoryStat With {
            .Value = 43,
            .FillPanel = PnlFillBarClassicLit,
            .BackPanel = PnlBackBarClassicLit
        })

        CategoryStats.Add("Science & Technology", New CategoryStat With {
            .Value = 37,
            .FillPanel = PnlFillBarSciTech,
            .BackPanel = PnlBackBarSciTech
        })

        CategoryStats.Add("History", New CategoryStat With {
            .Value = 32,
            .FillPanel = PnlFillBarHistory,
            .BackPanel = PnlBackBarHistory
        })

        CategoryStats.Add("Fiction", New CategoryStat With {
            .Value = 28,
            .FillPanel = PnlFillBarFiction,
            .BackPanel = PnlBackBarFiction
        })

        ' Then loop through all of them to set the progress:
        For Each stat In CategoryStats.Values
            Dim fullBarWidth As Integer = stat.BackPanel.Width
            SetCategoryBarProgress(stat.FillPanel, stat.Value, fullBarWidth)
        Next


    End Sub

    Private Sub PnlRow_Paint(sender As Object, e As PaintEventArgs) Handles PnlRow.Paint
        PanelPillRadius(PnlRow, e)
    End Sub

    Private Sub PnlForBarCL_Paint(sender As Object, e As PaintEventArgs)
        PanelPillRadius(PnlForBarCL, e)
    End Sub

    Private Sub PnlForSTBar_Paint(sender As Object, e As PaintEventArgs)
        PanelPillRadius(PnlForSTBar, e)
    End Sub

    Private Sub PnlForBarHistory_Paint(sender As Object, e As PaintEventArgs)
        PanelPillRadius(PnlForBarHistory, e)
    End Sub

    Private Sub PnlForFictionBar_Paint(sender As Object, e As PaintEventArgs)
        PanelPillRadius(PnlForFictionBar, e)
    End Sub

End Class