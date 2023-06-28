const express = require("express");
const router = express.Router();
const { getAllByTable } = require("../database/generalMethods");

// Ruta para obtener todos los usuarios
router.get("", async (req, res) => {
  const response = await getAllByTable("Recetas");

  if (!response.status) {
    res.status(500).json({
      error: "Error al ejecutar la consulta get ",
      response: response.content,
    });
  } else {
    res.status(200).json(response.content.recordset);
  }
});

// Exporta el objeto router
module.exports = router;
