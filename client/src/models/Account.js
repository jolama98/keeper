export class Account {
  /**
   * @type {string}
   */
  id;

  /**
   * @type {string}
   */
  email;

  /**
   * @type {string}
   */
  name;

  /**
   * @type {string}
   */
  picture;

  /**
  * @type {string}
  */
  coverImage;

  /**
   * @param {Object} data
   * @param {string} data.id
   * @param {string} data.email
   * @param {string} data.name
   * @param {string} data.picture
   * @param {string} data.coverImage
  */
  constructor({ id, email, name, picture, coverImage }) {
    this.id = id;
    this.email = email;
    this.name = name;
    this.picture = picture;
    this.coverImage = coverImage;
  }
}
