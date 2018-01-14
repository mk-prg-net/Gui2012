<?xml version="1.0" encoding="UTF-8" ?>
<xsl:stylesheet version="1.0"				
				xmlns:astro="http://www.tracs.de/Planeten.xsd"
                xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
                xmlns="http://www.w3.org/TR/REC-html40" >
                
  <xsl:output method="html"
              indent="yes" />

  

  <!-- Startpunkt der Transformation: Beim Öffnen des Dokumentes wird das Template
       angewendet und baut dabei die HTML Grundstruktur im Ausgabedokument auf-->
  <xsl:template match="/" >
    
        <h1>Tabelle der Planeten und Monde</h1>

        <!-- Hier wird die Kontrolle wieder an den XSLT- Prozessor übergeben, der in das 
             Dokument tiefer vordringt, und dabei wiederum versucht, Templates anzuwenden -->
        <xsl:apply-templates/>
      
  </xsl:template>

  <!-- Wird im Eingabedokument ein Element mit dem Namen "Planet" vom XSLT Prozessor erreicht,
       dann wird die Kontrolle an dieses Template übergeben. Es gibt eine h2 Überschrift aus und 
       baut den Rumpf einer Tabelle für die Daten der Monde auf, die den Planeten umkreisen -->
  <xsl:template match="astro:Planet">
    <h2>Monde von <xsl:value-of select="./@name"/></h2>
    <table border="1" bgcolor="#00a000">
      <tr>
        <th>Name</th>
        <th>Durchmesser</th>
        <th>Info</th>
      </tr>

      <!-- Hier wird die Kontrolle wieder an den XSLT- Prozessor übergeben, der in das 
           Dokument tiefer vordringt, und dabei wiederum versucht, Templates anzuwenden die nur
           für Elemente mit dem Namen "Mond" definiert sind. -->
      <xsl:apply-templates select="astro:Mond"/>      

    </table>    
  </xsl:template>

  <!-- Wird im Eingabedokument ein Element mit dem Namen "Mond" vom XSLT Prozessor erreicht,
       dann wird die Kontrolle an dieses Template übergeben. Es gibt eine Tabellenzeile mit den
       Daten des Mondes auf, die als Attribute gespeichert sind -->
  
  <xsl:template match="astro:Mond">

    <tr>
      <td>
        <xsl:value-of select="./@name"/>
      </td>
      <td>
        <xsl:value-of select="./astro:Durchmesser/@Wert"/>&#160;<xsl:value-of select="./Durchmesser/@Einheit"/>
      </td>
      <td>
        keine Infos
      </td>      
    </tr>
    
  </xsl:template> 
    
  
</xsl:stylesheet>