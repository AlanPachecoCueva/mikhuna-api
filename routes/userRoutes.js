const express = require("express");
const router = express.Router();
const { getAllByTable } = require("../database/generalMethods.js");
const { insertUser, deleteUser, updateUser } = require("../microservices/userService.js");

// Ruta para obtener todos los usuarios
router.get("", async (req, res) => {
  const response = await getAllByTable("Usuarios");

  if (!response.recordset) {
    res
      .status(500)
      .json({ error: "Error al ejecutar la consulta get: ", response });
  } else {
    res.send(response.recordset);
  }
});

// Ruta para crear un nuevo usuario
router.post("", async (req, res) => {
  const userData = req.body; // Acceder correctamente al cuerpo de la solicitud

  const response = await insertUser(userData);
  // Lógica para crear un nuevo usuario
  if (response.rowsAffected[0] < 1) {
    res
      .status(500)
      .json({ error: "Error al ejecutar la consulta post: ", response });
  } else {
    res.status(200).json({ userData });
  }
});

router.delete("/delete", async (req, res) => {
  const data = req.body;
  try {
    const resp = await deleteUser(data);
    if(resp){
      res.status(200).send(`User has been deleted.`);
    }else{
      res.status(500).json({ message: 'Error deleting user' });
    }
  } catch (error) {
    console.error(error);
    res.status(500).json({ message: 'Error deleting user' });
  }
});


router.put('/update', async (req, res) => {
  const data = req.body;
  try {
    const result = await updateUser(data);

    if(!result){
      res.status(500).json({ message: 'Error updating user' });
    }else{
      res.status(200).json(result);
    }
    
  } catch (error) {
    console.error(error);
    res.status(500).json({ message: 'Error updating user' });
  }
});

// Exporta el objeto router
module.exports = router;
