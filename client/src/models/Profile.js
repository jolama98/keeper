export class Profile {
  constructor(data) {
    this.id = data.id || data._id
    this.name = data.name
    this.picture = data.picture
    this.coverImg = data.coverImg
  }
}
