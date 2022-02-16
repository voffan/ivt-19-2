package com.example.vidioteka.entity;

import javax.persistence.*;
import java.sql.Date;
import java.util.Objects;

@Entity
@Table(name = "ord", schema = "public", catalog = "Vidioteka")
public class OrdEntity {
    private int id;
    private int sum;
    private Date date;
    private Date returnDate;
    private boolean status;

    @Id
    @Column(name = "id")
    public int getId() {
        return id;
    }

    public void setId(int id) {
        this.id = id;
    }

    @Basic
    @Column(name = "sum")
    public int getSum() {
        return sum;
    }

    public void setSum(int sum) {
        this.sum = sum;
    }

    @Basic
    @Column(name = "date")
    public Date getDate() {
        return date;
    }

    public void setDate(Date date) {
        this.date = date;
    }

    @Basic
    @Column(name = "return_date")
    public Date getReturnDate() {
        return returnDate;
    }

    public void setReturnDate(Date returnDate) {
        this.returnDate = returnDate;
    }

    @Basic
    @Column(name = "status")
    public boolean isStatus() {
        return status;
    }

    public void setStatus(boolean status) {
        this.status = status;
    }

    @Override
    public boolean equals(Object o) {
        if (this == o) return true;
        if (o == null || getClass() != o.getClass()) return false;
        OrdEntity ordEntity = (OrdEntity) o;
        return id == ordEntity.id && sum == ordEntity.sum && status == ordEntity.status && Objects.equals(date, ordEntity.date) && Objects.equals(returnDate, ordEntity.returnDate);
    }

    @Override
    public int hashCode() {
        return Objects.hash(id, sum, date, returnDate, status);
    }
}
