package com.example.urbanplanning;

import static com.example.urbanplanning.Classes.GetDataClass.Clients;
import static com.example.urbanplanning.Classes.GetDataClass.Genders;

import androidx.appcompat.app.AppCompatActivity;

import android.annotation.SuppressLint;
import android.content.Intent;
import android.content.SharedPreferences;
import android.os.Bundle;
import android.view.View;
import android.widget.AdapterView;
import android.widget.ArrayAdapter;
import android.widget.Button;
import android.widget.DatePicker;
import android.widget.EditText;
import android.widget.Spinner;
import android.widget.TextView;
import android.widget.Toast;

import com.example.urbanplanning.Classes.Client;
import com.example.urbanplanning.Classes.Gender;
import com.example.urbanplanning.Classes.GetDataClass;

import java.math.BigInteger;
import java.util.ArrayList;
import java.util.stream.Collectors;

public class LegalRegistration extends AppCompatActivity implements AdapterView.OnItemSelectedListener {


    Button btnLegalReg;
    EditText tbFirstName;
    EditText tbLastName;
    EditText tbPatronymic;
    Spinner spGender;
    DatePicker dpBirthday;
    EditText tbPhone;
    EditText tbCompanyTitle;
    EditText tbINN;
    EditText tbKPP;
    EditText tbOGRN;
    EditText tbBIK;
    EditText tbCorrespondentAccount;
    EditText tbPaymentAccount;
    EditText tbLogin;
    EditText tbPassword;
    EditText tbSecondPassword;

    SharedPreferences settings;
    GetDataClass getDataClass;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_legal_registration);

        getDataClass = new GetDataClass();
        try {
            settings = getSharedPreferences("IP", MODE_PRIVATE);
            getDataClass.API_URL=settings.getString("IP","http://192.168.0.13:5000");
        }
        catch(Exception ex)
        {

        }
        getDataClass.GetData();


        btnLegalReg = findViewById(R.id.btnLegalReg);
        tbFirstName = findViewById(R.id.editText_FirstNameLegal);
        tbLastName = findViewById(R.id.editText_LastNameLegal);
        tbPatronymic = findViewById(R.id.editText_PatronymicLegal);
        spGender = findViewById(R.id.Spinner_GendersLegal);
        dpBirthday = findViewById(R.id.date_picker_BirthdayLegal);
        tbPhone = findViewById(R.id.editText_PhoneLegal);
        tbCompanyTitle = findViewById(R.id.editText_CompanyTitle);
        tbINN = findViewById(R.id.editText_INN);
        tbBIK = findViewById(R.id.editText_BIK);
        tbOGRN = findViewById(R.id.editText_OGRN);
        tbKPP = findViewById(R.id.editText_KPP);
        tbCorrespondentAccount = findViewById(R.id.editText_CorrespondentAccount);
        tbPaymentAccount = findViewById(R.id.editText_PaymentAccount);
        tbLogin = findViewById(R.id.editText_LoginLegal);
        tbPassword = findViewById(R.id.editText_PasswordLegal);
        tbSecondPassword = findViewById(R.id.editText_SecondPasswordLegal);

        ArrayList<String> titleGender = new ArrayList<>();
        for (Gender gender:Genders) {
            titleGender.add(gender.GenderTitle);
        }
        spGender.setOnItemSelectedListener(this);
        ArrayAdapter aa =new ArrayAdapter(this, androidx.appcompat.R.layout.support_simple_spinner_dropdown_item,titleGender);
        aa.setDropDownViewResource(androidx.appcompat.R.layout.support_simple_spinner_dropdown_item);
        spGender.setAdapter(aa);


        btnLegalReg.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                if (tbFirstName.getText().toString().length() <= 0 || tbLastName.getText().toString().length()<= 0 ||tbPatronymic.getText().toString().length()<= 0 ||tbPhone.getText().toString().length()<= 0 ||tbLogin.getText().toString().length()<= 0 ||tbPassword.getText().toString().length()<= 0 ||tbCompanyTitle.getText().toString().length()<= 0 ||tbINN.getText().toString().length()<= 0 ||tbKPP.getText().toString().length()<= 0 ||tbOGRN.getText().toString().length()<= 0 ||tbBIK.getText().toString().length()<= 0 ||tbPaymentAccount.getText().toString().length()<= 0 ||tbCorrespondentAccount.getText().toString().length()<= 0||tbSecondPassword.getText().toString().length()<= 0)
                {
                    Toast.makeText(LegalRegistration.this,"Все поля должны быть заполненными",Toast.LENGTH_LONG).show();
                    return;
                }

                if(tbPhone.getText().toString().length()>13)
                {
                    Toast.makeText(LegalRegistration.this,"Неверные данные номера телефона",Toast.LENGTH_LONG).show();
                    return;
                }

                if(tbINN.getText().toString().length()!=10)
                {
                    Toast.makeText(LegalRegistration.this,"Неверные данные INN\nДлинна должна составлять 10 символов",Toast.LENGTH_LONG).show();
                    return;
                }

                if(tbKPP.getText().toString().length()!=9)
                {
                    Toast.makeText(LegalRegistration.this,"Неверные данные KPP\nДлинна должна составлять 9 символов",Toast.LENGTH_LONG).show();
                    return;
                }

                if(tbBIK.getText().toString().length()!=9)
                {
                    Toast.makeText(LegalRegistration.this,"Неверные данные BIK\nДлинна должна составлять 9 символов",Toast.LENGTH_LONG).show();
                    return;
                }

                if(tbOGRN.getText().toString().length()!=13)
                {
                    Toast.makeText(LegalRegistration.this,"Неверные данные OGRN\nДлинна должна составлять 13 символов",Toast.LENGTH_LONG).show();
                    return;
                }

                if(tbPaymentAccount.getText().toString().length()!=20)
                {
                    Toast.makeText(LegalRegistration.this,"Неверные данные платёжного счёта\nДлинна должна составлять 20 символов",Toast.LENGTH_LONG).show();
                    return;
                }

                if(tbCorrespondentAccount.getText().toString().length()!=20)
                {
                    Toast.makeText(LegalRegistration.this,"Неверные данные корреспондентского счёта\nДлинна должна составлять 20 символов",Toast.LENGTH_LONG).show();
                    return;
                }

                try {
                    BigInteger a;
                    a = new BigInteger(tbPhone.getText().toString());
                    a= new BigInteger(tbINN.getText().toString());
                    a= new BigInteger(tbKPP.getText().toString());
                    a= new BigInteger(tbOGRN.getText().toString());
                    a= new BigInteger(tbBIK.getText().toString());
                    a= new BigInteger(tbCorrespondentAccount.getText().toString());
                    a= new BigInteger(tbPaymentAccount.getText().toString());
                }
                catch (Exception ex)
                {
                    Toast.makeText(LegalRegistration.this,"Неверные данные",Toast.LENGTH_LONG).show();
                    return;
                }

                if (!tbPassword.getText().toString().equals(tbSecondPassword.getText().toString()))
                {
                    Toast.makeText(LegalRegistration.this,"Пароли должны совпадать",Toast.LENGTH_LONG).show();
                    return;
                }
                getDataClass.GetData();
                ArrayList<Client> client1 = (ArrayList<Client>) Clients.stream().filter(x->x.Login.equals(tbLogin.getText().toString())).collect(Collectors.toList());
                if (client1.size()>0)
                {
                    Toast.makeText(LegalRegistration.this,"Данный логин уже занят",Toast.LENGTH_LONG).show();
                    return;
                }
                ArrayList<Gender> gender = (ArrayList<Gender>) Genders.stream().filter(x->x.GenderTitle==spGender.getSelectedItem()).collect(Collectors.toList());
                Client client = new Client();
                client.FirstName=tbFirstName.getText().toString();
                client.LastName=tbLastName.getText().toString();
                client.Patronymic=tbPatronymic.getText().toString();
                client.IDGender=gender.get(0).IDGender;

                client.BirthdaySTR=dpBirthday.getYear()+"-";
                if(dpBirthday.getMonth()<10)
                {
                    client.BirthdaySTR+="0"+dpBirthday.getMonth()+"-";
                }
                else
                {
                    client.BirthdaySTR+=dpBirthday.getMonth()+"-";
                }
                if(dpBirthday.getDayOfMonth()<10)
                {
                    client.BirthdaySTR+="0"+dpBirthday.getDayOfMonth()+"T00:00:00";
                }
                else
                {
                    client.BirthdaySTR+=dpBirthday.getDayOfMonth()+"T00:00:00";
                }
                client.Phone=tbPhone.getText().toString();
                client.PasportSeries="null";
                client.PasportNumber="null";
                client.Login=tbLogin.getText().toString();
                client.Password=tbPassword.getText().toString();

                client.IsLegalEntity=true;
                client.BIK=tbBIK.getText().toString();
                client.KPP=tbKPP.getText().toString();
                client.OGRN=tbOGRN.getText().toString();
                client.INN=tbINN.getText().toString();
                client.CompanyTitle=tbCompanyTitle.getText().toString();
                client.PaymentAccount=tbPaymentAccount.getText().toString();
                client.CorrespondentAccount=tbCorrespondentAccount.getText().toString();

                getDataClass.AddNewClient(client);
                Toast.makeText(LegalRegistration.this,"Вы успешно зарегестрированны!",Toast.LENGTH_LONG).show();
                Intent intent = new Intent(LegalRegistration.this, MainActivity.class);
                startActivity(intent);
            }
        });

    }

    @Override
    public void onItemSelected(AdapterView<?> parent, View view, int position, long id) {

    }

    @Override
    public void onNothingSelected(AdapterView<?> parent) {

    }
}