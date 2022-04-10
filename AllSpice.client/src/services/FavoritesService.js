import { AppState } from "../AppState"
import { logger } from "../utils/Logger"
import { api } from "./AxiosService"

class FavoritesService {

  async createFavorite(body) {
    const res = await api.post('/api/favorites', body)
    logger.log('createFavorite', res.data)
    AppState.favorites = res.data
  }

  async removeFavorite(id) {
    const res = await api.delete('/api/favorites/' + id)
    logger.log('deleteFavorite', res.data)
    AppState.favorites = res.data
  }
}

export const favoritesService = new FavoritesService()