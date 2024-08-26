import { logger } from "../utils/Logger.js"
import { api } from "./AxiosService.js"
import { AppState } from "../AppState.js"
import { Keep } from "@/models/Keep.js"

class KeepsService {


  setActiveKeep(keep) {
    AppState.setActiveKeep = keep
  }

  async getAllKeeps() {
    const response = await api.get('api/keeps')
    logger.log('All Keeps!!!!!!!!!!', response.data)
    const keep = response.data.map(keepPOJO => new Keep(keepPOJO))
    AppState.keeps = keep
  }


  // async getAllRecipes() {
  //   const response = await api.get('api/recipes')
  //   logger.log('GOT RECIPES 🍔', response.data)
  //   const recipes = response.data.map(recipePOJO => new Recipe(recipePOJO))
  //   AppState.recipes = recipes
  // }
}

export const keepsService = new KeepsService()
