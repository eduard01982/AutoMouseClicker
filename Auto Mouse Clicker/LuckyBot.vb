Imports System.IO
Public Class Form1
    Dim fecha As Date = Today
    Dim archivo As String = fecha + ".csv"
    Dim oracion As String = ""
    Dim color As String = "ROJO"
    Dim numero_actual As Int16 = 0
    Dim apuesta As String = ""
    Dim parar As Boolean = False

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    End Sub

    Private Sub copiar()
        SendKeys.Send("^c")
    End Sub
    Private Sub pegar()
        SendKeys.Send("^v")
    End Sub

    Function gano()
        Dim color_que_salio As String
        'MsgBox("if " + color + "=" + color_salido() + " " + numero_actual.ToString)
        color_que_salio = color_salido()
        oracion = "'" + Today + " " + Now.ToLongTimeString + "','" + color + "','" + color_que_salio + "'"
        If color = color_que_salio Then
            'MsgBox("GANOOOOOO!!")
            Return True
        Else Return False
            'MsgBox(":(")
        End If
    End Function

    Function gano2()
        Dim apostoo As String
        Dim recibioo As String
        Dim apostod As Double
        Dim recibiod As Double

        apostoo = aposto().Trim
        recibioo = recibio().Trim
        oracion = oracion + "," + numero_actual.ToString + ","
        oracion = oracion + "," + apostoo + "," + recibioo
        Double.TryParse(apostoo, apostod)
        Double.TryParse(recibioo, recibiod)
        'MsgBox(apostod.ToString + " < " + recibiod.ToString)
        If apostod < recibiod Then
            'MsgBox("GANOOOOOO!!")
            Return True
        Else Return False
            'MsgBox(":(")
        End If
    End Function


    Sub cambiarColor()
        If color = "ROJO" Then
            color = "NEGRO"
        Else color = "ROJO"
        End If
    End Sub
    Function color_salido() As String
        Dim color_que_salio As String
        'MsgBox(ultimo_numero)
        Try
            numero_actual = Convert.ToInt16(ultimo_numero())
        Catch ex As Exception
            Try
                numero_actual = Convert.ToInt16(ultimo_numero2())
            Catch ex2 As Exception
                Try
                    numero_actual = Convert.ToInt16(ultimo_numero3())
                Catch
                    recargarBrowser()
                    numero_actual = Convert.ToInt16(ultimo_numero())
                End Try
            End Try
        End Try

        If ComboBoxTipo.SelectedItem.ToString = "REDBLACK" Then
            Select Case numero_actual
                Case 3, 9, 12, 18, 21, 27, 30, 36, 5, 14, 23, 32, 1, 7, 16, 19, 25, 34 'rojo
                    color_que_salio = "ROJO"

                Case 6, 15, 24, 33, 2, 8, 11, 17, 20, 26, 29, 35, 4, 10, 13, 22, 28, 31 'negro
                    color_que_salio = "NEGRO"

                Case Else
                    color_que_salio = "ZERO"
            End Select
        ElseIf ComboBoxTipo.SelectedItem.ToString = "EVENODD" Then
            Select Case numero_actual
                Case 1, 3, 5, 7, 9, 11, 13, 15, 17, 19, 21, 23, 25, 27, 29, 31, 33, 35 'odd
                    color_que_salio = "ROJO"

                Case 2, 4, 6, 8, 10, 12, 14, 16, 18, 20, 22, 24, 26, 28, 30, 32, 34, 36 'even
                    color_que_salio = "NEGRO"

                Case Else
                    color_que_salio = "ZERO"
            End Select
        ElseIf ComboBoxTipo.SelectedItem.ToString = "1-18&19-36" Then
            Select Case numero_actual
                Case 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32, 33, 34, 35, 36 '19-36
                    color_que_salio = "ROJO"

                Case 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18 '1-18
                    color_que_salio = "NEGRO"

                Case Else
                    color_que_salio = "ZERO"
            End Select
        End If

        'Console.WriteLine(tipo_actual)

        Return color_que_salio
    End Function

    Sub apostar(color As String, cantidad As Int16)
        Dim c As Int16 = 0

        If color = "ROJO" Then
            apuesta = "ROJO"
            While c < cantidad
                set_rojo()
                c = c + 1
            End While
        ElseIf color = "NEGRO" Then
            apuesta = "NEGRO"
            While c < cantidad
                set_negro()
                c = c + 1
            End While
        End If

    End Sub

    Sub resetApuesta()

        Mouse.SetMousePos(CX.Value, CY.Value) 'ultimo numero
        Mouse.LeftClick()

    End Sub

    Function cantidadPreApostada() As String
        System.Threading.Thread.Sleep(1000)
        Mouse.SetMousePos(PreApuestaX.Value, PreApuestaY.Value) 'ultimo numero
        Mouse.LeftClick()
        Mouse.LeftClick()

        System.Threading.Thread.Sleep(1000) '6000
        copiar()
        copiar()
        'MsgBox(My.Computer.Clipboard.GetText())
        Return My.Computer.Clipboard.GetText()
    End Function
    Function ultimo_numero() As String
        System.Threading.Thread.Sleep(6000)
        Mouse.SetMousePos(UltimoNroX.Value, UltimoNroY.Value) 'ultimo numero
        Mouse.LeftClick()
        Mouse.LeftClick()

        System.Threading.Thread.Sleep(2000) '6000
        copiar()
        copiar()
        'MsgBox(My.Computer.Clipboard.GetText())
        Return My.Computer.Clipboard.GetText()
    End Function

    Function ultimo_numero2() As String
        System.Threading.Thread.Sleep(6000)
        Mouse.SetMousePos(UltimoNro2X.Value, UltimoNro2Y.Value) 'ultimo numero
        Mouse.LeftClick()
        Mouse.LeftClick()

        System.Threading.Thread.Sleep(2000) '6000
        copiar()
        copiar()
        'MsgBox(My.Computer.Clipboard.GetText())
        Return My.Computer.Clipboard.GetText()
    End Function

    Function ultimo_numero3() As String
        System.Threading.Thread.Sleep(6000)
        Mouse.SetMousePos(UltimoNro3X.Value, UltimoNro3Y.Value) 'ultimo numero
        Mouse.LeftClick()
        Mouse.LeftClick()

        System.Threading.Thread.Sleep(2000) '6000
        copiar()
        copiar()
        'MsgBox(My.Computer.Clipboard.GetText())
        Return My.Computer.Clipboard.GetText()
    End Function

    Function aposto() As String
        System.Threading.Thread.Sleep(2000) '6000
        Mouse.SetMousePos(ApostoX.Value, ApostoY.Value)
        Mouse.LeftClick()
        Mouse.LeftClick()
        System.Threading.Thread.Sleep(2000)

        copiar()
        copiar()
        'MsgBox(My.Computer.Clipboard.GetText())
        Return My.Computer.Clipboard.GetText()
    End Function

    Function recibio() As String
        System.Threading.Thread.Sleep(2000)
        Mouse.SetMousePos(GanoX.Value, GanoY.Value)
        Mouse.LeftClick()
        Mouse.LeftClick()
        System.Threading.Thread.Sleep(2000)

        copiar()
        copiar()
        'MsgBox(My.Computer.Clipboard.GetText())
        Return My.Computer.Clipboard.GetText()
    End Function
    Sub set_rojo()
        Mouse.SetMousePos(RojoX.Value, RojoY.Value) 'rojo
        Mouse.LeftClick()
    End Sub

    Sub set_negro()
        Mouse.SetMousePos(NegroX.Value, NegroY.Value) 'negro
        Mouse.LeftClick()
    End Sub

    Sub girar()
        Mouse.SetMousePos(GirarX.Value, GirarY.Value) 'Girar
        Mouse.LeftClick()
    End Sub

    Sub cambiarSeeds()
        Mouse.SetMousePos(JustoX.Value, JustoY.Value)
        Mouse.LeftClick()
        System.Threading.Thread.Sleep(3000)
        Mouse.SetMousePos(AleatorioX.Value, AleatorioY.Value)
        Mouse.LeftClick()
        System.Threading.Thread.Sleep(3000)
        Mouse.SetMousePos(CerrarX.Value, CerrarY.Value)
        Mouse.LeftClick()
        System.Threading.Thread.Sleep(3000)
    End Sub
    Sub recargarBrowser()
        Mouse.SetMousePos(ReloadX.Value, ReloadY.Value)
        Mouse.LeftClick()
        System.Threading.Thread.Sleep(10000)
        Mouse.SetMousePos(MisApX.Value, MisApY.Value)
        Mouse.LeftClick()
        System.Threading.Thread.Sleep(3000)
    End Sub

    Private Sub CmdStart_Click() Handles CmdStart.Click
        Dim ganoo As Boolean = False
        Dim ganoo2 As Boolean = False
        Dim multiplicador As Int16 = 2
        Int16.TryParse(Multilicador.Value, multiplicador)
        parar = False
        Dim intentos As Int16 = multiplicador
        Dim intento_anterior As Int16 = multiplicador
        Dim i As Int16
        i = 0


        While Not parar
            ganoo = gano()
            ganoo2 = gano2()

            If ganoo Or ganoo2 Then
                oracion = oracion + ",'GANO'"
                cambiarColor()
                intentos = multiplicador
            Else
                oracion = oracion + ",'PERDIO'"
                Try
                    intento_anterior = intentos
                    intentos = intentos * multiplicador
                Catch
                    parar = True
                    MsgBox("¡Saldo Insuficiente!")
                End Try
            End If
            '------
            Try
                Dim ruta As String = "c:\luckylog\luckylog.csv"

                Dim escritor As StreamWriter
                escritor = File.AppendText(ruta)
                escritor.WriteLine(oracion)
                oracion = ""
                escritor.Flush()
                escritor.Close()
                'MessageBox.Show("Escritura realizada con éxito")
            Catch ex As Exception
                MessageBox.Show("Escritura de Log realizada incorrectamente")
            End Try
            '------

            If multiplicador ^ 4 <= intentos Then cambiarSeeds()

            Select Case intentos
                '2,4,8,16,32,64,128,256,512,1024,2048,4096,...
                Case multiplicador ^ 1, multiplicador ^ 2, multiplicador ^ 3, multiplicador ^ 4, multiplicador ^ 5, multiplicador ^ 6, multiplicador ^ 7, multiplicador ^ 8, multiplicador ^ 9, multiplicador ^ 10, multiplicador ^ 11, multiplicador ^ 12, multiplicador ^ 13, multiplicador ^ 14, multiplicador ^ 15, multiplicador ^ 16
                    If (multiplicador ^ 13 <= intentos) And (ganoo Or ganoo2) Then recargarBrowser() 'soluciona la trabada de cuando gano en 4096
                    apostar(color, intentos)
                    MsgBox(cantidadPreApostada().ToString)
                    If Convert.ToDouble(cantidadPreApostada()) Mod intentos = 0 Then 'soluciona el problema de que apueste cosas sin sentido
                        girar()
                    Else
                        MsgBox((Convert.ToDouble(cantidadPreApostada()) Mod intentos).ToString)
                        MsgBox((4096 Mod 2).ToString)
                        resetApuesta()
                        intentos = intento_anterior
                    End If

                Case Else
                    System.Threading.Thread.Sleep(60000)
                    intentos = intento_anterior
                    ' apostar(color, intentos)
            End Select

            System.Threading.Thread.Sleep(6000) '18000
            i = i + 1
        End While


    End Sub

    Private Sub ButtonStop_Click(sender As Object, e As EventArgs) Handles ButtonStop.Click
        parar = True
    End Sub
End Class

'Rojo (3,9,12,18,21,27,30,36,5,14,23,32,1,7,16,19,25,34)
'Negro (6,15,24,33,2,8,11,17,20,26,29,35,4,10,13,22,28,31)
'Primera Fila (3,9,12,18,21,27,30,36,6,15,24,33)
'Segunda Fila (5,14,23,32,2,8,11,17,20,26,29,35)
'Tercera Fila (1,7,16,19,25,34,4,10,13,22,28,31)
'Primera Columna (3,6,9,12,2,5,8,11,1,4,7,10)
'Segunda Columna (15,18,21,24,14,17,20,23,13,16,19,22)
'Tercera Columna (27,30,33,36,26,29,32,35,25,28,31,34)
'Par (2,4,6,8,10,12,14,16,18,20,22,24,26,28,30,32,34,36)
'Impar (1,3,5,7,9,11,13,15,17,19,21,23,25,27,29,31,33,35)
