package com.example.urbanplanning;

import static com.example.urbanplanning.Classes.GetDataClass.Clients;
import static com.example.urbanplanning.Classes.GetDataClass.Genders;

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

import androidx.appcompat.app.AppCompatActivity;

import com.example.urbanplanning.Classes.Client;
import com.example.urbanplanning.Classes.Gender;
import com.example.urbanplanning.Classes.GetDataClass;

import java.math.BigInteger;
import java.util.Date;
import java.text.DateFormat;
import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.util.ArrayList;
import java.util.Locale;
import java.util.stream.Collectors;


public class Registration extends AppCompatActivity implements AdapterView.OnItemSelectedListener {


    Button btnNoLegalReg;
    Button btnRegMore;
    TextView textView_HeaderRegistration;


    EditText tbFirstName;
    EditText tbLastName;
    EditText tbPatronymic;
    Spinner spGender;
    DatePicker dpBirthday;
    EditText tbPhone;
    EditText tbPasportSeries;
    EditText tbPasportNumber;
    EditText tbLogin;
    EditText tbPassword;
    EditText tbSecondPassword;

    SharedPreferences settings;


    GetDataClass getDataClass;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_registration);

        getDataClass = new GetDataClass();
        try {
            settings = getSharedPreferences("IP", MODE_PRIVATE);
            getDataClass.API_URL=settings.getString("IP","http://192.168.0.13:5000");
        }
        catch(Exception ex)
        {

        }
        getDataClass.GetData();


        btnNoLegalReg = findViewById(R.id.btnNoLegalReg);
        btnRegMore = findViewById(R.id.btnRegMore);
        textView_HeaderRegistration = findViewById(R.id.textView_HeaderRegistration);
        tbFirstName = findViewById(R.id.editText_FirstName);
        tbLastName = findViewById(R.id.editText_LastName);
        tbPatronymic = findViewById(R.id.editText_Patronymic);
        spGender = findViewById(R.id.Spinner_Genders);
        dpBirthday = findViewById(R.id.date_picker_Birthday);
        tbPhone = findViewById(R.id.editText_Phone);
        tbPasportSeries = findViewById(R.id.editText_PasportSeries);
        tbPasportNumber = findViewById(R.id.editText_PasportNumber);
        tbLogin = findViewById(R.id.editText_Login);
        tbPassword = findViewById(R.id.editText_Password);
        tbSecondPassword = findViewById(R.id.editText_SecondPassword);

        ArrayList<String> titleGender = new ArrayList<>();
        for (Gender gender:Genders) {
            titleGender.add(gender.GenderTitle);
        }
        spGender.setOnItemSelectedListener(this);
        ArrayAdapter aa =new ArrayAdapter(this, androidx.appcompat.R.layout.support_simple_spinner_dropdown_item,titleGender);
        aa.setDropDownViewResource(androidx.appcompat.R.layout.support_simple_spinner_dropdown_item);
        spGender.setAdapter(aa);









        btnNoLegalReg.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                if (tbFirstName.getText().toString().length() <= 0 || tbLastName.getText().toString().length()<= 0 ||tbPatronymic.getText().toString().length()<= 0 ||tbPhone.getText().toString().length()<= 0 ||tbLogin.getText().toString().length()<= 0 ||tbPassword.getText().toString().length()<= 0 ||tbPasportSeries.getText().toString().length()<= 0 ||tbPasportNumber.getText().toString().length()<= 0||tbSecondPassword.getText().toString().length()<= 0)
                {
                    Toast.makeText(Registration.this,"Все поля должны быть заполненными",Toast.LENGTH_LONG).show();
                    return;
                }
                if (!tbPassword.getText().toString().equals(tbSecondPassword.getText().toString()))
                {
                    Toast.makeText(Registration.this,"Пароли должны совпадать",Toast.LENGTH_LONG).show();
                    return;
                }

                if(tbPasportSeries.getText().toString().length()!=4)
                {
                    Toast.makeText(Registration.this,"Неверные данные серии паспорта\nДлинна должна составлять 4 символа",Toast.LENGTH_LONG).show();
                    return;
                }
                if(tbPasportNumber.getText().toString().length()!=6)
                {
                    Toast.makeText(Registration.this,"Неверные данные номера паспорта\nДлинна должна составлять 6 символов",Toast.LENGTH_LONG).show();
                    return;
                }

                if(tbPhone.getText().toString().length()>13)
                {
                    Toast.makeText(Registration.this,"Не верные данные номера телефона",Toast.LENGTH_LONG).show();
                    return;
                }

                try {
                    BigInteger a;
                    a= new BigInteger(tbPhone.getText().toString());
                    a= new BigInteger(tbPasportNumber.getText().toString());
                    a= new BigInteger(tbPasportSeries.getText().toString());
                }
                catch (Exception ex)
                {
                    Toast.makeText(Registration.this,"Неверные данные",Toast.LENGTH_LONG).show();
                    return;
                }


                getDataClass.GetData();
                ArrayList<Client> client1 = (ArrayList<Client>) Clients.stream().filter(x->x.Login.equals(tbLogin.getText().toString())).collect(Collectors.toList());
                if (client1.size()>0)
                {
                    Toast.makeText(Registration.this,"Данный логин уже занят",Toast.LENGTH_LONG).show();
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
                client.PasportSeries=tbPasportSeries.getText().toString();
                client.PasportNumber=tbPasportNumber.getText().toString();
                client.Login=tbLogin.getText().toString();
                client.Password=tbPassword.getText().toString();

                client.IsLegalEntity=false;
                client.BIK="null";
                client.KPP="null";
                client.OGRN="null";
                client.INN="null";
                client.CompanyTitle="null";
                client.PaymentAccount="null";
                client.CorrespondentAccount="null";

                getDataClass.AddNewClient(client);
                Toast.makeText(Registration.this,"Вы успешно зарегестрированны!",Toast.LENGTH_LONG).show();
                Intent intent = new Intent(Registration.this, MainActivity.class);
                startActivity(intent);
            }
        });

        btnRegMore.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                Intent intent = new Intent(Registration.this, LegalRegistration.class);
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