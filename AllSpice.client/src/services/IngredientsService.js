import { AppState } from "../AppState"
import { logger } from "../utils/Logger"
import { api } from "./AxiosService"

class IngredientsService {

  async createIngredient(body) {
    const res = await api.post('/api/ingredients', body)
    logger.log('createIngredient', res.data)
    AppState.ingredients = res.data

  }
  async updateIngredient(id, body) {
    const res = await api.put('/api/ingredients/' + id, body)
    logger.log('updateIngredient', res.data)
    AppState.ingredients = res.data
  }

  async removeIngredient(id) {
    const res = await api.delete('/api/ingredients/' + id)
    logger.log('removeIngredient', res.data)
    AppState.ingredients = res.data
  }
}
export const ingredientsService = new IngredientsService()