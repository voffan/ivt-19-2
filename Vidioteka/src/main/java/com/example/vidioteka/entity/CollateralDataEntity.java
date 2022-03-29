package com.example.vidioteka.entity;

import javax.persistence.*;
import java.util.Objects;

@Entity
@Table(name = "collateral_data", schema = "public", catalog = "Vidioteka")
public class CollateralDataEntity {
    private String passport;
    private int money;
    private String item;
    private int id;

    @Basic
    @Column(name = "passport")
    public String getPassport() {
        return passport;
    }

    public void setPassport(String passport) {
        this.passport = passport;
    }

    @Basic
    @Column(name = "money")
    public int getMoney() {
        return money;
    }

    public void setMoney(int money) {
        this.money = money;
    }

    @Basic
    @Column(name = "item")
    public String getItem() {
        return item;
    }

    public void setItem(String item) {
        this.item = item;
    }

    @Id
    @Column(name = "id")
    public int getId() {
        return id;
    }

    public void setId(int id) {
        this.id = id;
    }

    @Override
    public boolean equals(Object o) {
        if (this == o) return true;
        if (o == null || getClass() != o.getClass()) return false;
        CollateralDataEntity that = (CollateralDataEntity) o;
        return money == that.money && id == that.id && Objects.equals(passport, that.passport) && Objects.equals(item, that.item);
    }

    @Override
    public int hashCode() {
        return Objects.hash(passport, money, item, id);
    }
}
