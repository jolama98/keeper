import { logger } from "../utils/Logger.js"
import { api } from "./AxiosService.js"
import { AppState } from "../AppState.js"
import { Keep } from "@/models/Keep.js"

class KeepsService {

  async createKeep(keepData) {
    const response = await api.post('api/keeps', keepData)
    const newKeep = new Keep(response.data)
    AppState.keeps.push(newKeep)
  }

  async setActiveKeep(keep) {
    AppState.setActiveKeep = null
    const response = await api.get(`api/keeps/${keep.id}`)
    AppState.setActiveKeep = response.data
  }


  async destroyKeep(keepId) {
    const response = await api.delete(`api/keeps/${keepId}`)
    const keepDelete = AppState.keeps.findIndex(KeepToDelete => KeepToDelete.id == keepId)
    AppState.keeps.splice(keepDelete, 1)
  }

  async getAllKeeps() {
    const response = await api.get('api/keeps')
    const keeps = response.data.map(keepPOJO => new Keep(keepPOJO))
    AppState.keeps = keeps
  }

  async getKeepById(keepId) {
    AppState.keepById = null
    const response = await api.get(`api/keeps/${keepId}`)
    logger.log(response.data)
    AppState.keepById = response.data


  }
}

export const keepsService = new KeepsService()
