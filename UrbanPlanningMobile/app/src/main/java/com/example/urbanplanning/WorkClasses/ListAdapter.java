package com.example.urbanplanning.WorkClasses;

import android.content.Context;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ArrayAdapter;
import android.widget.ImageView;
import android.widget.TextView;

import androidx.annotation.NonNull;
import androidx.annotation.Nullable;

import com.example.urbanplanning.R;
import com.squareup.picasso.Picasso;

import java.text.DecimalFormat;
import java.util.ArrayList;

public class ListAdapter extends ArrayAdapter<ListData> {

    public ListAdapter(@NonNull Context context, ArrayList<ListData> dataArrayList) {
        super(context, R.layout.list_item, dataArrayList);
    }

    @NonNull
    @Override
    public View getView(int position, @Nullable View view, @NonNull ViewGroup parent) {
        ListData listData= getItem(position);
        if (view==null)
        {
            view= LayoutInflater.from(getContext()).inflate(R.layout.list_item,parent,false);
        }
        ImageView listImage = view.findViewById(R.id.listImage);
        TextView tv_EstateObjectID = view.findViewById(R.id.tv_EstateObjectID);
        TextView tv_EstateObjectPrice = view.findViewById(R.id.tv_EstateObjectPrice);
        TextView tv_EstateObjectSquare = view.findViewById(R.id.tv_EstateObjectSquare);
        TextView tv_EstateObjectAddress = view.findViewById(R.id.tv_EstateObjectAddress);
        TextView tv_EstateObjectNumber = view.findViewById(R.id.tv_EstateObjectNumber);
        TextView tv_EstateObjectDateOfApplication = view.findViewById(R.id.tv_EstateObjectDateOfApplication);
        TextView tv_EstateObjectDateOfDefinition = view.findViewById(R.id.tv_EstateObjectDateOfDefinition);
        TextView tv_EstateObjectPostIndex = view.findViewById(R.id.tv_EstateObjectPostIndex);
        TextView tv_EstateObjectTypeOfActivity = view.findViewById(R.id.tv_EstateObjectTypeOfActivity);
        TextView tv_EstateObjectFormat = view.findViewById(R.id.tv_EstateObjectFormat);

        DecimalFormat DFormat = new DecimalFormat("#");

        Picasso.get().load(listData.image).into(listImage);
        tv_EstateObjectID.setText("Кадастровый номер объекта: "+listData.IDEstateObject+"");
        tv_EstateObjectPrice.setText("Цена: "+ DFormat.format(listData.Price));
        tv_EstateObjectSquare.setText("Площадь: "+DFormat.format(listData.Square));
        tv_EstateObjectAddress.setText("Адрес: "+listData.Adress);
        tv_EstateObjectNumber.setText("Номер объекта "+listData.Number+"");
        tv_EstateObjectDateOfApplication.setText("Дата ввода проекта в эксплуатацию: "+listData.DateOfApplication+"");
        tv_EstateObjectDateOfDefinition.setText("Дата утверждения проекта: "+listData.DateOfDefinition+"");
        tv_EstateObjectPostIndex.setText("Почтовый индекс: "+listData.PostIndex);
        tv_EstateObjectTypeOfActivity.setText("Тип объекта: "+listData.TypeOfActivity);
        tv_EstateObjectFormat.setText("Формат объекта: "+listData.Format);
        return view;
    }
}
