unit main;

{$mode objfpc}{$H+}

interface

uses
  Classes, SysUtils, FileUtil, Forms, Controls, Graphics, Dialogs, ExtCtrls,
  StdCtrls;

type

  { TForm1 }

  TForm1 = class(TForm)
    Wczytaj: TButton;
    Plik_We: TLabeledEdit;
    Do_Ukrycia: TLabeledEdit;
    Plik_Wy: TLabeledEdit;
    Do_Odczytu: TLabeledEdit;
    WczytajU: TButton;
    Zapisz: TButton;
    procedure Do_OdczytuChange(Sender: TObject);
    procedure Do_UkryciaChange(Sender: TObject);
    procedure FormCreate(Sender: TObject);
    procedure Plik_WeChange(Sender: TObject);
    procedure Plik_WyChange(Sender: TObject);
    procedure WczytajClick(Sender: TObject);
    procedure WczytajUClick(Sender: TObject);
    procedure ZapiszClick(Sender: TObject);
  private
    { private declarations }
  public
    { public declarations }
  end;

var
  Form1: TForm1;

implementation

{$R *.lfm}

{ TForm1 }

procedure TForm1.FormCreate(Sender: TObject);
begin

end;
///////////////////////////////////////////////////////
procedure TForm1.Plik_WeChange(Sender: TObject);
begin

end;

procedure TForm1.WczytajClick(Sender: TObject);
begin

end;
///////////////////////////////////////////////////////
procedure TForm1.Do_UkryciaChange(Sender: TObject);
begin

end;

procedure TForm1.ZapiszClick(Sender: TObject);
begin

end;
///////////////////////////////////////////////////////
procedure TForm1.Plik_WyChange(Sender: TObject);
begin

end;

procedure TForm1.WczytajUClick(Sender: TObject);
begin

end;
//////////////////////////////////////////////////////
procedure TForm1.Do_OdczytuChange(Sender: TObject);
begin

end;
//////////////////////////////////////////////////////
end.

