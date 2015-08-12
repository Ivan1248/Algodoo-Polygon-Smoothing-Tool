Imports System.Text.RegularExpressions
Imports System.IO
Imports System.Globalization

Public Class Form1

    Dim RawString As String
    Dim Substring0 As String
    Dim SmoothString As String
    Dim Substring2 As String

    Dim SmoothingMode As Integer = 0

    Dim Raw As List(Of PointF)
    Dim Smooth As List(Of PointF)



    Private Sub PasteButton_Click(sender As Object, e As EventArgs) Handles PasteButton.Click
        Try
            RawExclusions.Clear()
            RawString = Clipboard.GetText
            TextToRaw()
            DrawRaw()
            SmoothButton.Enabled = True
            PasteLabel.Text = "Polygon loaded"
            'If CInt(StrTB.Text) < 200 Then 
            SmoothButton.PerformClick()
        Catch ex As Exception
            SmoothButton.Enabled = False
            PasteLabel.Text = "Invalid polygon"
        End Try
    End Sub

    Private Sub SmoothButton_Click(sender As Object, e As EventArgs) Handles SmoothButton.Click
        SmoothButton.Enabled = False
        CopyButton.Enabled = False
        Me.Cursor = Cursors.WaitCursor
        BackgroundWorker1.RunWorkerAsync()
    End Sub

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        'TextToRaw()
        'Dim str As String = ""
        'For i = 0 To Raw.Count - 1
        '    str &= Raw(i).X & "," & Raw(i).Y & " "
        'Next
        'e.Result = str
        RawToSmooth()
        SmoothToText()
    End Sub
    Private Sub BackgroundWorker1_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        'TextBox1.Text = e.Result
        DrawSmooth()
        CopyLabel.Text = "Smoothed polygon"
        CopyButton.Enabled = True
        SmoothButton.Enabled = True
        Me.Cursor = Cursors.Arrow
    End Sub

    '///// Glavne funkcije ///////////////////////////////////////

    Private Sub TextToRaw()
        Raw = New List(Of PointF)
        Dim start As Integer = RawString.IndexOf("[[") + 2
        Dim ende As Integer = RawString.IndexOf("]]") + 1
        Substring0 = RawString.Substring(0, start)
        Substring2 = RawString.Substring(ende)

        Dim rgx1 = New Regex("(?<=\[).+?(?=\])").Matches(RawString.Substring(start, ende - start))
        For Each m As Match In rgx1
            Dim stringpoint = m.Value.Split(","c)
            Raw.Add(New PointF(Single.Parse(stringpoint(0), CultureInfo.InvariantCulture), Single.Parse(stringpoint(1), CultureInfo.InvariantCulture)))
        Next
        Smooth = CType(DeepCopy(Raw), Global.System.Collections.Generic.List(Of Global.System.Drawing.PointF))
    End Sub

    Private Sub RawToSmooth()
        Dim Strength As Integer = If(StrTB.Text.Length > 0, Integer.Parse(StrTB.Text), 0)
        Dim Range As Integer = If(RadTB.Text.Length > 0, Integer.Parse(RadTB.Text), 0)

        If Range > Raw.Count - 1 Then MsgBox("Error: Radius larger than number of points.") : Exit Sub

        Dim Midd As List(Of PointF) = CType(DeepCopy(Raw), Global.System.Collections.Generic.List(Of Global.System.Drawing.PointF))

        If Strength < 1 Then Smooth = CType(DeepCopy(Raw), Global.System.Collections.Generic.List(Of Global.System.Drawing.PointF))
        For N = 1 To Strength
            For i = 0 To (Midd.Count - 1)
                If Not RawExclusions.Contains(i) Then
                    Select Case SmoothingMode
                        Case 0 'prosječni položaj
                            Dim averageX As Double = 0
                            Dim averageY As Double = 0
                            For r = -Range To Range
                                Dim index = (i + r + Midd.Count) Mod Midd.Count
                                averageX += Midd(index).X
                                averageY += Midd(index).Y
                            Next
                            averageX /= (Range * 2 + 1)
                            averageY /= (Range * 2 + 1)
                            Smooth(i) = New PointF(averageX, averageY)
                        Case 1 'prosječni kut
                            Dim angles(Midd.Count - 1) As Double
                            Dim normals(Midd.Count - 1) As Double

                            For p = 0 To Midd.Count - 1
                                Dim prevp As PointF = Midd((p - 1 + Midd.Count) Mod Midd.Count)
                                Dim nextp As PointF = Midd((p + 1 + Midd.Count) Mod Midd.Count)
                                Dim A1 As Double = (Math.Atan2(nextp.Y - Midd(p).Y, nextp.X - Midd(p).X) + 2 * Math.PI) Mod (2 * Math.PI)
                                Dim A2 As Double = (Math.Atan2(prevp.Y - Midd(p).Y, prevp.X - Midd(p).X) + 2 * Math.PI) Mod (2 * Math.PI)

                                angles(p) = Math.Abs(A1 - A2)
                                normals(p) = (A1 + A2) / 2

                                MsgBox(angles(p))
                                'averageA += Math.Atan2(Midd(index).Y-Midd(index-1).y,
                            Next

                            Dim orientation As Integer = 0
                            Dim averageA As Integer = 0
                            For r = -Range To Range
                                Dim index = (i + r + Midd.Count) Mod Midd.Count
                                'averageA += Math.Atan2(Midd(index).Y-Midd(index-1).y,
                            Next
                    End Select
                Else
                    Smooth(i) = Raw(i)
                End If
            Next
            Midd = CType(DeepCopy(Smooth), Global.System.Collections.Generic.List(Of Global.System.Drawing.PointF))
        Next
    End Sub

    Private Sub SmoothToText()
        Dim text As String = String.Empty
        For Each pair As PointF In Smooth
            text &= "[" & Convert.ToString(pair.X).Replace(",", ".") & "," & Convert.ToString(pair.Y).Replace(",", ".") & "],"
        Next
        text = text.Substring(0, text.Length - 1)
        SmoothString = text
    End Sub

    '/////////////////////////////////////////////////////////////

    Private Sub CopyButton_Click(sender As Object, e As EventArgs) Handles CopyButton.Click
        Clipboard.SetText(Substring0 & SmoothString & Substring2)
    End Sub

    '///// Prikaz ////////////////////////////////////////////////

    Dim SizeFactor As Single = 0
    Dim ShiftX As Single = 0
    Dim ShiftY As Single = 0

    Dim RawDrawPoly() As PointF

    Private Sub DrawRaw()
        Dim maxX As Single = 0
        Dim minX As Single = 0
        Dim maxY As Single = 0
        Dim minY As Single = 0
        For i = 0 To Raw.Count - 1
            Select Case Raw(i).X
                Case Is > maxX : maxX = Raw(i).X
                Case Is < minX : minX = Raw(i).X
            End Select
            Select Case Raw(i).Y
                Case Is > maxY : maxY = Raw(i).Y
                Case Is < minY : minY = Raw(i).Y
            End Select
        Next
        Dim width As Single = maxX - minX
        Dim height As Single = maxY - minY
        Dim maxdim As Single = If(width > height, width, height)

        Dim factor As Single = 198 / maxdim

        SizeFactor = factor
        ShiftX = -minX + (maxdim - width) / 2
        ShiftY = -minY + (maxdim - height) / 2


        Dim g = Graphics.FromImage(RawImage)
        g.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias

        g.Clear(Color.Transparent)
        RawDrawPoly = Raw.ToArray
        For i = 0 To RawDrawPoly.Length - 1
            RawDrawPoly(i) = New PointF(1 + (RawDrawPoly(i).X + ShiftX) * factor, 199 - (RawDrawPoly(i).Y + ShiftY) * factor)
            g.FillRectangle(Brushes.White, New RectangleF(New PointF(CSng(RawDrawPoly(i).X - 0.5), CSng(RawDrawPoly(i).Y - 0.5)), New Size(1, 1)))
            'MsgBox(pts(i))
        Next
        g.FillPolygon(New SolidBrush(Color.FromArgb(128, 0, 0, 0)), RawDrawPoly)
        PictureBox1.BackgroundImage = RawImage
        PictureBox1.Refresh()
    End Sub
    Private Sub DrawSmooth()
        Dim SmoothImage As New Bitmap(200, 200)
        Dim g = Graphics.FromImage(SmoothImage)
        g.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias
        Dim pts = Smooth.ToArray
        For i = 0 To pts.Length - 1
            pts(i) = New PointF(1 + (pts(i).X + ShiftX) * SizeFactor, 199 - (pts(i).Y + ShiftY) * SizeFactor)
            'g.FillPolygon(Brushes.White,
            g.FillRectangle(Brushes.White, New RectangleF(New PointF(CSng(pts(i).X - 0.5), CSng(pts(i).Y - 0.5)), New Size(1, 1)))
        Next
        g.FillPolygon(New SolidBrush(Color.FromArgb(128, 0, 0, 0)), pts)
        PictureBox2.BackgroundImage = SmoothImage
    End Sub

    '/////////////////////////////////////////////////////////////

    '///// Označavanje iznimki //////////////////////////////////
    Dim selecting As Boolean = False

    Dim RawImage As New Bitmap(200, 200)

    Dim RawExclusions As New List(Of Integer)
    'Dim exclbmp As New Bitmap(200, 200)

    Private Sub PictureBox1_MouseDown(sender As Object, e As MouseEventArgs) Handles PictureBox1.MouseDown
        selecting = True
    End Sub
    Dim LineEndPoss As New List(Of Integer)

    Private Sub PictureBox1_MouseMove(sender As Object, e As MouseEventArgs) Handles PictureBox1.MouseMove
        If selecting Then
            'Dim g = Graphics.FromImage(exclbmp)
            'g.FillEllipse(New SolidBrush(Color.Aqua), New RectangleF(New PointF(e.X - 10, e.Y - 10), New Size(20, 20)))
            'g.FillRectangle(Brushes.AliceBlue, New Rectangle(e.Location, New Size(1, 1)))
            Dim bmp = CType(DeepCopy(RawImage), Bitmap)
            Dim g = Graphics.FromImage(bmp)
            g.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias
            'Exclusions.Add(-1)
            For i = 0 To RawDrawPoly.Length - 1
                If (e.X - RawDrawPoly(i).X) ^ 2 + (e.Y - RawDrawPoly(i).Y) ^ 2 <= 100 Then
                    If e.Button = Windows.Forms.MouseButtons.Left Then
                        If Not RawExclusions.Contains(i) Then
                            If RawExclusions.Count = 0 OrElse i > RawExclusions(RawExclusions.Count - 1) Then
                                RawExclusions.Add(i)
                            Else
                                For j = 0 To RawExclusions.Count - 1
                                    If i < RawExclusions(j) Then
                                        RawExclusions.Insert(j, i)
                                        Exit For
                                    End If
                                Next
                            End If
                        End If
                    Else
                        RawExclusions.Remove(i)
                    End If
                End If
            Next

            Select Case RawExclusions.Count
                Case RawDrawPoly.Count
                    g.DrawClosedCurve(Pens.Aquamarine, RawDrawPoly)
                Case Is <> 0
                    Dim ende As Integer = RawExclusions.Count - 1
                    Dim start As Integer = 0
                    If RawExclusions(0) = 0 AndAlso RawExclusions(ende) = RawDrawPoly.Count - 1 Then
                        For i = RawExclusions.Count - 1 To 1 Step -1
                            If RawExclusions(i) - 1 <> RawExclusions(i - 1) Then
                                ende = i
                                'g.FillEllipse(New SolidBrush(Color.Yellow), New RectangleF(New PointF(RawDrawPoly(ende).X - 2, RawDrawPoly(ende).Y - 2), New Size(4, 4)))
                                Exit For
                            End If
                        Next
                        For i = 0 To RawExclusions.Count - 2
                            If RawExclusions(i) + 1 <> RawExclusions(i + 1) Then
                                start = i
                                'g.FillEllipse(New SolidBrush(Color.Yellow), New RectangleF(New PointF(RawDrawPoly(start).X - 2, RawDrawPoly(start).Y - 2), New Size(4, 4)))

                                Exit For
                            End If
                        Next
                        Dim NofLefts As Integer = RawExclusions.Count - ende
                        Dim line(NofLefts + start) As PointF
                        For i = ende To RawExclusions.Count - 1
                            line(i - ende) = RawDrawPoly(RawExclusions(i))
                        Next
                        For i = 0 To start
                            line(i + NofLefts) = RawDrawPoly(RawExclusions(i))
                        Next
                        'For j = lastI To lastI
                        'line(j) = RawDrawPoly((Exclusions(Exclusions.Count - 1 - ende) + j) Mod Exclusions.Count)
                        'Next
                        g.DrawLines(Pens.Red, line)
                        'LineEnds.Add(ende)
                        'LineEnds.Add(start)
                    End If

                    Dim LineEnds As New List(Of Integer)

                    For i = start To ende
                        For j = i To ende
                            Try
                                If j = ende OrElse RawExclusions(j) + 1 <> RawExclusions(j + 1) Then
                                    'Dim addlast As Integer = If (exclusions(j+2)=ende andalso Exclusions(j+2
                                    LineEnds.Add(RawExclusions(i))
                                    LineEnds.Add(RawExclusions(j))
                                    i = j
                                    Exit For
                                    'ElseIf j = Exclusions.Count - 2 AndAlso i <> j Then
                                    '    LineEnds.Add(Exclusions(i))
                                    '    LineEnds.Add(Exclusions(j + 1))
                                    '    i = ende
                                    '    Exit For
                                End If
                            Catch
                                LineEnds.Add(RawExclusions(i))
                                LineEnds.Add(RawExclusions(j))
                                i = j + 1
                                Exit For
                            End Try
                        Next
                    Next

                    For i = 0 To LineEnds.Count - 1 Step 2
                        Dim length As Integer = LineEnds(i + 1) - LineEnds(i) + 1
                        If length > 1 Then
                            Dim line(length - 1) As PointF
                            For j = 0 To length - 1
                                line(j) = RawDrawPoly(LineEnds(i) + j)
                            Next
                            g.DrawLines(Pens.Orange, line)
                        Else
                            g.FillEllipse(Brushes.Orange, New RectangleF(New PointF(RawDrawPoly(LineEnds(i)).X - 1.5, RawDrawPoly(LineEnds(i)).Y - 1.5), New Size(3, 3)))
                        End If
                    Next
            End Select
            g.FillEllipse(Brushes.Red, New RectangleF(New PointF(RawDrawPoly(0).X - 1.5, RawDrawPoly(0).Y - 1.5), New Size(3, 3)))
            g.FillEllipse(Brushes.Blue, New RectangleF(New PointF(RawDrawPoly(RawDrawPoly.Count - 1).X - 1.5, RawDrawPoly(RawDrawPoly.Count - 1).Y - 1.5), New Size(3, 3)))

            PictureBox1.BackgroundImage = bmp

            PictureBox1.Refresh()
        End If
    End Sub
    Private Sub PictureBox1_MouseUp(sender As Object, e As MouseEventArgs) Handles PictureBox1.MouseUp
        selecting = False
    End Sub



    '/////////////////////////////////////////////////////////////


    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        MaximizeBox = False
        Me.Icon = New Icon(System.Reflection.Assembly.GetExecutingAssembly.GetManifestResourceStream("Smoothro.APST.ico"))
        RadTB.ContextMenu = New ContextMenu
        StrTB.ContextMenu = RadTB.ContextMenu
    End Sub
    Private Sub Form1_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.Control And e.KeyCode = Keys.V Then
            PasteButton.PerformClick()
        End If
        If e.Control And e.KeyCode = Keys.C Then
            CopyButton.PerformClick()
        End If
    End Sub
    Private Sub Form1_Paint(sender As Object, e As PaintEventArgs) Handles MyBase.Paint
        Dim gradBrush As New Drawing2D.LinearGradientBrush(Me.ClientRectangle, Color.FromArgb(255, 34, 77, 114), Color.FromArgb(255, 45, 100, 150), Drawing2D.LinearGradientMode.Vertical)
        e.Graphics.FillRectangle(gradBrush, Me.ClientRectangle)
    End Sub

    Private Sub RadTB_KeyPress(sender As Object, e As KeyPressEventArgs) Handles StrTB.KeyPress, RadTB.KeyPress
        Select Case e.KeyChar
            Case "0"c, "1"c, "2"c, "3"c, "4"c, "5"c, "6"c, "7"c, "8"c, "9"c, ChrW(Keys.Back), ChrW(Keys.Delete)
            Case Else
                e.Handled = True
        End Select
    End Sub

    '///// Ostale funkcije ///////////////////////////////////////

    Public Function DeepCopy(ByVal ObjectToCopy As Object) As Object
        Using mem As New MemoryStream
            Dim bf As New Runtime.Serialization.Formatters.Binary.BinaryFormatter
            bf.Serialize(mem, ObjectToCopy)
            mem.Seek(0, SeekOrigin.Begin)
            Return bf.Deserialize(mem)
        End Using
    End Function


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim str As String = ""
        For i = 0 To RawExclusions.Count - 1
            str &= RawExclusions(i) & " "
        Next
        MsgBox(str)
    End Sub
End Class

