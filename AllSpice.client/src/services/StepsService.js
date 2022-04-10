import { AppState } from "../AppState"
import { logger } from "../utils/Logger"
import { api } from "./AxiosService"

class StepsService {

  async createStep(body) {
    const res = await api.post('/api/steps', body)
    logger.log('createStep', res.data)
    AppState.steps = res.data
  }

  async updateStep(id, body) {
    const res = await api.put('/api/steps/' + id, body)
    logger.log('updateStep', res.data)
    AppState.steps = res.data
  }

  async removeStep() {
    const res = await api.delete('/api/steps/' + id)
    logger.log('removeStep', res.data)
    AppState.steps = res.data
  }
}
export const stepsService = new StepsService()