package com.example.urbanplanning;

import static com.example.urbanplanning.Classes.GetDataClass.EstateObjects;
import static com.example.urbanplanning.Classes.GetDataClass.EstatePhotos;
import static com.example.urbanplanning.Classes.GetDataClass.Formats;
import static com.example.urbanplanning.Classes.GetDataClass.PostIndexes;
import static com.example.urbanplanning.Classes.GetDataClass.TypeOfActivities;

import androidx.appcompat.app.AppCompatActivity;

import android.content.Intent;
import android.os.Bundle;

import com.example.urbanplanning.Classes.EstateObject;
import com.example.urbanplanning.Classes.EstatePhoto;
import com.example.urbanplanning.Classes.Format;
import com.example.urbanplanning.Classes.PostIndex;
import com.example.urbanplanning.Classes.TypeOfActivity;
import com.example.urbanplanning.WorkClasses.ListAdapter;
import com.example.urbanplanning.WorkClasses.ListAdapterPhoto;
import com.example.urbanplanning.WorkClasses.ListData;
import com.example.urbanplanning.WorkClasses.ListDataPhoto;
import com.example.urbanplanning.databinding.ActivityEstateObjectsViewBinding;
import com.example.urbanplanning.databinding.ActivityMoreEstateObjectViewBinding;

import java.text.DecimalFormat;
import java.util.ArrayList;
import java.util.stream.Collectors;

public class MoreEstateObject_View extends AppCompatActivity {

    ArrayList<EstateObject> estateObject;
    ActivityMoreEstateObjectViewBinding binding;
    ListAdapterPhoto listAdapterPhoto;
    ArrayList<ListDataPhoto> dataArrayList = new ArrayList<ListDataPhoto>();
    ListDataPhoto listDataPhoto;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        binding = ActivityMoreEstateObjectViewBinding.inflate(getLayoutInflater());
        setContentView(R.layout.activity_more_estate_object_view);
        setContentView(binding.getRoot());

        Intent intent = this.getIntent();
        if (intent!=null)
        {
            estateObject = (ArrayList<EstateObject>) EstateObjects.stream().filter(x->(x.IDEstateObject+"").equals(intent.getStringExtra("IDEstateObject"))).collect(Collectors.toList());
        }

        //--------------------------

ArrayList<EstatePhoto> estatePhotos = (ArrayList<EstatePhoto>) EstatePhotos.stream().filter(x->x.IDEstateObject==estateObject.get(0).IDEstateObject).collect(Collectors.toList()) ;
        if (estatePhotos.size()>0)
        {
            for (EstatePhoto estatePhoto: estatePhotos) {

                listDataPhoto = new ListDataPhoto(estatePhoto.PhotoPath);

                dataArrayList.add(listDataPhoto);
            }
        }
        else
        {
            listDataPhoto = new ListDataPhoto("https://static.tildacdn.com/tild6565-6639-4632-b765-646462396566/no-image3.jpg");

            dataArrayList.add(listDataPhoto);
        }


//--------------------------
        DecimalFormat DFormat = new DecimalFormat("#");

        listAdapterPhoto = new ListAdapterPhoto(MoreEstateObject_View.this,dataArrayList);
        binding.listViewPhoto.setAdapter(listAdapterPhoto);

        binding.tvEstateObjectIDMore.setText("Кадастровый номер объекта: "+estateObject.get(0).IDEstateObject);
        binding.tvEstateObjectPriceMore.setText("Цена: "+ DFormat.format(estateObject.get(0).Price));
        binding.tvEstateObjectSquareMore.setText("Площадь: "+DFormat.format(estateObject.get(0).Square));
        binding.tvEstateObjectAddressMore.setText("Адрес: "+estateObject.get(0).Adress);
        binding.tvEstateObjectNumberMore.setText("Номер объекта "+estateObject.get(0).Number+"");
        binding.tvEstateObjectDateOfApplicationMore.setText("Дата ввода проекта в эксплуатацию: "+estateObject.get(0).DateOfApplication+"");
        binding.tvEstateObjectDateOfDefinitionMore.setText("Дата утверждения проекта: "+estateObject.get(0).DateOfDefinition+"");

        ArrayList<PostIndex> postIndex = (ArrayList<PostIndex>)PostIndexes.stream().filter(x->x.IDPostindex==estateObject.get(0).IDPostIndex).collect(Collectors.toList());
        ArrayList<TypeOfActivity> typeOfActivity = (ArrayList<TypeOfActivity>)TypeOfActivities.stream().filter(x->x.IDTypeOfActivity==estateObject.get(0).IDTypeOfActivity).collect(Collectors.toList());
        ArrayList<Format> format = (ArrayList<Format>)Formats.stream().filter(x->x.IDFormat==estateObject.get(0).IDFormat).collect(Collectors.toList());

        binding.tvEstateObjectPostIndexMore.setText("Почтовый индекс: "+postIndex.get(0).Postindex1);
        binding.tvEstateObjectTypeOfActivityMore.setText("Тип объекта: "+typeOfActivity.get(0).Title);
        binding.tvEstateObjectFormatMore.setText("Формат объекта: "+format.get(0).FormatTitle);


    }
}