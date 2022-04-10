import { AppState } from "../AppState"
import { logger } from "../utils/Logger"
import { api } from "./AxiosService"

class RecipesService {

  async getAllRecipes() {
    const res = await api.get("/api/recipes")
    logger.log('getallrecipes', res.data)
    AppState.recipes = res.data
  }

  async getAllIngredients(id) {
    const res = await api.get('/api/recipes/' + id + '/ingredients')
    logger.log(res.data)
    AppState.ingredients = res.data
  }

  async getAllSteps(id) {
    const res = await api.get('/api/steps/' + id + '/steps')
    logger.log(res.data)
    AppState.steps = res.data
  }

  async createRecipe(body) {
    const res = await api.post("/api/recipes", body)
    logger.log('createrecipe', res.data)
    AppState.recipes = res.data
  }

  async deleteRecipe(id) {
    const res = await api.delete("/api/recipes/" + id)
    logger.log(res.data)
    AppState.recipes = res.data
  }
}
export const recipesService = new RecipesService()