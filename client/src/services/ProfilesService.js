import { Keep } from "@/models/Keep.js"
import { AppState } from "../AppState.js"
import { Profile } from "../models/Profile.js"
import { logger } from "../utils/Logger.js"
import { api } from "./AxiosService.js"

class ProfilesService {
  async getProfileById(profileId) {
    const response = await api.get(`api/profiles/${profileId}`)
    const profile = new Profile(response.data)
    AppState.profile = profile
  }

  async getKeepsByProfileId(profileId) {
    AppState.profileKeeps = []

    const response = await api.get(`api/profiles/${profileId}/keeps`)
    logger.log('keeps', response.data)
    const keeps = response.data.map(keepPOJO => new Keep(keepPOJO))
    AppState.profileKeeps = keeps

  }
  async getVaultsByProfileId(profileId) {
    AppState.profileVaults = []

    const response = await api.get(`api/profiles/${profileId}/vaults`)
    logger.log('vaults', response.data)
    const vaults = response.data.map(vaultsPOJO => new Keep(vaultsPOJO))
    AppState.profileVaults = vaults

  }
}

export const profilesService = new ProfilesService()
