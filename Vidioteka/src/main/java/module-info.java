module com.example.vidioteka {
    requires javafx.controls;
    requires javafx.fxml;
    requires java.persistence;
    requires java.sql;


    opens com.example.vidioteka to javafx.fxml;
    exports com.example.vidioteka;
    exports com.example.vidioteka.entity;
    opens com.example.vidioteka.entity to javafx.fxml;
}