const express = require("express");
const router = express.Router();

const { registerUser, login } = require("../microservices/authService");

//Ruta para obtener todos los usuarios
router.get("/login", async (req, res) => {
  const data = req.body;
  const response = await login(data);
  if (!response.status) {
    res
      .status(500)
      .json({ error: "Error al ejecutar la consulta get: ", response: response.content });
  } else {
    res.send(response);
  }
});

// Ruta para crear un nuevo usuario
router.post("/register", async (req, res) => {
  const data = req.body; // Acceder correctamente al cuerpo de la solicitud

  const response = await registerUser(data);
  console.log("response register: ", response);
  // Lógica para crear un nuevo usuario
  if (!response.status) {
    res.status(500).json({ error: "Error al hacer register ", response: response.content });
  } else {
    res.status(200).json({ data });
  }
});

// router.delete("/delete", async (req, res) => {
//   const data = req.body;
//   try {
//     const resp = await deleteUser(data);
//     if (resp) {
//       res.status(200).send(`User has been deleted.`);
//     } else {
//       res.status(500).json({ message: "Error deleting user" });
//     }
//   } catch (error) {
//     console.error(error);
//     res.status(500).json({ message: "Error deleting user" });
//   }
// });

// router.put("/update", async (req, res) => {
//   const data = req.body;
//   try {
//     const result = await updateUser(data);

//     if (!result) {
//       res.status(500).json({ message: "Error updating user" });
//     } else {
//       res.status(200).json(result);
//     }
//   } catch (error) {
//     console.error(error);
//     res.status(500).json({ message: "Error updating user" });
//   }
// });

// Exporta el objeto router
module.exports = router;
