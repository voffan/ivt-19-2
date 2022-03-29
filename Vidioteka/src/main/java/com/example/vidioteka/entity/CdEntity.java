package com.example.vidioteka.entity;

import javax.persistence.*;
import java.util.Objects;

@Entity
@Table(name = "cd", schema = "public", catalog = "Vidioteka")
public class CdEntity {
    private int id;
    private int amount;
    private int price;

    @Id
    @Column(name = "id")
    public int getId() {
        return id;
    }

    public void setId(int id) {
        this.id = id;
    }

    @Basic
    @Column(name = "amount")
    public int getAmount() {
        return amount;
    }

    public void setAmount(int amount) {
        this.amount = amount;
    }

    @Basic
    @Column(name = "price")
    public int getPrice() {
        return price;
    }

    public void setPrice(int price) {
        this.price = price;
    }

    @Override
    public boolean equals(Object o) {
        if (this == o) return true;
        if (o == null || getClass() != o.getClass()) return false;
        CdEntity cdEntity = (CdEntity) o;
        return id == cdEntity.id && amount == cdEntity.amount && price == cdEntity.price;
    }

    @Override
    public int hashCode() {
        return Objects.hash(id, amount, price);
    }
}
