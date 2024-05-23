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

public class ListAdapterPhoto  extends ArrayAdapter<ListDataPhoto> {

    public ListAdapterPhoto(@NonNull Context context, ArrayList<ListDataPhoto> dataArrayList) {
        super(context, R.layout.list_item, dataArrayList);
    }

    @NonNull
    @Override
    public View getView(int position, @Nullable View view, @NonNull ViewGroup parent) {
        ListDataPhoto listDataPhoto= getItem(position);
        if (view==null)
        {
            view= LayoutInflater.from(getContext()).inflate(R.layout.list_photo_item,parent,false);
        }
        ImageView listImage_Photo = view.findViewById(R.id.listImage_Photo);

        Picasso.get().load(listDataPhoto.image).into(listImage_Photo);
        return view;
    }
}