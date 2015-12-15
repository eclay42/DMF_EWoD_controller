Public Class Form1

    Public pin1_state As Boolean = False
    Public pin2_state As Boolean = False
    Public pin3_state As Boolean = False
    Public pin4_state As Boolean = False
    Public pin5_state As Boolean = False
    Public pin6_state As Boolean = False
    Public pin7_state As Boolean = False
    Public pin8_state As Boolean = False

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If pin1_state Then
            SerialPort1.WriteLine("1L")
            'MsgBox(SerialPort1.ReadLine)
            pin1_state = False
            Button1.BackColor = Color.Lime
        Else
            SerialPort1.WriteLine("1H")
            'MsgBox(SerialPort1.ReadLine)
            pin1_state = True
            Button1.BackColor = Color.Red
        End If
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        For Each sp As String In My.Computer.Ports.SerialPortNames
            ComboBox1.Items.Add(sp)
        Next
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        SerialPort1.Close()
        SerialPort1.PortName = ComboBox1.SelectedItem
        SerialPort1.Open()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If pin2_state Then
            SerialPort1.WriteLine("2L")
            'MsgBox(SerialPort1.ReadLine)
            pin2_state = False
            Button2.BackColor = Color.Lime
        Else
            SerialPort1.WriteLine("2H")
            'MsgBox(SerialPort1.ReadLine)
            pin2_state = True
            Button2.BackColor = Color.Red
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If pin3_state Then
            SerialPort1.WriteLine("3L")
            'MsgBox(SerialPort1.ReadLine)
            pin3_state = False
            Button3.BackColor = Color.Lime
        Else
            SerialPort1.WriteLine("3H")
            'MsgBox(SerialPort1.ReadLine)
            pin3_state = True
            Button3.BackColor = Color.Red
        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        If pin4_state Then
            SerialPort1.WriteLine("4L")
            'MsgBox(SerialPort1.ReadLine)
            pin4_state = False
            Button4.BackColor = Color.Lime
        Else
            SerialPort1.WriteLine("4H")
            'MsgBox(SerialPort1.ReadLine)
            pin4_state = True
            Button4.BackColor = Color.Red
        End If
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        If pin5_state Then
            SerialPort1.WriteLine("5L")
            'MsgBox(SerialPort1.ReadLine)
            pin5_state = False
            Button5.BackColor = Color.Lime
        Else
            SerialPort1.WriteLine("5H")
            'MsgBox(SerialPort1.ReadLine)
            pin5_state = True
            Button5.BackColor = Color.Red
        End If
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        If pin6_state Then
            SerialPort1.WriteLine("6L")
            'MsgBox(SerialPort1.ReadLine)
            pin6_state = False
            Button6.BackColor = Color.Lime
        Else
            SerialPort1.WriteLine("6H")
            'MsgBox(SerialPort1.ReadLine)
            pin6_state = True
            Button6.BackColor = Color.Red
        End If
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        If pin7_state Then
            SerialPort1.WriteLine("7L")
            'MsgBox(SerialPort1.ReadLine)
            pin7_state = False
            Button7.BackColor = Color.Lime
        Else
            SerialPort1.WriteLine("7H")
            'MsgBox(SerialPort1.ReadLine)
            pin7_state = True
            Button7.BackColor = Color.Red
        End If
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        If pin8_state Then
            SerialPort1.WriteLine("8L")
            'MsgBox(SerialPort1.ReadLine)
            pin8_state = False
            Button8.BackColor = Color.Lime
        Else
            SerialPort1.WriteLine("8H")
            'MsgBox(SerialPort1.ReadLine)
            pin8_state = True
            Button8.BackColor = Color.Red
        End If
    End Sub

    Private Sub pwmButton_Click(sender As Object, e As EventArgs) Handles pwmButton.Click
        SerialPort1.WriteLine(TextBox1.Text + "P" + TextBox2.Text)
    End Sub

    Private Sub btnReset_Click(sender As Object, e As EventArgs) Handles btnReset.Click
        SerialPort1.WriteLine("R")
        pin1_state = False
        Button1.BackColor = Color.Lime
        pin2_state = False
        Button2.BackColor = Color.Lime
        pin3_state = False
        Button3.BackColor = Color.Lime
        pin4_state = False
        Button4.BackColor = Color.Lime
        pin5_state = False
        Button5.BackColor = Color.Lime
        pin6_state = False
        Button6.BackColor = Color.Lime
        pin7_state = False
        Button7.BackColor = Color.Lime
        pin8_state = False
        Button8.BackColor = Color.Lime
    End Sub
End Class
