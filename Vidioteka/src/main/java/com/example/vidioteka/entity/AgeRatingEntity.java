package com.example.vidioteka.entity;

import javax.persistence.*;
import java.util.Objects;

@Entity
@Table(name = "age_rating", schema = "public", catalog = "Vidioteka")
public class AgeRatingEntity {
    private String rating;
    private Integer newColumn;
    private int id;

    @Basic
    @Column(name = "rating")
    public String getRating() {
        return rating;
    }

    public void setRating(String rating) {
        this.rating = rating;
    }

    @Basic
    @Column(name = "new_column")
    public Integer getNewColumn() {
        return newColumn;
    }

    public void setNewColumn(Integer newColumn) {
        this.newColumn = newColumn;
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
        AgeRatingEntity that = (AgeRatingEntity) o;
        return id == that.id && Objects.equals(rating, that.rating) && Objects.equals(newColumn, that.newColumn);
    }

    @Override
    public int hashCode() {
        return Objects.hash(rating, newColumn, id);
    }
}
