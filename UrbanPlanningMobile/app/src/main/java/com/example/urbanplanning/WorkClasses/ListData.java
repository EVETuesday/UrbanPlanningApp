package com.example.urbanplanning.WorkClasses;

import java.sql.Date;

public class ListData {
    public int IDEstateObject;
    public double Square;
    public double Price;
    public Date DateOfDefinition;
    public Date DateOfApplication;
    public int Number;
    public String Adress;
    public String PostIndex;
    public String TypeOfActivity;
    public String Format;
    public  String image;

    public ListData(int IDEstateObject, double square, double price, Date dateOfDefinition, Date dateOfApplication, int number, String adress, String PostIndex, String TypeOfActivity, String Format, String image) {
        this.IDEstateObject = IDEstateObject;
        Square = square;
        Price = price;
        DateOfDefinition = dateOfDefinition;
        DateOfApplication = dateOfApplication;
        Number = number;
        Adress = adress;
        this.PostIndex = PostIndex;
        this.TypeOfActivity = TypeOfActivity;
        this.Format = Format;
        this.image = image;
    }
}
