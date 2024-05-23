package com.example.urbanplanning;

import static com.example.urbanplanning.Classes.GetDataClass.EstateObjects;
import static com.example.urbanplanning.Classes.GetDataClass.EstatePhotos;
import static com.example.urbanplanning.Classes.GetDataClass.Formats;
import static com.example.urbanplanning.Classes.GetDataClass.PostIndexes;
import static com.example.urbanplanning.Classes.GetDataClass.TypeOfActivities;

import android.annotation.SuppressLint;
import android.content.Intent;
import android.os.Bundle;
import android.text.Editable;
import android.text.TextWatcher;
import android.view.View;
import android.widget.AdapterView;
import android.widget.ArrayAdapter;
import android.widget.EditText;
import android.widget.Spinner;
import android.widget.TextView;

import androidx.appcompat.app.AppCompatActivity;

import com.example.urbanplanning.Classes.EstateObject;
import com.example.urbanplanning.Classes.EstatePhoto;
import com.example.urbanplanning.Classes.Format;
import com.example.urbanplanning.Classes.GetDataClass;
import com.example.urbanplanning.Classes.PostIndex;
import com.example.urbanplanning.Classes.TypeOfActivity;
import com.example.urbanplanning.WorkClasses.ListAdapter;
import com.example.urbanplanning.WorkClasses.ListData;
import com.example.urbanplanning.databinding.ActivityEstateObjectsViewBinding;

import java.util.ArrayList;
import java.util.Comparator;
import java.util.stream.Collectors;

public class EstateObjects_View extends AppCompatActivity implements AdapterView.OnItemSelectedListener {

    ActivityEstateObjectsViewBinding binding;
    ListAdapter listAdapter;
    ArrayList<ListData> dataArrayList = new ArrayList<>();
    ListData listData;
    ArrayList<EstateObject> OrderedEstateObjects;



    Spinner spOrder;
    EditText etSearch;
    int OrderPosition;


    GetDataClass getDataClass = new GetDataClass();

    @SuppressLint("MissingInflatedId")
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        binding = ActivityEstateObjectsViewBinding.inflate(getLayoutInflater());
        setContentView(R.layout.activity_estate_objects_view);
        setContentView(binding.getRoot());

        spOrder=findViewById(R.id.spinner_Order);

        ArrayList<String> orderList = new ArrayList<String>();orderList.add("По умолчанию");orderList.add("По цене");orderList.add("По площади");orderList.add("По адресу");

        spOrder.setOnItemSelectedListener(this);
        ArrayAdapter aa =new ArrayAdapter(this, androidx.appcompat.R.layout.support_simple_spinner_dropdown_item,orderList);
        aa.setDropDownViewResource(androidx.appcompat.R.layout.support_simple_spinner_dropdown_item);
        spOrder.setAdapter(aa);





        getDataClass.GetData();

        OrderedEstateObjects = EstateObjects;
//--------------------------


        for (EstateObject estateObject: OrderedEstateObjects) {
            ArrayList<PostIndex> postIndex = (ArrayList<PostIndex>)PostIndexes.stream().filter(x->x.IDPostindex==estateObject.IDPostIndex).collect(Collectors.toList());
            ArrayList<TypeOfActivity> typeOfActivity = (ArrayList<TypeOfActivity>)TypeOfActivities.stream().filter(x->x.IDTypeOfActivity==estateObject.IDTypeOfActivity).collect(Collectors.toList());
            ArrayList<Format> format = (ArrayList<Format>)Formats.stream().filter(x->x.IDFormat==estateObject.IDFormat).collect(Collectors.toList());

            ArrayList<EstatePhoto> estatePhoto = (ArrayList<EstatePhoto>)EstatePhotos.stream().filter(x->x.IDEstateObject==estateObject.IDEstateObject).collect(Collectors.toList());

            if (estatePhoto.size()>0)
            {
                listData = new ListData(estateObject.IDEstateObject,estateObject.Square,estateObject.Price,estateObject.DateOfDefinition,estateObject.DateOfApplication,estateObject.Number,estateObject.Adress,postIndex.get(0).Postindex1,typeOfActivity.get(0).Title,format.get(0).FormatTitle,estatePhoto.get(0).PhotoPath);
            }
            else {
                listData = new ListData(estateObject.IDEstateObject,estateObject.Square,estateObject.Price,estateObject.DateOfDefinition,estateObject.DateOfApplication,estateObject.Number,estateObject.Adress,postIndex.get(0).Postindex1,typeOfActivity.get(0).Title,format.get(0).FormatTitle,"https://static.tildacdn.com/tild6565-6639-4632-b765-646462396566/no-image3.jpg");
            }

            dataArrayList.add(listData);
        }

//--------------------------
        listAdapter = new ListAdapter(EstateObjects_View.this,dataArrayList);
        binding.listView.setAdapter(listAdapter);
        binding.listView.setClickable(true);

        binding.listView.setOnItemClickListener(new AdapterView.OnItemClickListener() {
            @Override
            public void onItemClick(AdapterView<?> parent, View view, int i, long id) {
                Intent intent = new Intent(EstateObjects_View.this, MoreEstateObject_View.class);
                TextView textView = findViewById(R.id.tv_EstateObjectID);
                String[] a = textView.getText().toString().split(" ");
                intent.putExtra("IDEstateObject",a[3]);
                startActivity(intent);
            }
        });



        etSearch=findViewById(R.id.editText_Search);
        etSearch.addTextChangedListener(new TextWatcher() {
            @Override
            public void beforeTextChanged(CharSequence s, int start, int count, int after) {

            }

            @Override
            public void onTextChanged(CharSequence s, int start, int before, int count) {
                ArrayList<ListData> newdataArrayList = new ArrayList<ListData>();
                ArrayList<ListData> f = (ArrayList<ListData>) dataArrayList.stream().filter(x->x.Adress.contains(etSearch.getText().toString())||(x.IDEstateObject+"").contains(etSearch.getText().toString()) ).collect(Collectors.toList());
                if(f.size()<1)
                {
                    switch (OrderPosition)
                    {
                        case 0:
                            dataArrayList = (ArrayList<ListData>) dataArrayList.stream().sorted((o1, o2) -> o1.IDEstateObject - o2.IDEstateObject).collect(Collectors.toList());
                            break;
                        case 1:
                            dataArrayList = (ArrayList<ListData>) dataArrayList.stream().sorted((o1, o2) -> (o1.Price+"").compareTo(o2.Price+"")).collect(Collectors.toList());
                            break;
                        case 2:
                            dataArrayList = (ArrayList<ListData>) dataArrayList.stream().sorted((o1, o2) -> (o1.Square+"").compareTo(o2.Square+"")).collect(Collectors.toList());
                            break;
                        case 3:
                            dataArrayList = (ArrayList<ListData>) dataArrayList.stream().sorted((o1, o2) -> o1.Adress.compareTo(o2.Adress)).collect(Collectors.toList());
                            break;
                    }

                    listAdapter = new ListAdapter(EstateObjects_View.this,dataArrayList);
                    binding.listView.setAdapter(listAdapter);
                    return;
                }
                for (ListData ld:f) {
                    newdataArrayList.add(ld);
                }

                switch (OrderPosition)
                {
                    case 0:
                        newdataArrayList = (ArrayList<ListData>) newdataArrayList.stream().sorted((o1, o2) -> o1.IDEstateObject - o2.IDEstateObject).collect(Collectors.toList());
                        break;
                    case 1:
                        newdataArrayList = (ArrayList<ListData>) newdataArrayList.stream().sorted((o1, o2) -> (o1.Price+"").compareTo(o2.Price+"")).collect(Collectors.toList());
                        break;
                    case 2:
                        newdataArrayList = (ArrayList<ListData>) newdataArrayList.stream().sorted((o1, o2) -> (o1.Square+"").compareTo(o2.Square+"")).collect(Collectors.toList());
                        break;
                    case 3:
                        newdataArrayList = (ArrayList<ListData>) newdataArrayList.stream().sorted((o1, o2) -> o1.Adress.compareTo(o2.Adress)).collect(Collectors.toList());
                        break;
                }
                listAdapter = new ListAdapter(EstateObjects_View.this,newdataArrayList);
                binding.listView.setAdapter(listAdapter);
            }

            @Override
            public void afterTextChanged(Editable s) {

            }
        });

    }

    @Override
    public void onItemSelected(AdapterView<?> parent, View view, int position, long id) {
        OrderPosition=position;
        switch (position)
        {
            case 0:
                dataArrayList = (ArrayList<ListData>) dataArrayList.stream().sorted((o1, o2) -> o1.IDEstateObject - o2.IDEstateObject).collect(Collectors.toList());
                break;
            case 1:
                dataArrayList = (ArrayList<ListData>) dataArrayList.stream().sorted((o1, o2) -> (o1.Price+"").compareTo(o2.Price+"")).collect(Collectors.toList());
                break;
            case 2:
                dataArrayList = (ArrayList<ListData>) dataArrayList.stream().sorted((o1, o2) -> (o1.Square+"").compareTo(o2.Square+"")).collect(Collectors.toList());
                break;
            case 3:
                dataArrayList = (ArrayList<ListData>) dataArrayList.stream().sorted((o1, o2) -> o1.Adress.compareTo(o2.Adress)).collect(Collectors.toList());
                break;
        }

        listAdapter = new ListAdapter(EstateObjects_View.this,dataArrayList);
        binding.listView.setAdapter(listAdapter);

    }

    @Override
    public void onNothingSelected(AdapterView<?> parent) {

    }
}