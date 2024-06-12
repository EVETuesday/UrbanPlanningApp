package com.example.urbanplanning.Classes;


import static android.content.Context.MODE_PRIVATE;

import android.content.ContextWrapper;
import android.content.SharedPreferences;
import android.widget.EditText;

import com.example.urbanplanning.MainActivity;
import com.example.urbanplanning.R;
import com.example.urbanplanning.databinding.ActivityMoreEstateObjectViewBinding;
import com.google.gson.Gson;
import com.google.gson.GsonBuilder;
import com.google.gson.reflect.TypeToken;

import java.io.BufferedReader;
import java.io.DataOutputStream;
import java.io.IOException;
import java.io.InputStreamReader;
import java.lang.reflect.Type;
import java.net.HttpURLConnection;
import java.net.URL;
import java.nio.charset.StandardCharsets;
import java.util.ArrayList;
import java.util.List;


public class GetDataClass {
    public boolean endThread = false;
    Client addedClient;

    public String API_URL = "http://192.168.0.13:5000";

    public static ArrayList<Gender> Genders = new ArrayList<Gender>();
    public static ArrayList<Client> Clients = new ArrayList<Client>();
    public static ArrayList<EstateObject> EstateObjects = new ArrayList<EstateObject>();
    public static ArrayList<EstatePhoto> EstatePhotos = new ArrayList<EstatePhoto>();
    public static ArrayList<PostIndex> PostIndexes = new ArrayList<PostIndex>();
    public static ArrayList<TypeOfActivity> TypeOfActivities = new ArrayList<TypeOfActivity>();
    public static ArrayList<Format> Formats = new ArrayList<Format>();
    public void GetData(){
        int timeout=0;
        Thread thread = new Thread(runnable);
        thread.start();
        while (!endThread)
        {

            try {
                Thread.sleep(100);
            } catch (InterruptedException e) {
                throw new RuntimeException(e);
            }
            timeout+=100;
            if (timeout>5100)
            {
                break;
            }
        }

    }

    public void AddNewClient(Client client){
        addedClient = client;
        int timeout=0;
        Thread thread = new Thread(runnable2);
        thread.start();
        while (!endThread)
        {
            try {
                Thread.sleep(100);
            } catch (InterruptedException e) {
                throw new RuntimeException(e);
            }
            timeout+=100;
            if (timeout>5100)
            {
                break;
            }
        }
    }
    Runnable runnable2=new Runnable() {
        @Override
        public void run() {
            endThread=false;
            String result;
            try{

                Gson gson=new Gson();
                String body = gson.toJson(addedClient);
                body=body.substring(0,body.length()-1);
                body=body+",\"Birthday\":\""+addedClient.BirthdaySTR+"\",\"Gender\":{\"IDGender\":2,\"GenderTitle\":\"Женщина\",\"Client\":[],\"Employee\":[]}}";

                try {
                    URL url = new URL(API_URL+"/api/Test/AddNewClient");
                    HttpURLConnection conn = (HttpURLConnection) url.openConnection();
                    conn.setRequestMethod("POST");
                    conn.setDoOutput(true);
                    conn.setRequestProperty("Content-Type", "application/json");


                    byte[] postData = body.getBytes(StandardCharsets.UTF_8);

                    try (DataOutputStream wr = new DataOutputStream(conn.getOutputStream())) {
                        wr.write(postData);
                    }

                    int a = conn.getResponseCode();
                    try (BufferedReader in = new BufferedReader(new InputStreamReader(conn.getInputStream(), "UTF-8"))) {
                        String inputLine;
                        while ((inputLine = in.readLine()) != null) {
                            System.out.println(inputLine);
                        }
                    }
                } catch (IOException e) {
                    e.printStackTrace();
                }


            }
            catch (Exception e)
            {
                result = e.getMessage();
            }
            endThread=true;
        }
    };

    Runnable runnable = new Runnable() {
        @Override
        public void run() {
            endThread=false;
            try{
                Gson gson = new GsonBuilder().setDateFormat("yyyy-MM-dd").create();
                Type listType = new TypeToken<List<Gender>>(){}.getType();
                Genders = gson.fromJson(getGenders(),listType);

                listType= new TypeToken<List<Client>>(){}.getType();
                Clients = gson.fromJson(getClients(),listType);

                listType= new TypeToken<List<EstateObject>>(){}.getType();
                EstateObjects = gson.fromJson(getEstateObjects(),listType);

                listType= new TypeToken<List<EstatePhoto>>(){}.getType();
                EstatePhotos = gson.fromJson(getEstatePhotos(),listType);

                listType= new TypeToken<List<PostIndex>>(){}.getType();
                PostIndexes = gson.fromJson(getPostIndexes(),listType);

                listType= new TypeToken<List<TypeOfActivity>>(){}.getType();
                TypeOfActivities = gson.fromJson(getTypeOfActivities(),listType);

                listType= new TypeToken<List<Format>>(){}.getType();
                Formats = gson.fromJson(getFormats(),listType);

            } catch(Exception e){
                String a = e.getMessage();
            };


            endThread=true;
        }
    };



    public String getGenders(Void... voids) {
        String response = "";
        try {
            URL url = new URL(API_URL+"/api/Gender/GetAllGenders");
            HttpURLConnection urlConnection = (HttpURLConnection) url.openConnection();
            urlConnection.setRequestMethod("GET");

            BufferedReader in = new BufferedReader(new InputStreamReader(urlConnection.getInputStream()));
            String inputLine;
            StringBuilder responseBuilder = new StringBuilder();

            while ((inputLine = in.readLine()) != null) {
                responseBuilder.append(inputLine);
            }

            in.close();
            response = responseBuilder.toString();
            urlConnection.disconnect();
        } catch (Exception e) {
            response = e.getMessage();
        }
        return response;
    }


    public String getClients(Void... voids) {
        String response = "";
        try {
            URL url = new URL(API_URL+"/api/Test/GetAllClients");
            HttpURLConnection urlConnection = (HttpURLConnection) url.openConnection();
            urlConnection.setRequestMethod("GET");

            BufferedReader in = new BufferedReader(new InputStreamReader(urlConnection.getInputStream()));
            String inputLine;
            StringBuilder responseBuilder = new StringBuilder();

            while ((inputLine = in.readLine()) != null) {
                responseBuilder.append(inputLine);
            }

            in.close();
            response = responseBuilder.toString();
            urlConnection.disconnect();
        } catch (Exception e) {
            response = e.getMessage();
        }
        return response;
    }



    public String getEstateObjects(Void... voids) {
        String response = "";
        try {
            URL url = new URL(API_URL+"/api/EstateObject/GetAllEstateObjects");
            HttpURLConnection urlConnection = (HttpURLConnection) url.openConnection();
            urlConnection.setRequestMethod("GET");

            BufferedReader in = new BufferedReader(new InputStreamReader(urlConnection.getInputStream()));
            String inputLine;
            StringBuilder responseBuilder = new StringBuilder();

            while ((inputLine = in.readLine()) != null) {
                responseBuilder.append(inputLine);
            }

            in.close();
            response = responseBuilder.toString();
            urlConnection.disconnect();
        } catch (Exception e) {
            response = e.getMessage();
        }
        return response;
    }



    public String getEstatePhotos(Void... voids) {
        String response = "";
        try {
            URL url = new URL(API_URL+"/api/EstatePhoto/GetAllEstatePhotos");
            HttpURLConnection urlConnection = (HttpURLConnection) url.openConnection();
            urlConnection.setRequestMethod("GET");

            BufferedReader in = new BufferedReader(new InputStreamReader(urlConnection.getInputStream()));
            String inputLine;
            StringBuilder responseBuilder = new StringBuilder();

            while ((inputLine = in.readLine()) != null) {
                responseBuilder.append(inputLine);
            }

            in.close();
            response = responseBuilder.toString();
            urlConnection.disconnect();
        } catch (Exception e) {
            response = e.getMessage();
        }
        return response;
    }

    public String getPostIndexes(Void... voids) {
        String response = "";
        try {
            URL url = new URL(API_URL+"/api/PostIndex/GetAllPostindexes");
            HttpURLConnection urlConnection = (HttpURLConnection) url.openConnection();
            urlConnection.setRequestMethod("GET");

            BufferedReader in = new BufferedReader(new InputStreamReader(urlConnection.getInputStream()));
            String inputLine;
            StringBuilder responseBuilder = new StringBuilder();

            while ((inputLine = in.readLine()) != null) {
                responseBuilder.append(inputLine);
            }

            in.close();
            response = responseBuilder.toString();
            urlConnection.disconnect();
        } catch (Exception e) {
            response = e.getMessage();
        }
        return response;
    }

    public String getTypeOfActivities(Void... voids) {
        String response = "";
        try {
            URL url = new URL(API_URL+"/api/TypeOfActivity/GetAllTypeOfActivity");
            HttpURLConnection urlConnection = (HttpURLConnection) url.openConnection();
            urlConnection.setRequestMethod("GET");

            BufferedReader in = new BufferedReader(new InputStreamReader(urlConnection.getInputStream()));
            String inputLine;
            StringBuilder responseBuilder = new StringBuilder();

            while ((inputLine = in.readLine()) != null) {
                responseBuilder.append(inputLine);
            }

            in.close();
            response = responseBuilder.toString();
            urlConnection.disconnect();
        } catch (Exception e) {
            response = e.getMessage();
        }
        return response;
    }
    public String getFormats(Void... voids) {
        String response = "";
        try {
            URL url = new URL(API_URL+"/api/Format/GetAllFormats");
            HttpURLConnection urlConnection = (HttpURLConnection) url.openConnection();
            urlConnection.setRequestMethod("GET");

            BufferedReader in = new BufferedReader(new InputStreamReader(urlConnection.getInputStream()));
            String inputLine;
            StringBuilder responseBuilder = new StringBuilder();

            while ((inputLine = in.readLine()) != null) {
                responseBuilder.append(inputLine);
            }

            in.close();
            response = responseBuilder.toString();
            urlConnection.disconnect();
        } catch (Exception e) {
            response = e.getMessage();
        }
        return response;
    }

}
