const express = require("express");
const router = express.Router();
const { getAllByTable } = require("../database/generalMethods");
const {
  addRecipe,
  addIngredient,
  addStep,
  getRecipeById
} = require("../microservices/recipesService.js");

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

// Ruta para crear un nuevo usuario
router.post("", async (req, res) => {
  const data = req.body; // Acceder correctamente al cuerpo de la solicitud

  const response = await addRecipe(data);
  // Lógica para crear un nuevo usuario
  if (!response.status) {
    res.status(500).json({
      error: "Error al ejecutar la consulta post",
      response: response.content,
    });
  } else {
    res.status(200).json({ data });
  }
});

router.post("/ingredients", async (req, res) => {
  const data = req.body; // Acceder correctamente al cuerpo de la solicitud

  const response = await addIngredient(data);
  // Lógica para crear un nuevo usuario
  if (!response.status) {
    res.status(500).json({
      error: "Error al ejecutar la consulta post",
      response: response.content,
    });
  } else {
    res.status(200).json({ data });
  }
});

router.post("/steps", async (req, res) => {
  const data = req.body; // Acceder correctamente al cuerpo de la solicitud

  const response = await addStep(data);
  // Lógica para crear un nuevo usuario
  if (!response.status) {
    res.status(500).json({
      error: "Error al ejecutar la consulta post",
      response: response.content,
    });
  } else {
    res.status(200).json({ data });
  }
});

router.get("/:id", async (req, res) => {
  const { id } = req.params;
  const response = await getRecipeById(id);

  if (!response.status) {
    res.setHeader("Content-Type", "application/json");

    res.status(500).json({
      error: "Error al ejecutar la consulta get de receta por id",
      response: response.content,
    });
  } else {
    res.status(200).json(response.content);
  }
});

// Exporta el objeto router
module.exports = router;
