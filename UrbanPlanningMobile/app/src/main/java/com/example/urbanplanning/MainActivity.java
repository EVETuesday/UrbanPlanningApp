package com.example.urbanplanning;

import static com.example.urbanplanning.Classes.GetDataClass.Clients;

import android.annotation.SuppressLint;
import android.content.Intent;
import android.content.SharedPreferences;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.TextView;
import android.widget.Toast;

import androidx.appcompat.app.AppCompatActivity;
import androidx.appcompat.app.AppCompatDelegate;

import com.example.urbanplanning.Classes.Client;
import com.example.urbanplanning.Classes.GetDataClass;

import java.util.ArrayList;
import java.util.stream.Collectors;

public class MainActivity extends AppCompatActivity {

    EditText tb_Login;
    EditText tb_Password;

    TextView textViewSecret;
    int secretScore=0;
    EditText editTextTextIP;
    Button btnSecretGo;

    SharedPreferences settings;

    GetDataClass getDataClass= new GetDataClass();


    @SuppressLint("MissingInflatedId")
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        AppCompatDelegate.setDefaultNightMode(AppCompatDelegate.MODE_NIGHT_YES);
        Button btnEnter = findViewById(R.id.btnEnter);
        Button btnReg = findViewById(R.id.btnReg);

        tb_Login=findViewById(R.id.editText_MainLogin);
        tb_Password=findViewById(R.id.editText_MainPassword);
        textViewSecret=findViewById(R.id.textViewSecret);
        editTextTextIP=findViewById(R.id.editTextTextIP);
        btnSecretGo = findViewById(R.id.btnSecretGo);
        try {
            settings = getSharedPreferences("IP", MODE_PRIVATE);
            editTextTextIP.setText(settings.getString("IP","http://192.168.0.13:5000"));
        }
        catch(Exception ex)
        {

        }
        try {
            getDataClass.API_URL=settings.getString("IP","http://192.168.0.13:5000");
        }
        catch(Exception ex)
        {

        }


        btnSecretGo.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {

                SharedPreferences.Editor prefEditor = settings.edit();
                prefEditor.putString("IP", editTextTextIP.getText().toString());
                prefEditor.apply();
                getDataClass.API_URL=editTextTextIP.getText().toString();
                Toast.makeText(MainActivity.this,"IP Сохранён "+getDataClass.API_URL,Toast.LENGTH_LONG).show();
            }
        });

        textViewSecret.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                secretScore+=1;
                if (secretScore>=10)
                {
                    editTextTextIP.setVisibility(View.VISIBLE);
                    btnSecretGo.setVisibility(View.VISIBLE);
                    editTextTextIP.setEnabled(true);
                    btnSecretGo.setEnabled(true);

                }
                if (secretScore>=12)
                {
                    editTextTextIP.setVisibility(View.INVISIBLE);
                    btnSecretGo.setVisibility(View.INVISIBLE);
                    editTextTextIP.setEnabled(false);
                    btnSecretGo.setEnabled(false);
                    secretScore=0;
                }
            }
        });
        /*try {
            getDataClass.GetData();
        }
        catch (Exception ex)
        {
            Toast.makeText(MainActivity.this,"Отсутствует соединение с сервером",Toast.LENGTH_LONG).show();
        }*/



        btnEnter.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                getDataClass.GetData();
                ArrayList<Client> clients = (ArrayList<Client>) Clients.stream().filter(x->x.Login.equals(tb_Login.getText().toString())).filter(x->x.Password.equals(tb_Password.getText().toString())).collect(Collectors.toList());
                if (clients.size()<1)
                {
                    Toast.makeText(MainActivity.this,"Данный пользователь не найден",Toast.LENGTH_LONG).show();
                    return;
                }
                Intent intent = new Intent(MainActivity.this, EstateObjects_View.class);
                startActivity(intent);
            }
        });

        btnReg.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                Intent intent = new Intent(MainActivity.this, Registration.class);
                startActivity(intent);
            }
        });
    }
}