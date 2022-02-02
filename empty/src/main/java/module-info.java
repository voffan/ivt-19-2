module com.example.empty {
    requires javafx.controls;
    requires javafx.fxml;


    opens com.example.empty to javafx.fxml;
    exports com.example.empty;
}